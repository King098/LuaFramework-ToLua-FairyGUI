﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FairyUIModeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(FairyUIMode));
		L.RegVar("DoNothing", get_DoNothing, null);
		L.RegVar("HideOtherOnly", get_HideOtherOnly, null);
		L.RegVar("HideOtherAndNeedBack", get_HideOtherAndNeedBack, null);
		L.RegFunction("IntToEnum", IntToEnum);
		L.EndEnum();
		TypeTraits<FairyUIMode>.Check = CheckType;
		StackTraits<FairyUIMode>.Push = Push;
	}

	static void Push(IntPtr L, FairyUIMode arg)
	{
		ToLua.Push(L, arg);
	}

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(typeof(FairyUIMode), L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DoNothing(IntPtr L)
	{
		ToLua.Push(L, FairyUIMode.DoNothing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HideOtherOnly(IntPtr L)
	{
		ToLua.Push(L, FairyUIMode.HideOtherOnly);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HideOtherAndNeedBack(IntPtr L)
	{
		ToLua.Push(L, FairyUIMode.HideOtherAndNeedBack);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		FairyUIMode o = (FairyUIMode)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}

