# LuaFramework-ToLua-FairyGUI

#引用项目

[LuaFramework_UGUI](https://github.com/jarjin/LuaFramework_UGUI)

[FairyGUI 5.0版本](https://github.com/fairygui/FairyGUI-unity)

#功能：

集成了DOTween插件

集成了创建UI的lua脚本的工具

合并两个项目，使用FairyGUI可以直接接入LuaFramework框架，在Unity中Scripting Define Symbols中使用如下预编译

1.ASYNC_MODE

  LuaFramework原来自带的用于开启异步加载资源的预编译，现在效果一样
  
2.FairyGUI

  这个是现在项目新增字段，用于开启FairyGUI的Lua功能，如果不开启，则默认使用LuaFramework原来的UGUI的Lua模块，FairyGUI的Lua模块提供使用一个UI一个AB包的方式接入，也提供一个UI连个AB包的方式接入，打包规则参照[FairyGUI官网](http://www.fairygui.com/guide/unity/index.html)



#Tips：

1.如果使用FairyGUI的Lua模块，则Lua框架入口为FairyGUIGame.lua脚本，如果使用UGUI的Lua模块入口为Game.lua脚本

2.FairyGUI开启时，Lua脚本存放在Lua下的Fairy文件夹下

3.如果开启了FairyGUI，AB包可放置在Builds->FairyGUI下（使用一个UI一个AB包则将资源放在此目录之下根据UI命名文件夹创建并放入，使用一个UI两个AB包则分别放在DES和RES文件夹）

4.此项目修改了LuaFramework的LuaLoader文件，现在可在Lua动态创建新的文件夹也不会找不到，同时可更新
