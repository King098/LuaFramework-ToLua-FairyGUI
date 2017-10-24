using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class Test : MonoBehaviour {
	public bool flag;
	// Use this for initialization
	void Start () {
		UIPackage.AddPackage("TestUI");
		GComponent com = UIPackage.CreateObject("TestUI","RoomMgrPanel").asCom;
		GRoot.inst.AddChild(com);

		GObject com1 = com.GetChild("PlayerInfo");
		if(com1 == null)
		{
			Debug.LogError("没有找到子物体");
			return;
		}
		com1.onClick.Add(OnClick);
		Debug.Log(UIPackage.GetPackages().Count);
	}
	
	void OnClick(EventContext context)
	{
		Debug.Log("Click" + ((GComponent)context.sender).name);
	}

	// Update is called once per frame
	void Update () {
		if(flag)
		{
			flag = false;
			Start();
		}
	}
}
