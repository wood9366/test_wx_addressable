# 测试微信小游戏使用Addressable真机加载

开发系统环境：macOS Sonoma Version 14.0
Unity版本：2021.2.5f1c303
微信小游戏转化插件版本：202312181916
DevTools版本：Stable 1.06.2310080
CDN：使用微信云托管的对象存储
测试手机：iphone SE2
手机微信版本：8.0.44

问题：
DevTool中使用真机预览，使用Addressable加载资源报错

RemoteProviderException: TextDataProvider: unable to load from url: https://{CDN_PATH}/StreamingAssets/aa/settings.json

在DevTool中直接测试时没有问题
