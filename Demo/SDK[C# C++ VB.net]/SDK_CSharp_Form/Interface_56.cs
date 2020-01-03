using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDK_CSharp_Form
{
    //BX-5、BX-6共同使用接口
    public class Interface_56
    {
        //调整亮度
        public static void Net_Bright(byte[] ipAdder, byte num)
        {
            bx_sdk_dual.Brightness brightness;
            brightness.BrightnessMode = 0;
            brightness.HalfHourValue0 = num;
            brightness.HalfHourValue1 = num;
            brightness.HalfHourValue2 = num;
            brightness.HalfHourValue3 = num;
            brightness.HalfHourValue4 = num;
            brightness.HalfHourValue5 = num;
            brightness.HalfHourValue6 = num;
            brightness.HalfHourValue7 = num;
            brightness.HalfHourValue8 = num;
            brightness.HalfHourValue9 = num;
            brightness.HalfHourValue10 = num;
            brightness.HalfHourValue11 = num;
            brightness.HalfHourValue12 = num;
            brightness.HalfHourValue13 = num;
            brightness.HalfHourValue14 = num;
            brightness.HalfHourValue15 = num;
            brightness.HalfHourValue16 = num;
            brightness.HalfHourValue17 = num;
            brightness.HalfHourValue18 = num;
            brightness.HalfHourValue19 = num;
            brightness.HalfHourValue20 = num;
            brightness.HalfHourValue21 = num;
            brightness.HalfHourValue22 = num;
            brightness.HalfHourValue23 = num;
            brightness.HalfHourValue24 = num;
            brightness.HalfHourValue25 = num;
            brightness.HalfHourValue26 = num;
            brightness.HalfHourValue27 = num;
            brightness.HalfHourValue28 = num;
            brightness.HalfHourValue29 = num;
            brightness.HalfHourValue30 = num;
            brightness.HalfHourValue31 = num;
            brightness.HalfHourValue32 = num;
            brightness.HalfHourValue33 = num;
            brightness.HalfHourValue34 = num;
            brightness.HalfHourValue35 = num;
            brightness.HalfHourValue36 = num;
            brightness.HalfHourValue37 = num;
            brightness.HalfHourValue38 = num;
            brightness.HalfHourValue39 = num;
            brightness.HalfHourValue40 = num;
            brightness.HalfHourValue41 = num;
            brightness.HalfHourValue42 = num;
            brightness.HalfHourValue43 = num;
            brightness.HalfHourValue44 = num;
            brightness.HalfHourValue45 = num;
            brightness.HalfHourValue46 = num;
            brightness.HalfHourValue47 = num;

            int err = bx_sdk_dual.bxDual_cmd_setBrightness(ipAdder, 5005, ref brightness);
            Console.WriteLine("cmd_setBrightness:" + err);
        }
        //删除节目
        public static int Net_DelProgram(byte[] ipAdder, ushort port)
        {
            //获取节目列表
            bx_sdk_dual.GetDirBlock_G56 driBlock = new bx_sdk_dual.GetDirBlock_G56(); ;
            int err = bx_sdk_dual.bxDual_cmd_ofsReedDirBlock(ipAdder, port, ref driBlock);
            //获取节目详细信息
            for (int i = 0; i < driBlock.fileNumber; i++)
            {
                bx_sdk_dual.FileAttribute_G56 fileAttr = new bx_sdk_dual.FileAttribute_G56();
                err = bx_sdk_dual.bxDual_cmd_getFileAttr(ref driBlock, (ushort)i, ref fileAttr);
                //删除指定节目
                err = bx_sdk_dual.bxDual_cmd_ofsDeleteFormatFile(ipAdder, port, 1, fileAttr.fileName);
            }
            return err;
        }
        public static int Com_DelProgram(byte[] com, byte bart)
        {
            //获取节目列表
            bx_sdk_dual.GetDirBlock_G56 driBlock = new bx_sdk_dual.GetDirBlock_G56();
            int err = bx_sdk_dual.bxDual_cmd_uart_ofsReedDirBlock(com, bart, ref driBlock);
            //获取节目详细信息
            for (int i = 0; i < driBlock.fileNumber; i++)
            {
                bx_sdk_dual.FileAttribute_G56 fileAttr = new bx_sdk_dual.FileAttribute_G56();
                err = bx_sdk_dual.bxDual_cmd_getFileAttr(ref driBlock, (ushort)i, ref fileAttr);
                //删除指定节目
                err = bx_sdk_dual.bxDual_cmd_uart_ofsDeleteFormatFile(com, bart, 1, fileAttr.fileName);
            }
            return err;
        }
    }
}
