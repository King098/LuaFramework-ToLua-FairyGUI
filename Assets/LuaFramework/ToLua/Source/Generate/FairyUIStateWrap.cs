﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FairyUIStateWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(FairyUIState));
		L.RegVar("NONE", get_NONE, null);
		L.RegVar("OPEN", get_OPEN, null);
		L.RegVar("HIDE", get_HIDE, null);
		L.RegVar("CLOSE", get_CLOSE, null);
		L.RegFunction("IntToEnum", IntToEnum);
		L.EndEnum();
		TypeTraits<FairyUIState>.Check = CheckType;
		StackTraits<FairyUIState>.Push = Push;
	}

	static void Push(IntPtr L, FairyUIState arg)
	{
		ToLua.Push(L, arg);
	}

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(typeof(FairyUIState), L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NONE(IntPtr L)
	{
		ToLua.Push(L, FairyUIState.NONE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OPEN(IntPtr L)
	{
		ToLua.Push(L, FairyUIState.OPEN);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HIDE(IntPtr L)
	{
		ToLua.Push(L, FairyUIState.HIDE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CLOSE(IntPtr L)
	{
		ToLua.Push(L, FairyUIState.CLOSE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		FairyUIState o = (FairyUIState)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}

