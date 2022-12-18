using System;
using System.Collections;
using System.Collections.Generic;
using Jyx2;
using Jyx2Configs;
using UnityEngine;
using UnityEditor;
public class Hunter6TestPlayerWindow : EditorWindow
{
    [MenuItem("项目快速导航/测试Player 瞬移",priority = 101)]
    public static void StartWindow()
    {
        GetWindow<Hunter6TestPlayerWindow>().Show();
    }

    private Vector2 pos;
    private bool isDirectEnter;
    private string m_MapName;
    private string m_MapContent;//因为是从选颜色的gui代码改的，所以还是这个名字有些怪，这里现在保存的是地图名字（字串，同m_MapName）
    private void Awake()
    {
        pos = new Vector2(EditorPrefs.GetFloat("PlayerZ", 0), EditorPrefs.GetFloat("PlayerX", 0));
        m_MapName = m_MapContent = EditorPrefs.GetString("G_MapName");
    }

    private void OnGUI()
    {
        if (!Application.isPlaying)
        {
            GUILayout.Label("<color=red>部分功能没展示，请先运行游戏，才可场景跳转</color>");
            return;
        }
        
        OnGUIByName();
        OnGUIByPosition();
        
        if (GUI.changed)
        {
            SavePlayerPrefs();
        }
       
    }
    

    void OnGUIByPosition()
    {
        GUILayout.Space(10);
        pos = EditorGUILayout.Vector2Field("罗盘位置",pos);


        isDirectEnter = EditorGUILayout.Toggle("直接进入场景",isDirectEnter);
        if (GUILayout.Button("测试瞬移"))
        {
            Jyx2LuaBridge.EveMove(pos.x,pos.y);
            if (isDirectEnter)
            {
                DelayInvoke.StartTimmer(1f,()=>
                {
                    MapTeleportor.Inst.DoTransport();
                });
            }
        }
    }

    void SavePlayerPrefs()
    {
        EditorPrefs.SetFloat("PlayerZ",pos.x);
        EditorPrefs.SetFloat("PlayerX",pos.y);
        EditorPrefs.SetString("G_MapName",m_MapName);
    }
    /// <summary>
    /// v1.2，改良了点，选择后，会更新DropDown 当前 Content Text
    /// </summary>
    void OnGUIByName()
    {
        if (EditorGUILayout.DropdownButton(new GUIContent(m_MapContent), FocusType.Passive))
        {
            GenericMenu menu = new GenericMenu();
 
            
   //////////////添加 menu item (带层次) 的示例代码 ///////////////////////
            // forward slashes nest menu items under submenus
            //AddMenuItemForColor(menu, "RGB/Red", Color.red);
            //AddMenuItemForColor(menu, "RGB/Green", Color.green);
            //AddMenuItemForColor(menu, "RGB/Blue", Color.blue);
            
            //menu.AddSeparator("");
 
            //AddMenuItemForColor(menu, "White", Color.white);
    ///////////////////////////////////////////////////////////////////////
            foreach(var map in GameConfigDatabase.Instance.GetAll<Jyx2ConfigMap>())
            {
                if (!string.IsNullOrEmpty(map.Tags))
                {
                    AddMenuItemForColor(menu, map.Tags + "/" + map.Name, map.Name);
                }
                else
                {
                    AddMenuItemForColor(menu, map.Name, map.Name);
                }
            }
            // display the menu
            menu.ShowAsContext();
        }

        //todo 现在场景在大地图才可跳转
        if (GUILayout.Button(("场景-直接跳转")))
        {
            if (string.IsNullOrEmpty(m_MapName)==false)
            {
                MapTeleportor.Inst.DoTransportByName(m_MapName);
            }
        }


    }
    void AddMenuItemForColor(GenericMenu menu, string menuPath, string nameName)
    {
        // the menu item is marked as selected if it matches the current value of m_Color
        menu.AddItem(new GUIContent(menuPath), m_MapName.Equals(nameName), OnColorSelected, nameName);
    }
    // the GenericMenu.MenuFunction2 event handler for when a menu item is selected
    void OnColorSelected(object mapName)
    {
        m_MapName = mapName.ToString();
        m_MapContent =mapName.ToString();
    }
}
