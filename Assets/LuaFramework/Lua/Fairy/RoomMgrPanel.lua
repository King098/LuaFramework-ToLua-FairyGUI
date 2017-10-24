RoomMgrPanel = {};
local this = RoomMgrPanel;

function RoomMgrPanel.Awake(com)
	this.component = com;
	--设置UI层级 Normal--Fixed--PopUp--Toppest
	this.component.fairyUIType = FairyUIType.Normal;
	--设置UI模式 DoNothing--HideOtherOnly--HideOtherAndNeedBack
	this.component.fairyUIMode = FairyUIMode.DoNothing;
	--设置UI是否需要对象池
	this.component.needPool = false;
	
	logWarn("FairyGUI Lua => RoomMgrPanel Awake");
end

function RoomMgrPanel.GetInitComponent(com)
	--在此进行UI设置和获取组建
	this.PlayerIco = com:GetChild("PlayerInfo");
	--移除事件绑定
	this.RemoveAllEvent();
	--在此进行事件注册和初始化界面
	this.PlayerIco.onClick:Add(this.OnClick);
	
	logWarn("FairyGUI Lua => RoomMgrPanel Register Event");
end

function RoomMgrPanel.RemoveAllEvent()
	--移除事件绑定
	this.PlayerIco.onClick:Remove(this.OnClick);
end

function RoomMgrPanel.Start()
	--获取并初始化组件
	if not this.component.needPool then
		this.GetInitComponent(this.component.inst);
	end
	logWarn("FairyGUI Lua => RoomMgrPanel Start");
	--显示界面
	this.Show();
end

function RoomMgrPanel.Show()
	--显示一个UI
	if this.component.needPool then
		--使用对象池
		local com = this.component.pool:GetObject(this.component.fairyURL);
		--如果使用对象池，则在获取的时候取消一次事件，并重新绑定事件
		this.GetInitComponent(com);
		--入栈
		this.component.stack:Push(com);
		com.visible = true;
	else
		--不使用对象池
		this.component.inst.visible = true;
	end
	logWarn("FairyGUI Lua => RoomMgrPanel Show");
end

function RoomMgrPanel.Hide(com)
	--关闭一个UI
	if this.component.needPool then
		this.component.pool:ReturnObject(com);
		--取消所有事件绑定
		this.RemoveAllEvent();
		--出栈
        if this.component.stack:Peek() == com then
			this.component.stack:Pop();
		end
		com.visible = false;
	else
		--不使用对象池
		this.component.inst.visible = false;
	end
	logWarn("FairyGUI Lua => RoomMgrPanel Hide" .. com.name);
end

function RoomMgrPanel.HideAll()
	--关闭所有UI
	if this.component.needPool then
		for i = this.component.stack.Count - 1, 0, - 1 do
			this.component:Hide();
		end
		this.component.stack:Clear();
	else
		this.component.stack:Hide();
	end
	logWarn("FairyGUI Lua => RoomMgrPanel HideAll");
end

function RoomMgrPanel.Destroy()
	logWarn("FairyGUI Lua => RoomMgrPanel Destroy");
end

--设置各种事件
function RoomMgrPanel.OnClick(context)
	local obj = context.sender;
	if obj.name == "PlayerInfo" then
		log('you click '..obj.name);
        uiMgr:HideCurrPage();
	end
end 