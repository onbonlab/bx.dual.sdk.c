（一）目录说明
lib32_MT目录下是所有依赖库；
（二）文件说明
1）bx_dual_sdk.h 所有接口函数及枚举类型的声明；
2）bx_sdk_dual.h 接口函数的别名；
3）Obasic_types.h 基础类型的声明；
4）bx_sdk_dual.dll bx_sdk_dual.lib 为动态库；c++程序调用bx_sdk_dual.dll时需将bx_sdk_dual.lib引入；
5）关于LedSdkDemo.exe程序
LedSdkDemo.exe程序运行后，直接与4张6代的控制卡通讯，
4张卡的IP分别为：
192.168.0.181
192.168.0.182
192.168.0.183
//192.168.0.184
192.168.0.185
4张的显示区域为80*32；
所以，如果要用此程序进行测试，需确认或配置下PC机的IP也配置为192.168.0.*网段；

