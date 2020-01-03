using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SDK_CSharp_Form
{
    public class Calculation
    {
        public class sdk_err
        {
            public const int ERR_NO = 0; 
            public const int ERR_OUTOFGROUP = 1;  
            public const int ERR_NOCMD = 2; 
            public const int ERR_BUSY = 3; 
            public const int ERR_MEMORYVOLUME = 4;  
            public const int ERR_CHECKSUM = 5;  
            public const int ERR_FILENOTEXIST = 6; 
            public const int ERR_FLASH = 7;
            public const int ERR_FILE_DOWNLOAD = 8; 
            public const int ERR_FILE_NAME = 9;
            public const int ERR_FILE_TYPE = 10;
            public const int ERR_FILE_CRC16 = 11;
            public const int ERR_FONT_NOT_EXIST = 12;
            public const int ERR_FIRMWARE_TYPE = 13;
            public const int ERR_DATE_TIME_FORMAT = 14;
            public const int ERR_FILE_EXIST = 15;
            public const int ERR_FILE_BLOCK_NUM = 16;
            public const int ERR_CONTROLLER_TYPE = 17;
            public const int ERR_SCREEN_PARA = 18;
            public const int ERR_CONTROLLER_ID = 19;
            public const int ERR_USER_SECRET = 20;
            public const int ERR_OLD_USER_SECRET = 21;
            public const int ERR_PHY1_NO_SECRET = 22;
            public const int ERR_PHY1_USE_SECRET = 23;
            public const int ERR_RTC = 24;
            public const int ERR_CMD_PARA = 25;
            public const int ERR_CASCADE_COMM = 26;
            public const int ERR_NO_BATTLE_AREA = 27;
            public const int ERR_NO_TIMER_AREA = 28;
            public const int ERR_FPGA_COMM = 29;
            public const int ERR_SET_MODBUS_PARA = 60;

            public const int ERR_TCP = -1; 
        }
        public static string GetError(int err)
        {
            string str = "";
            switch (err)
            {
                case sdk_err.ERR_TCP:
                    str = "通讯错误";
                    break;
                case sdk_err.ERR_NO:
                    str = "没有错误";
                    break;
                case sdk_err.ERR_OUTOFGROUP:
                    str = "命令组错误";
                    break;
                case sdk_err.ERR_NOCMD:
                    str = "此命令不存在";
                    break;
                case sdk_err.ERR_BUSY:
                    str = "控制器忙";
                    break;
                case sdk_err.ERR_MEMORYVOLUME:
                    str = "存储器容量越界";
                    break;
                case sdk_err.ERR_CHECKSUM:
                    str = "数据包 CRC 校验错误";
                    break;
                case sdk_err.ERR_FILENOTEXIST:
                    str = "此文件不存在";
                    break;
                case sdk_err.ERR_FLASH:
                    str = "Flash 访问错误";
                    break;
                case sdk_err.ERR_FILE_DOWNLOAD:
                    str = "文件下载错误";
                    break;
                case sdk_err.ERR_FILE_NAME:
                    str = "文件名错误";
                    break;
                case sdk_err.ERR_FILE_TYPE:
                    str = "文件类型错误";
                    break;
                case sdk_err.ERR_FILE_CRC16:
                    str = "文件校验错误";
                    break;
                case sdk_err.ERR_FONT_NOT_EXIST:
                    str = "字库文件不存在";
                    break;
                case sdk_err.ERR_FIRMWARE_TYPE:
                    str = "Firmware 与控制器类型不匹配";
                    break;
                case sdk_err.ERR_DATE_TIME_FORMAT:
                    str = "日期时间格式错误 ";
                    break;
                case sdk_err.ERR_FILE_EXIST:
                    str = "此文件已存在";
                    break;
                case sdk_err.ERR_FILE_BLOCK_NUM:
                    str = "文件 Block 号错误";
                    break;
                case sdk_err.ERR_CONTROLLER_TYPE:
                    str = "控制器类型不匹配";
                    break;
                case sdk_err.ERR_SCREEN_PARA:
                    str = "控制器参数越界或错误";
                    break;
                case sdk_err.ERR_CONTROLLER_ID:
                    str = "控制器 ID 错误";
                    break;
                case sdk_err.ERR_USER_SECRET:
                    str = "用户密码错误";
                    break;
                case sdk_err.ERR_OLD_USER_SECRET:
                    str = "设置新密码时，输入的旧密码不正确";
                    break;
                case sdk_err.ERR_PHY1_NO_SECRET:
                    str = "底层无密码，上位机有密码";
                    break;
                case sdk_err.ERR_PHY1_USE_SECRET:
                    str = " 底层有密码，上位机无密码";
                    break;
                case sdk_err.ERR_RTC:
                    str = "时钟芯片故障";
                    break;
                case sdk_err.ERR_CMD_PARA:
                    str = "命令参数错误";
                    break;
                case sdk_err.ERR_CASCADE_COMM:
                    str = "级联系统通讯故障";
                    break;
                case sdk_err.ERR_NO_BATTLE_AREA:
                    str = "无战斗时间区域";
                    break;
                case sdk_err.ERR_NO_TIMER_AREA:
                    str = "无秒表区域";
                    break;
                case sdk_err.ERR_FPGA_COMM:
                    str = "与后级扫描模块通讯故障";
                    break;
                case sdk_err.ERR_SET_MODBUS_PARA:
                    str = "设置 MODBUS 参数错误";
                    break;
                default:
                    str = "未知错误：" + err;
                    break;
            }
            return str;
        }
        //byte[]转换为Intptr
        public static IntPtr BytesToIntptr(byte[] bytes)
        {
            //int size = bytes.Length;
            //IntPtr buffer = Marshal.AllocHGlobal(size);
            //try
            //{
            //    Marshal.Copy(bytes, 0, buffer, size);
            //    return buffer;
            //}
            //finally
            //{
            //    //Marshal.FreeHGlobal(buffer);
            //}
            GCHandle hObject = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();

            if (hObject.IsAllocated)
                hObject.Free();
            return pObject;
        }
        //byte[]转换为string  回读数据使用
        public static string BytesToString(byte[] bytes)
        {
            string str = "";
            for (int a = 0; a < bytes.Length; a++)
            {
                if (a == 0)
                {
                    str = Convert.ToUInt16(bytes[a]).ToString();
                }
                else
                {
                    str += "." + Convert.ToUInt16(bytes[a]).ToString();
                }
            }
            return str;
        }
        //byte转换为BCD码
        private static byte ConvertBCD(byte b)
        {
            //高四位  
            byte b1 = (byte)(b / 10);
            //低四位  
            byte b2 = (byte)(b % 10);
            return (byte)((b1 << 4) | b2);
        }
        /// <summary>  
        /// 将BCD一字节数据转换到byte 十进制数据  
        /// </summary>  
        /// <param name="b" />字节数  
        /// <returns>返回转换后的BCD码</returns>  
        public static byte ConvertBCDToInt(byte b)
        {
            //高四位  
            byte b1 = (byte)((b >> 4) & 0xF);
            //低四位  
            byte b2 = (byte)(b & 0xF);

            return (byte)(b1 * 10 + b2);
        }
        //队列语音列表
        public static List<bx_sdk_dual.EQSoundDepend_6G> list_stSoundData = new List<bx_sdk_dual.EQSoundDepend_6G>();
        //通讯方式
        public static int SendMode = 1;//0串口  1网口
        //星期数据转换
        public static byte set_bit(byte data, int index, bool flag)
        {
            if (index > 8 || index < 1)
                throw new ArgumentOutOfRangeException();
            int v = index < 2 ? index : (2 << (index - 2));
            return flag ? (byte)(data | v) : (byte)(data & ~v);
        }
    }
}
