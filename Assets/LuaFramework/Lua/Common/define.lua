
CtrlNames = {
	Prompt = "PromptCtrl",
	Message = "MessageCtrl"
}

PanelNames = {
	"PromptPanel",	
	"MessagePanel",
}

--协议类型--
ProtocalType = {
	BINARY = 0,
	PB_LUA = 1,
	PBC = 2,
	SPROTO = 3,
}

--使用FairyGUI的UI框架时存储UI信息的
FairyUIs = 
{
	"RoomMgrPanel",
}

--是否使用了单份资源(false使用单份UI资源，true使用双份UI资源)
FairyAssetBundleBool = true;
--当前加载到的资源下标
FairyAssetBundleIndex = 0;
--需要加载的AssetBundle包名(需要注意顺序)(UI使用双份资源时需要资源使用_des和_res后缀区分,使用单份资源时不需要后缀)
AssetBundles = 
{
	"testui_des",
	"testui_res",
}

--当前使用的协议类型--
TestProtoType = ProtocalType.BINARY;

Util = LuaFramework.Util;
AppConst = LuaFramework.AppConst;
LuaHelper = LuaFramework.LuaHelper;
ByteBuffer = LuaFramework.ByteBuffer;
resMgr = LuaHelper.GetResManager();
panelMgr = LuaHelper.GetPanelManager();
soundMgr = LuaHelper.GetSoundManager();
networkMgr = LuaHelper.GetNetManager();
uiMgr = LuaHelper.GetFairyGUIManager();

WWW = UnityEngine.WWW;
GameObject = UnityEngine.GameObject;