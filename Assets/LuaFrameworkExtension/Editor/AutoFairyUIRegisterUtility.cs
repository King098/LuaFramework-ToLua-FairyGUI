using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class AutoFairyUIRegisterUtility : EditorWindow
{
    bool isTwoAB = true;
    List<string> packageList = new List<string>();
    List<string> nameList = new List<string>();
    int capacity = 0;
    string capacityText = "0";

    string defineLuaPath;

    string targetPanelLuaPath;

    //下面两个路径要根据自身情况修改
    string panelLuaPath = @"F:\LuaFramework_UGUI-master\Assets\LuaFrameworkExtension\UIFramework\Lua\88-ToLua# Panel Script-Panel.lua.txt";

    string resourceBuildPath;

    void OnEnable()
    {
        defineLuaPath = Application.dataPath + "/LuaFramework/Lua/Common/define.Lua";

        targetPanelLuaPath = Application.dataPath + "/LuaFramework/Lua/Fairy/";

        //下面两个路径要根据自身情况修改
        panelLuaPath = Application.dataPath + "/LuaFrameworkExtension/UIFramework/Lua/XUI View Script-View.lua.txt";

        resourceBuildPath = Application.dataPath + "/LuaFramework/Examples/Builds/FairyGUI/";
    }

    [MenuItem("LuaFramework/FairyUIAutoRegister")]
    static void SetAssetBundleNameExtension()
    {
        EditorWindow.GetWindow<AutoFairyUIRegisterUtility>();
    }
    string content = "";
    void OnGUI()
    {
        isTwoAB = EditorGUILayout.Toggle(new GUIContent("UI资源是否分成两份AB包"), isTwoAB);
        content = File.ReadAllText(defineLuaPath);
        if (isTwoAB)
        {
            content = content.Replace("FairyAssetBundleBool = false", "FairyAssetBundleBool = true");
            File.WriteAllText(defineLuaPath, content);
        }
        else
        {
            content = content.Replace("FairyAssetBundleBool = true", "FairyAssetBundleBool = false");
            File.WriteAllText(defineLuaPath, content);
        }

        EditorGUILayout.BeginHorizontal();

        capacityText = EditorGUILayout.TextField("View数量", capacityText);
        if (GUILayout.Button("确定"))
        {
            if (!int.TryParse(capacityText, out capacity)) return;

            if (nameList.Count == 0) for (int i = 0; i < capacity; i++) { packageList.Add(""); nameList.Add(""); }
            else if (nameList.Count < capacity) for (int i = nameList.Count; i < capacity; i++) { packageList.Add(""); nameList.Add(""); }
            else if (nameList.Count > capacity) for (int i = nameList.Count; i > capacity; i--) { packageList.RemoveAt(i - 1); nameList.RemoveAt(i - 1); }
        }

        EditorGUILayout.EndHorizontal();

        if (capacity > 0)
        {
            for (int i = 0; i < capacity; i++)
            {
                EditorGUILayout.BeginHorizontal();
                nameList[i] = EditorGUILayout.TextField(i + ".View名字:", nameList[i]);
                packageList[i] = EditorGUILayout.TextField("所在资源包:", packageList[i]);
                EditorGUILayout.EndHorizontal();
            }
        }


        EditorGUILayout.LabelField("------------------------------------------------------------------");
        EditorGUILayout.LabelField("下面的设置将修改：");
        EditorGUILayout.LabelField("1.define.lua" + " 路径为: " + defineLuaPath);
        if (GUILayout.Button("修改define.lua"))
        {
            //修改define.lua
            // string content = File.ReadAllText(defineLuaPath);//Debug.Log(content);
            for (int i = 0; i < capacity; i++)
            {
                int b = content.IndexOf('}', content.IndexOf("FairyUIs"));
                if (!content.Contains("\"" + nameList[i] + "\""))
                {
                    content = content.Insert(b, "\t" + "\"" + nameList[i] + "\",\r\n");
                }
                else
                {
                    Debug.Log("UI已经存在" + nameList[i]);
                }

                int c = content.IndexOf('}', content.IndexOf("AssetBundles"));
                if (isTwoAB)
                {
                    if (!content.Contains("\"" + packageList[i].ToLower() + "_des\""))
                    {
                        content = content.Insert(c, "\t" + "\"" + packageList[i].ToLower() + "_des\",\r\n");
                    }
                    if (!content.Contains("\"" + packageList[i].ToLower() + "_res\""))
                    {
                        content = content.Insert(c, "\t" + "\"" + packageList[i].ToLower() + "_res\",\r\n");
                    }
                }
                else
                {
                    if (!content.Contains("\"" + packageList[i].ToLower() + "\""))
                    {
                        content = content.Insert(c, "\t" + "\"" + packageList[i].ToLower() + "\",\r\n");
                    }
                }
            }
            File.WriteAllText(defineLuaPath, content);

            Debug.Log("修改完毕！");
        }

        //EditorGUILayout.BeginHorizontal();
        //startupPanel = EditorGUILayout.TextField("将Panel名字为：", startupPanel);
        //if (GUILayout.Button("设置为启动Panel(修改Game.lua)"))
        //{
        //    //修改Game.lua
        //    string content3 = File.ReadAllText(gameLuaPath);
        //    int a = content3.IndexOf("Game");
        //    content3 = content3.Insert(a, "require \"Controller/" + startupPanel + "Ctrl\"\r\n");
        //    int b = content3.IndexOf("local ctrl = CtrlManager.GetCtrl(CtrlNames.") + "local ctrl = CtrlManager.GetCtrl(CtrlNames.".Length;
        //    int c = content3.IndexOf(')', b);

        //    content3 = content3.Remove(b, c - b);
        //    content3 = content3.Insert(b, startupPanel);
        //    File.WriteAllText(gameLuaPath, content3);

        //    Debug.Log(startupPanel);   
        //}

        //if (GUILayout.Button("设置为启动Panel(修改define.lua)"))
        //{
        //    //修改define.lua
        //    string content3 = File.ReadAllText(defineLuaPath);
        //    int a = content3.IndexOf("StartUIName");
        //    int b = content3.IndexOf("=", a);
        //    int c = content3.IndexOf(";", b);
        //    content3 = content3.Remove(b, c - b);
        //    content3 = content3.Insert(b, "= \"" + startupPanel + "Ctrl\"");
        //    File.WriteAllText(defineLuaPath, content3);

        //    Debug.Log(startupPanel);
        //}
        //EditorGUILayout.EndHorizontal();


        EditorGUILayout.LabelField("------------------------------------------------------------------");
        EditorGUILayout.LabelField("lua模板的位置(如不同请修改)：");
        EditorGUILayout.LabelField("XXX.lua" + " 路径为: " + panelLuaPath);
        if (GUILayout.Button("生成lua文件"))
        {
            for (int i = 0; i < capacity; i++)
            {
                string a = targetPanelLuaPath + nameList[i] + ".lua";

                if (File.Exists(a)) File.Delete(a);

                FileUtil.CopyFileOrDirectory(panelLuaPath, a);

                string contentA = File.ReadAllText(a);
                contentA = contentA.Replace("#SCRIPTNAME#", nameList[i]);
                File.WriteAllText(a, contentA);
            }
            AssetDatabase.Refresh();
        }

        if (GUILayout.Button("创建View资源文件夹"))
        {
            for (int i = 0; i < capacity; i++)
            {
                if(isTwoAB)
                {
                    Directory.CreateDirectory(resourceBuildPath + "DES/" + nameList[i]);
                    Directory.CreateDirectory(resourceBuildPath + "RES/" + nameList[i]);
                }
                else
                {
                    Directory.CreateDirectory(resourceBuildPath + nameList[i]);
                }
            }
            AssetDatabase.Refresh();
        }
    }

}
