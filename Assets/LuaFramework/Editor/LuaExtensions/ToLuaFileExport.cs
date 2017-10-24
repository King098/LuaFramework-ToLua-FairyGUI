using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.IO;

public static class ToLuaFileExport
{
    [MenuItem("Lua/Export ToLuaExtendFile", false, 53)]
    public static void ExportToLuaExtendFile()
    {
        if (!Application.isPlaying)
        {
            EditorApplication.isPlaying = true;
        }

        Type[] list = ToLuaFile.exports;
        Dictionary<Type, List<MethodInfo>> dicTypeMethods = new Dictionary<Type, List<MethodInfo>>();
        for (int i = 0; i < list.Length; ++i)
        {
            Type type = list[i];
            List<MethodInfo> ltMethodInfo = new List<MethodInfo>();
            ltMethodInfo.AddRange(type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly));
            for (int j = 0; j < ltMethodInfo.Count; ++j)
            {
                MethodInfo method = ltMethodInfo[j];

                ParameterInfo[] parameterInfos = method.GetParameters();
                if (parameterInfos == null || parameterInfos.Length <= 0)
                    continue;

                Type parameterType = GetType(parameterInfos[0].ParameterType);
                if (parameterType.IsGenericParameter)
                    continue;

                if (dicTypeMethods.ContainsKey(parameterType))
                {
                    dicTypeMethods[parameterType].Add(method);
                }
                else
                {
                    List<MethodInfo> lt = new List<MethodInfo>();
                    lt.Add(method);
                    dicTypeMethods[parameterType] = lt;
                }
            }
        }

        foreach (KeyValuePair<Type, List<MethodInfo>> pair in dicTypeMethods)
        {
            if (pair.Key.IsGenericType)
                continue;

            SaveFile(pair.Key, pair.Value);
        }

        EditorApplication.isPlaying = false;
        Debug.Log("Export ToLuaExtendFiles over");
        AssetDatabase.Refresh();
    }

    static string ToLuaPath
    {
        get
        {
            return Application.dataPath + @"/LuaFramework/Editor/Wrap/";
        }
    }

    static Type GetType(Type type)
    {
        if (type.IsGenericParameter)
            return type.BaseType;

        return type;
    }

    static string GetTypeStr(Type type)
    {
        Type trueType = GetType(type);
        if (trueType == typeof(void))
            return "void";
        else
            return ToLuaExport.GetTypeStr(trueType);
    }

    static void SaveFile(Type type, List<MethodInfo> ltMethodInfo)
    {
        string fileName = "ToLua_" + type.FullName.Replace(".", "_");
        string path = ToLuaPath + fileName + ".cs";
        if (File.Exists(path))
            File.Delete(path);

        List<string> ltUsing = new List<string>();
        ltUsing.Add("System");
        ltUsing.Add("UnityEngine");
        using (StreamWriter textWriter = new StreamWriter(path, false, Encoding.UTF8))
        {
            StringBuilder usb = new StringBuilder();
            foreach (string str in ltUsing)
            {
                usb.AppendFormat("using {0};\r\n", str);
            }
            usb.AppendLine();
            usb.AppendFormat("public class {0}\r\n", fileName);
            usb.AppendLine("{\r\n");

            for (int i = 0; i < ltMethodInfo.Count; ++i)
            {
                MethodInfo m = ltMethodInfo[i];

                string returnType = GetTypeStr(m.ReturnType);
                usb.AppendFormat("\tpublic {0} {1}(", returnType, m.Name);
                ParameterInfo[] parameterInfos = m.GetParameters();
                for(int j = 1; j < parameterInfos.Length; ++j)
                {
                    ParameterInfo p = parameterInfos[j];
                    usb.AppendFormat("{0} arg{1}", GetTypeStr(p.ParameterType), j);
                    if (j < parameterInfos.Length - 1) usb.Append(", ");
                }
                usb.Append(")");
                if (returnType == "void")
                    usb.Append("\t{}\r\n");
                else
                    usb.Append("\t{ return default(" + returnType + "); }\r\n");
            }

            usb.AppendLine("}\r\n");
            textWriter.Write(usb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }
    }
}