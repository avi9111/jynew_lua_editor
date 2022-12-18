using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class Hunter6MenuTools
{
    [MenuItem("项目快速导航/跳转到开头脚本",priority = 101)]
    public static void PingToStartScript()
    {
        TextAsset go = null;
        //var path = AssetDatabase.GUIDToAssetPath("c56dd131bee09a44da4a8acfcf26402d");//ka591.lua
        var path = AssetDatabase.GUIDToAssetPath("625f8622abae4254cae286b28b996b17");//ka691.lua
        go = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
        //EditorWindow.GetWindow<Project>().
        EditorGUIUtility.PingObject(go);
    }
}
