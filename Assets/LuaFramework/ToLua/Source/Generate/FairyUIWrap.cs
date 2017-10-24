﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FairyUIWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FairyUI), typeof(System.Object));
		L.RegFunction("InitUI", InitUI);
		L.RegFunction("AddGObject", AddGObject);
		L.RegFunction("Awake", Awake);
		L.RegFunction("Start", Start);
		L.RegFunction("Show", Show);
		L.RegFunction("Hide", Hide);
		L.RegFunction("HideAll", HideAll);
		L.RegFunction("Destroy", Destroy);
		L.RegFunction("HasGInStack", HasGInStack);
		L.RegFunction("New", _CreateFairyUI);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("fairyPackage", get_fairyPackage, null);
		L.RegVar("fairyUIName", get_fairyUIName, null);
		L.RegVar("fairyURL", get_fairyURL, set_fairyURL);
		L.RegVar("fairyUIType", get_fairyUIType, set_fairyUIType);
		L.RegVar("fairyUIMode", get_fairyUIMode, set_fairyUIMode);
		L.RegVar("fairyUIState", get_fairyUIState, null);
		L.RegVar("pool", get_pool, null);
		L.RegVar("needPool", get_needPool, set_needPool);
		L.RegVar("inst", get_inst, set_inst);
		L.RegVar("stack", get_stack, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateFairyUI(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				FairyUI obj = new FairyUI();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: FairyUI.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitUI(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.InitUI(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddGObject(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			FairyGUI.GComponent arg0 = (FairyGUI.GComponent)ToLua.CheckObject<FairyGUI.GComponent>(L, 2);
			obj.AddGObject(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Awake(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			obj.Awake();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			obj.Start();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Show(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			obj.Show();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Hide(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			obj.Hide();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HideAll(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			obj.HideAll();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Destroy(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			obj.Destroy();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasGInStack(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyUI obj = (FairyUI)ToLua.CheckObject<FairyUI>(L, 1);
			bool o = obj.HasGInStack();
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fairyPackage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			string ret = obj.fairyPackage;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyPackage on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fairyUIName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			string ret = obj.fairyUIName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyUIName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fairyURL(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			string ret = obj.fairyURL;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyURL on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fairyUIType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyUIType ret = obj.fairyUIType;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyUIType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fairyUIMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyUIMode ret = obj.fairyUIMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyUIMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fairyUIState(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyUIState ret = obj.fairyUIState;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyUIState on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pool(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyGUI.GObjectPool ret = obj.pool;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index pool on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_needPool(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			bool ret = obj.needPool;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index needPool on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inst(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyGUI.GComponent ret = obj.inst;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index inst on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stack(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			System.Collections.Generic.Stack<FairyGUI.GComponent> ret = obj.stack;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index stack on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fairyURL(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.fairyURL = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyURL on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fairyUIType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyUIType arg0 = (FairyUIType)ToLua.CheckObject(L, 2, typeof(FairyUIType));
			obj.fairyUIType = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyUIType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fairyUIMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyUIMode arg0 = (FairyUIMode)ToLua.CheckObject(L, 2, typeof(FairyUIMode));
			obj.fairyUIMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fairyUIMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_needPool(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.needPool = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index needPool on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_inst(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyUI obj = (FairyUI)o;
			FairyGUI.GComponent arg0 = (FairyGUI.GComponent)ToLua.CheckObject<FairyGUI.GComponent>(L, 2);
			obj.inst = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index inst on a nil value");
		}
	}
}

