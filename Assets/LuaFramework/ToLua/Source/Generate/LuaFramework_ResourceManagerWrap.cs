﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaFramework_ResourceManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaFramework.ResourceManager), typeof(Manager));
		L.RegFunction("Initialize", Initialize);
		L.RegFunction("LoadPrefab", LoadPrefab);
		L.RegFunction("LoadAssetBundle", LoadAssetBundle);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.ResourceManager obj = (LuaFramework.ResourceManager)ToLua.CheckObject<LuaFramework.ResourceManager>(L, 1);
			obj.Initialize();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadPrefab(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			LuaFramework.ResourceManager obj = (LuaFramework.ResourceManager)ToLua.CheckObject<LuaFramework.ResourceManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string[] arg1 = ToLua.CheckStringArray(L, 3);
			LuaFunction arg2 = ToLua.CheckLuaFunction(L, 4);
			obj.LoadPrefab(arg0, arg1, arg2);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetBundle(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				LuaFramework.ResourceManager obj = (LuaFramework.ResourceManager)ToLua.CheckObject<LuaFramework.ResourceManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				UnityEngine.AssetBundle o = obj.LoadAssetBundle(arg0);
				ToLua.PushSealed(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<System.Action<UnityEngine.Object[]>>(L, 3))
			{
				LuaFramework.ResourceManager obj = (LuaFramework.ResourceManager)ToLua.CheckObject<LuaFramework.ResourceManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Action<UnityEngine.Object[]> arg1 = (System.Action<UnityEngine.Object[]>)ToLua.ToObject(L, 3);
				obj.LoadAssetBundle(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<LuaInterface.LuaFunction>(L, 3))
			{
				LuaFramework.ResourceManager obj = (LuaFramework.ResourceManager)ToLua.CheckObject<LuaFramework.ResourceManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				LuaFunction arg1 = ToLua.ToLuaFunction(L, 3);
				obj.LoadAssetBundle(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.ResourceManager.LoadAssetBundle");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

