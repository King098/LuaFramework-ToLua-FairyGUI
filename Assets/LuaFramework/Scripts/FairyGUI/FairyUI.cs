using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaFramework;
using FairyGUI;

public enum FairyUIType
{
    None,
    Normal,
    PopUp,
    Fixed,
    Toppest,
    Waiting,
}

public enum FairyUIMode
{
    DoNothing,
    HideOtherOnly,//隐藏其他所有窗口
    HideOtherAndNeedBack,//隐藏其他所有窗口并加入窗口返回上一级功能
}

public enum FairyUIState
{
    NONE,
    OPEN, //打开
    HIDE, //隐藏
    CLOSE,//销毁
}

public class FairyUI
{
    //UI所在的包名
    private string m_fairyPackage;
    public string fairyPackage
    {
        get { return m_fairyPackage; }
    }
    //UI名字
    private string m_fairyUIName;
    public string fairyUIName
    {
        get { return m_fairyUIName; }
    }
	//UI资源URL
	private string m_fairyURL;
	public string fairyURL
	{
		get{return m_fairyURL;}
		set{m_fairyURL = value;}
	}
    //UI层级
    private FairyUIType m_fairyUIType;
    public FairyUIType fairyUIType
    {
        get { return m_fairyUIType; }
        set { m_fairyUIType = value; }
    }
    //UI模式
    private FairyUIMode m_fairyUIMode;
    public FairyUIMode fairyUIMode
    {
        get { return m_fairyUIMode; }
        set { m_fairyUIMode = value; }
    }
    //UI当前状态
    private FairyUIState m_fairyUIState;
    public FairyUIState fairyUIState
    {
        get { return m_fairyUIState; }
    }
    //存储UI的对象池
    private GObjectPool m_pool;
    public GObjectPool pool
    {
        get { return m_pool; }		
    }
    //这个UI是否需要对象池
    private bool m_needPool;
    public bool needPool
    {
        get { return m_needPool; }
        set
        {
            m_needPool = value;
            //初始化对象池
            m_pool = new GObjectPool(FairyRoot.Instance.normalRoot.displayObject.cachedTransform);
			//设置每次创建新对象的时候的回调
			m_pool.initCallback = OnPoolCallBack;
        }
    }
    //不需要对象的UI对象
    private GComponent m_inst;
    public GComponent inst
    {
        get { return m_inst; }
        set { m_inst = value; }
    }

    //用于存储需要这个UI管理器下所有的UI的打开顺序情况
    private Stack<GComponent> m_stack = new Stack<GComponent>();
	public Stack<GComponent> stack
	{
		get{
			return m_stack;
		}
	}

    //初始化UI
    public void InitUI(string package, string name)
    {
        this.m_fairyPackage = package;
        this.m_fairyUIName = name;
    }

    //添加一个对象
    public void AddGObject(GComponent com)
    {
        if (FairyRoot.Instance != null)
        {
            FairyRoot.Instance.SetRoot(com, fairyUIType);
        }
        if (needPool)
        {
			fairyURL = com.resourceURL;
			com.visible = false;
            pool.ReturnObject(com);
        }
        else
        {
			fairyURL = com.resourceURL;
			inst = com;
            inst.visible = false;
        }
    }
	
	void OnPoolCallBack(GObject obj)
	{
		GComponent com = obj.asCom;
		com.visible = false;
		//设置层级
		if (FairyRoot.Instance != null)
        {
            FairyRoot.Instance.SetRoot(com, fairyUIType);
        }
	}

    public void Awake()
    {
        Util.CallMethod(m_fairyUIName, "Awake", this);
    }

    public void Start()
    {
        Util.CallMethod(m_fairyUIName, "Start");
    }

    public void Show()
    {
        if (!needPool)
        {
            m_fairyUIState = FairyUIState.OPEN;
        }
        else
        {
            m_fairyUIState = FairyUIState.NONE;
        }
        Util.CallMethod(m_fairyUIName, "Show");
    }

    public void Hide()
    {
        if (!needPool)
        {
            m_fairyUIState = FairyUIState.HIDE;
            Util.CallMethod(m_fairyUIName, "Hide", inst);
        }
        else
        {
            m_fairyUIState = FairyUIState.NONE;
            Util.CallMethod(m_fairyUIName, "Hide", stack.Peek());
        }
    }

    public void HideAll()
    {
        m_fairyUIState = FairyUIState.HIDE;
        Util.CallMethod(m_fairyUIName, "HideAll");
    }

    public void Destroy()
    {
        m_fairyUIState = FairyUIState.CLOSE;
        Util.CallMethod(m_fairyUIName, "Destroy");
    }

    //栈中是否还有其他UI
    public bool HasGInStack()
    {
        if (stack.Count > 0)
        {
            return true;
        }
        return false;
    }
}
