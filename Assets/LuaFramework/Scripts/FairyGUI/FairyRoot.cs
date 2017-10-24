using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using LuaInterface;
using LuaFramework;
using System;
using UObject = UnityEngine.Object;

public class FairyRoot : MonoBehaviour
{
    private static FairyRoot m_self = null;
    public static FairyRoot Instance
    {
        get
        {
            if (m_self == null)
            {
                InitRoot();
            }
            return m_self;
        }
    }
    public GComponent normalRoot;//Canvas order in layer 0
    public GComponent popupRoot;//250
    public GComponent fixedRoot;//500
    public GComponent ToppestRoot;//750
    public GComponent WaitingRoot;//900

    static void InitRoot()
    {
		GameObject go = new GameObject("FairyGUI");
		m_self = go.AddComponent<FairyRoot>();		
        //创建Normal
        m_self.normalRoot = new GComponent();
        GRoot.inst.AddChild(m_self.normalRoot);
        m_self.normalRoot.gameObjectName = "Normal";
        //创建Fixed
        m_self.fixedRoot = new GComponent();
        GRoot.inst.AddChild(m_self.fixedRoot);
        m_self.fixedRoot.gameObjectName = "Fixed";
        //创建popup
        m_self.popupRoot = new GComponent();
        GRoot.inst.AddChild(m_self.popupRoot);
        m_self.popupRoot.gameObjectName = "PopUp";
        //创建toppest
        m_self.ToppestRoot = new GComponent();
        GRoot.inst.AddChild(m_self.ToppestRoot);
        m_self.ToppestRoot.gameObjectName = "Toppest";
    }

    public void SetRoot(GComponent component, FairyUIType type)
    {
        switch (type)
        {
            case FairyUIType.Normal:
                m_self.normalRoot.AddChild(component);
                break;
            case FairyUIType.Fixed:
                m_self.fixedRoot.AddChild(component);
                break;
            case FairyUIType.PopUp:
                m_self.popupRoot.AddChild(component);
                break;
            case FairyUIType.Toppest:
                m_self.ToppestRoot.AddChild(component);
                break;
        }
    }
}
