using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class FairyUIManager
{
    private static FairyUIManager m_self = null;
    public static FairyUIManager Instance
    {
        get
        {
            if (m_self == null)
            {
                m_self = new FairyUIManager();
            }
            return m_self;
        }
    }

    //用于存储所有的UI控制器
    public Dictionary<string, FairyUI> allPages = new Dictionary<string, FairyUI>();
    //用于存储需要返回上一级的UI
    public Stack<FairyUI> stackPages = new Stack<FairyUI>();
    //当前显示的UI
    private FairyUI currShowUI;

    /// <summary>
    /// 获取所有单例面板
    /// </summary>
    /// <returns></returns>
    private List<FairyUI> GetAllUIs()
    {
        return new List<FairyUI>(allPages.Values);
    }

    /// <summary>
    /// 检查面板打开类型
    /// </summary>
    /// <param name="currXPage"></param>
    public void CheckUIMode(FairyUI currXPage)
    {
        if (currXPage.fairyUIMode == FairyUIMode.DoNothing)
        {

        }
        else if (currXPage.fairyUIMode == FairyUIMode.HideOtherOnly)
        {
            HideOtherPages(currXPage);
        }
        else if (currXPage.fairyUIMode == FairyUIMode.HideOtherAndNeedBack)
        {
            HideOtherPages(currXPage);
            stackPages.Push(currXPage);
        }
    }

    //之关闭fixed和popup层
    private void HideOtherPages(FairyUI currXPage)
    {
        List<FairyUI> xpages = GetAllUIs();
        int count = xpages.Count;
        for (int i = 0; i < count; i++)
        {
            FairyUI curr = xpages[i];
            if (curr.Equals(currXPage))
                continue;
            if (curr.fairyUIState == FairyUIState.OPEN && (curr.fairyUIType != FairyUIType.Fixed || curr.fairyUIType != FairyUIType.PopUp))
            {
                curr.HideAll();
            }
        }
    }

    /// <summary>
    /// 检测面板是否在队列里
    /// </summary>
    /// <param name="pageName"></param>
    /// <returns></returns>
    private FairyUI CheckPageExist(string pageName)
    {
        if (allPages.ContainsKey(pageName))
        {
            return allPages[pageName];
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// 打开面板
    /// </summary>
    /// <param name="pageLoadPath">加载的相对路径</param>
    public void ShowPage(string pkg, string pageName)
    {
        FairyUI currXPage = CheckPageExist(pageName);
        if (currXPage != null)
        {
            if (currXPage.fairyUIState == FairyUIState.CLOSE || currXPage.needPool)
            {
                CheckUIMode(currXPage);
                currXPage.Show();
                currShowUI = currXPage;
                Debug.Log("直接打开");
            }
        }
        else
        {
            currXPage = new FairyUI();
            currXPage.InitUI(pkg, pageName);
            currXPage.Awake();

            LoadUI(pkg, pageName,delegate (GObject obj)
             {
                 currXPage.AddGObject(obj.asCom);
                 allPages.Add(pageName, currXPage);
                 CheckUIMode(currXPage);
                 currXPage.Start();
                 currShowUI = currXPage;
             });
        }
    }
	public void LoadUI(string pkg, string pageName,  LuaInterface.LuaFunction gfunc = null)
    {
#if ASYNC_MODE
        UIPackage.CreateObjectAsync(pkg, pageName, delegate (GObject obj)
          {
              Debug.Log("异步加载打开");
              if (gfunc != null)
              {
                  gfunc.Call<GObject>(obj);
                  gfunc.Dispose();
                  gfunc = null;
              }
          });
#else
			Debug.Log("同步加载打开");
			GObject obj = UIPackage.CreateObject(pkg,pageName);
			  if(gfunc != null)
			  {
				  gfunc.Call<GObject>(obj);
				  gfunc.Dispose();
				  gfunc = null;
			  }
#endif
    }

    public void LoadUI(string pkg, string pageName,System.Action<GObject> gobj = null)
    {
#if ASYNC_MODE
        UIPackage.CreateObjectAsync(pkg, pageName, delegate (GObject obj)
          {
              Debug.Log("异步加载打开");
              if (gobj != null)
              {
                  gobj(obj);
                  gobj = null;
              }
          });
#else
			Debug.Log("同步加载打开");
			GObject obj = UIPackage.CreateObject(pkg,pageName);
			if(gobj != null)
			  {
				  gobj(obj);
				  gobj = null;
			  }
#endif
    }

    /// <summary>
    /// 隐藏当前的页面
    /// </summary>
    public bool HideCurrPage()
    {
        if (currShowUI != null)
        {
            if (currShowUI.fairyUIMode == FairyUIMode.HideOtherAndNeedBack)
            {
                if (stackPages.Count > 0)
                {
                    if (stackPages.Peek().Equals(currShowUI))
                    {
                        FairyUI topPage = stackPages.Pop();
                        topPage.Hide();
                        currShowUI = null;
                        if (stackPages.Count > 0)
                        {
                            FairyUI _curr = stackPages.Peek();
                            _curr.Show();
                            currShowUI = _curr;
                        }
                    }
                }
            }
            else
            {
                if (currShowUI.fairyUIState == FairyUIState.OPEN && !currShowUI.needPool)
                {
                    currShowUI.Hide();
                    currShowUI = null;
                }
                else if (currShowUI.needPool)
                {
                    currShowUI.Hide();
                    if (!currShowUI.HasGInStack())
                    {
                        currShowUI = null;
                    }
                }
            }

            return true;
        }
        else
        {
            Debug.Log("currShowPage is null");
            return false;
        }
    }

    /// <summary>
    ///隐藏指定面板 
    /// </summary>
    /// <param name="pageName">Page name.</param>
    public void HidePage(string pageName)
    {
        FairyUI _currXpage = CheckPageExist(pageName);
        if (_currXpage != null)
        {
            if (_currXpage.fairyUIState == FairyUIState.OPEN)
                _currXpage.Hide();
        }
    }

    /// <summary>
    /// 销毁所有面板
    /// </summary>
    public void CloseAllPages()
    {
        List<FairyUI> all = GetAllUIs();
        int count = all.Count;
        for (int i = 0; i < count; i++)
        {
            all[i].Destroy();
            all[i] = null;
        }
        allPages.Clear();
        stackPages.Clear();
    }
}
