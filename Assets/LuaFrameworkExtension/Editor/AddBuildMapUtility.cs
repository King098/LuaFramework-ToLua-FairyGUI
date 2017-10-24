using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Text;

public enum SuffixEnum
{
    Prefab,
    Png,
    Csv,
    Txt,
}

public class AddBuildMapUtility : EditorWindow {

    int count = 0;
    List<string> bundleNameList = new List<string>();
    List<SuffixEnum> suffixList = new List<SuffixEnum>();
    List<string> pathList = new List<string>();

    Vector2 scrollValue = Vector2.zero;

    [MenuItem("LuaFramework/AddBuildMap")]
    static void SetAssetBundleNameExtension()
    {
        EditorWindow.GetWindow<AddBuildMapUtility>();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("添加一项"))
        {
            AddItem();
        }
        if (GUILayout.Button("清除所有项"))
        {
            Clear();
        }
        if (GUILayout.Button("读取文件(.csv)"))
        {
            Clear();

            string path = EditorUtility.OpenFilePanel("", Application.dataPath, "csv");
            string content = File.ReadAllText(path);
            string[] contents = content.Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < contents.Length; i++)
            {
                string[] a = contents[i].Split(',');
                AddItem(a[0], StringToEnum(a[1]), a[2]);
            }
        }
        if (GUILayout.Button("保存"))
        {
            string path = EditorUtility.SaveFilePanel("", Application.dataPath, "AssetBundleInfo", "csv");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (string.IsNullOrEmpty(bundleNameList[i])) break;
                sb.Append(bundleNameList[i] + ",");
                sb.Append(EnumToString(suffixList[i]) + ",");
                sb.Append(pathList[i] + "\r\n");
            }
            File.WriteAllText(path, sb.ToString());
            AssetDatabase.Refresh();
        }
        if (GUILayout.Button("自动填写(所有选中的)"))
        {
            int startIndex = count;
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                AddItem();
                AutoFill(startIndex, Selection.objects[i]);
                startIndex++;
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("注意：请以文件夹为单位进行选择！！！文件夹名即为包名！！！");

        scrollValue = EditorGUILayout.BeginScrollView(scrollValue);
        for (int i = 0; i < count; i++)
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(i.ToString() + "AB包名");
            bundleNameList[i] = EditorGUILayout.TextField("", bundleNameList[i]);
            suffixList[i] = (SuffixEnum)EditorGUILayout.EnumPopup("类型", suffixList[i]);
            pathList[i] = EditorGUILayout.TextField("路径", pathList[i]);

            if (GUILayout.Button("自动填写(单个)"))
            {
                AutoFill(i, Selection.objects[0]);
            }
            if (GUILayout.Button("输出路径"))
            {
                Debug.Log(pathList[i]);
            }
            if (GUILayout.Button("删除该项"))
            {
                RemoveItem(i);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndScrollView();
    }

    void Clear()
    {
        count = 0;
        bundleNameList = new List<string>();
        suffixList = new List<SuffixEnum>();
        pathList = new List<string>();
    }

    void AddItem(string bundleName = "", SuffixEnum suffix = SuffixEnum.Prefab, string path = "")
    {
        count++;
        bundleNameList.Add(bundleName);
        suffixList.Add(suffix);
        pathList.Add(path);
    }

    void RemoveItem(int index)
    {
        count--;
        bundleNameList.Remove(bundleNameList[index]);
        suffixList.Remove(suffixList[index]);
        pathList.Remove(pathList[index]);
    }

    void AutoFill(int index, Object selectedObject)
    {
        string path = AssetDatabase.GetAssetPath(selectedObject);
        bundleNameList[index] = path.Remove(0, path.LastIndexOf("/") + 1).ToLower() + LuaFramework.AppConst.ExtName;

        string[] files = Directory.GetFiles(path);
        string[] temp = files[0].Split('.');
        suffixList[index] = StringToEnum("*." + temp[1]);

        pathList[index] = path;
    }

    public static string EnumToString(SuffixEnum se)
    {
        switch (se)
        {
            case SuffixEnum.Prefab:
                return "*.prefab";
            case SuffixEnum.Png:
                return "*.png";
            case SuffixEnum.Csv:
                return "*.csv";
            case SuffixEnum.Txt:
                return "*.txt";
            default:
                return "null";
        }
    }

    public static SuffixEnum StringToEnum(string s)
    {
        switch (s)
        {
            case "*.prefab":
                return SuffixEnum.Prefab;
            case "*.png":
                return SuffixEnum.Png;
            case "*.csv":
                return SuffixEnum.Csv;
            case "*.txt":
                return SuffixEnum.Txt;
            default:
                return SuffixEnum.Prefab;
        }
    }

}