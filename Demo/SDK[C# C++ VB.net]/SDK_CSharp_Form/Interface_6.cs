using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SDK_CSharp_Form
{
    //BX-6使用接口
    public class Interface_6
    {
        //创建节目
        public static int Creat_Program(byte FileType,uint ProgramID,byte ProgramStyle,byte ProgramPriority,byte ProgramPlayTimes,ushort ProgramTimeSpan,byte SpecialFlag,
            byte CommExtendParaLen,ushort ScheduNum,ushort LoopValue,byte Intergrate,byte TimeAttributeNum,ushort TimeAttribute0Offset,byte ProgramWeek,ushort ProgramLifeSpan_sy,
            byte ProgramLifeSpan_sm,byte ProgramLifeSpan_sd,ushort ProgramLifeSpan_ey,byte ProgramLifeSpan_em,byte ProgramLifeSpan_ed)
        {
            bx_sdk_dual.EQprogramHeader_G6 header;
            header.FileType = FileType;
            header.ProgramID = ProgramID;
            header.ProgramStyle = ProgramStyle;
            header.ProgramPriority = ProgramPriority;
            header.ProgramPlayTimes = ProgramPlayTimes;
            header.ProgramTimeSpan = ProgramTimeSpan;
            header.SpecialFlag = SpecialFlag;
            header.CommExtendParaLen = CommExtendParaLen;
            header.ScheduNum = ScheduNum;
            header.LoopValue = LoopValue;
            header.Intergrate = Intergrate;
            header.TimeAttributeNum = TimeAttributeNum;
            header.TimeAttribute0Offset = TimeAttribute0Offset;
            header.ProgramWeek = ProgramWeek;
            header.ProgramLifeSpan_sy = ProgramLifeSpan_sy;
            header.ProgramLifeSpan_sm = ProgramLifeSpan_sm;
            header.ProgramLifeSpan_sd = ProgramLifeSpan_sd;
            header.ProgramLifeSpan_ey = ProgramLifeSpan_ey;
            header.ProgramLifeSpan_em = ProgramLifeSpan_em;
            header.ProgramLifeSpan_ed = ProgramLifeSpan_ed;
            int err = bx_sdk_dual.bxDual_program_addProgram_G6(ref header);
            return err;
        }
        //添加时段
        public static void Creat_ProgramaddPlayPeriod()
        {
            bx_sdk_dual.EQprogrampTime_G56 Time;
            Time.StartHour = 0x10;
            Time.StartMinute = 0x00;
            Time.StartSecond = 0x00;
            Time.EndHour = 0x11;
            Time.EndMinute = 0x00;
            Time.EndSecond = 0x00;

            bx_sdk_dual.EQprogramppGrp_G56 headerGrp;
            headerGrp.playTimeGrpNum = 1;
            headerGrp.timeGrp0 = Time;
            headerGrp.timeGrp1 = Time;
            headerGrp.timeGrp2 = Time;
            headerGrp.timeGrp3 = Time;
            headerGrp.timeGrp4 = Time;
            headerGrp.timeGrp5 = Time;
            headerGrp.timeGrp6 = Time;
            headerGrp.timeGrp7 = Time;
            int err = bx_sdk_dual.bxDual_program_addPlayPeriodGrp_G6(ref headerGrp);
            Console.WriteLine("program_addPlayPeriodGrp:" + err);
        }
        //节目添加边框
        public static void ProgramAddFrame()
        {
            bx_sdk_dual.EQscreenframeHeader_G6 sfheader;
            sfheader.FrameDispStype = 0x01;    //边框显示方式
            sfheader.FrameDispSpeed = 0x10;    //边框显示速度
            sfheader.FrameMoveStep = 0x01;     //边框移动步长
            sfheader.FrameUnitLength = 2;   //边框组元长度
            sfheader.FrameUnitWidth = 2;    //边框组元宽度
            sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
            byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
            bx_sdk_dual.bxDual_program_addFrame_G6(ref sfheader, img);
        }
        //创建区域
        public static int Creat_Area(byte AreaType, ushort x, ushort y, ushort w, ushort h, ushort areaID)
        {
            bx_sdk_dual.EQareaHeader_G6 aheader;
            aheader.AreaType = AreaType;
            aheader.AreaX = x;
            aheader.AreaY = y;
            aheader.AreaWidth = w;
            aheader.AreaHeight = h;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bx_sdk_dual.EQSound_6G stSoundData = new bx_sdk_dual.EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            int err = bx_sdk_dual.bxDual_program_addArea_G6(areaID, ref aheader);  //添加图文区域
            return err;
        }
        //区域添加边框
        public static void AreaAddFrame(ushort areaID)
        {
        }
        //添加内容
        public static int Creat_AddStr(ushort areaID, string txt,string font,byte DisplayMode,byte Speed,ushort StayTime,byte RepeatTime,ushort ValidLen,
            byte CartoonFrameRate,byte BackNotValidFlag, bx_sdk_dual.E_arrMode arrMode, ushort fontSize, uint color, byte fontBold, byte fontItalic, 
            bx_sdk_dual.E_txtDirection tdirection, ushort txtSpace, byte Valign, byte Halign)
        {
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(txt);
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes(font);
            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.ValidLen = ValidLen;
            pheader.CartoonFrameRate = CartoonFrameRate;
            pheader.BackNotValidFlag = BackNotValidFlag;
            pheader.arrMode = arrMode;
            pheader.fontSize = fontSize;
            pheader.color = color;
            pheader.fontBold = fontBold;
            pheader.fontItalic = fontItalic;
            pheader.tdirection = tdirection;
            pheader.txtSpace = txtSpace;
            pheader.Valign = Valign;
            pheader.Halign = Halign;
            int err = bx_sdk_dual.bxDual_program_picturesAreaAddTxt_G6(areaID, str, Font, ref pheader);
            return err;
        }
        //添加图片
        public static int Creat_Addimg(ushort areaID, string png, ushort picID, byte DisplayMode, byte Speed, ushort StayTime, byte RepeatTime, ushort ValidLen,
            byte CartoonFrameRate, byte BackNotValidFlag, bx_sdk_dual.E_arrMode arrMode, ushort fontSize, uint color, byte fontBold, byte fontItalic,
            bx_sdk_dual.E_txtDirection tdirection, ushort txtSpace, byte Valign, byte Halign)
        {
            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.ValidLen = ValidLen;
            pheader.CartoonFrameRate = CartoonFrameRate;
            pheader.BackNotValidFlag = BackNotValidFlag;
            pheader.arrMode = arrMode;
            pheader.fontSize = fontSize;
            pheader.color = color;
            pheader.fontBold = fontBold;
            pheader.fontItalic = fontItalic;
            pheader.tdirection = tdirection;
            pheader.txtSpace = txtSpace;
            pheader.Valign = Valign;
            pheader.Halign = Halign;
            byte[] img = Encoding.GetEncoding("GBK").GetBytes(png);
            int err = bx_sdk_dual.bxDual_program_pictureAreaAddPic_G6(areaID, picID, ref pheader, img);
            return err;
        }
        //添加时间
        public static int Creat_Addtime(ushort areaID,bx_sdk_dual.EQtimeAreaData_G56 timeData)
        {
            int err = bx_sdk_dual.bxDual_program_timeAreaAddContent_G6(areaID, ref timeData);
            return err;
        }
        //添加表盘
        public static int Creat_AddClock(ushort areaID, bx_sdk_dual.EQAnalogClockHeader_G56 acheader, int ClockStyle, bx_sdk_dual.ClockColor_G56 ClockColor)
        {
            int err = bx_sdk_dual.bxDual_program_timeAreaAddAnalogClock_G6(areaID, ref acheader, (bx_sdk_dual.E_ClockStyle)ClockStyle, ref ClockColor);
            return err;
        }
        //发送 节目
        public static int Net_SengProgram(byte[] ipAdder,ushort port)
        {
            int err = 0;
            bx_sdk_dual.EQprogram_G6 program = new bx_sdk_dual.EQprogram_G6();
            err = bx_sdk_dual.bxDual_program_IntegrateProgramFile_G6(ref program);
            err = bx_sdk_dual.bxDual_cmd_ofsStartFileTransf(ipAdder, port);
            err = bx_sdk_dual.bxDual_cmd_ofsWriteFile(ipAdder, port, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
            err = bx_sdk_dual.bxDual_cmd_ofsWriteFile(ipAdder, port, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            err = bx_sdk_dual.bxDual_cmd_ofsEndFileTransf(ipAdder, port);
            err = bx_sdk_dual.bxDual_program_deleteProgram_G6();
            return err;
        }
        public static int Com_SengProgram(byte[] com, byte bart)
        {
            int err = 0;
            bx_sdk_dual.EQprogram_G6 program = new bx_sdk_dual.EQprogram_G6();
            err = bx_sdk_dual.bxDual_program_IntegrateProgramFile_G6(ref program);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsStartFileTransf(com, bart);

            err = bx_sdk_dual.bxDual_cmd_uart_ofsWriteFile(com, bart, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsWriteFile(com, bart, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsEndFileTransf(com, bart);
            err = bx_sdk_dual.bxDual_program_deleteProgram_G6();
            return err;
        }
        //节目语言
        public static void Creat_sound(ushort areaID)
        {
            byte[] str = Encoding.GetEncoding("gb2312").GetBytes("请张三到1号窗口取药");
            bx_sdk_dual.EQPicAreaSoundHeader_G6 pheader;
            pheader.SoundPerson = 3;
            pheader.SoundVolum = 5;
            pheader.SoundSpeed = 5;
            pheader.SoundDataMode = 0;
            pheader.SoundReplayTimes = 0;
            pheader.SoundReplayDelay = 1000;
            pheader.SoundReservedParaLen = 3;
            pheader.Soundnumdeal = 1;
            pheader.Soundlanguages = 1;
            pheader.Soundwordstyle = 1;
            int err = bx_sdk_dual.bxDual_program_pictureAreaEnableSound_G6(areaID, pheader, str);
            Console.WriteLine("program_pictureAreaEnableSound_G6:" + err);
        }

        //更新动态区文本
        public static int dynamicAreastr_6(byte[] ipAdder, ushort port, byte ScreenColor, byte uAreaId, ushort x, ushort y, ushort w, ushort h,
            byte DisplayMode,byte Speed,ushort StayTime,byte RepeatTime,ushort ValidLen,byte CartoonFrameRate, 
            bx_sdk_dual.E_arrMode arrMode, ushort fontSize, uint color, byte fontBold, byte fontItalic,
            bx_sdk_dual.E_txtDirection tdirection, ushort txtSpace, byte Valign, byte Halign, string fontName, string strAreaTxtContent,
            byte PlayImmediately, ushort RelateProNum, ushort[] RelateProSerial, bx_sdk_dual.EQSound_6G stSoundData)
        {
            int err = 0;
            bx_sdk_dual.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = x;
            aheader.AreaY = y;
            aheader.AreaWidth = w;
            aheader.AreaHeight = h;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            aheader.stSoundData = stSoundData;

            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.ValidLen = ValidLen;
            pheader.CartoonFrameRate = CartoonFrameRate;
            pheader.BackNotValidFlag = 0;
            pheader.arrMode = arrMode;
            pheader.fontSize = fontSize;
            pheader.color = color;
            pheader.fontBold = fontBold;
            pheader.fontItalic = fontItalic;
            pheader.tdirection = tdirection;
            pheader.txtSpace = txtSpace;
            pheader.Valign = Valign;
            pheader.Halign = Halign;
            bx_sdk_dual.DynamicAreaParams[] Params = new bx_sdk_dual.DynamicAreaParams[1];
            Params[0].uAreaId = uAreaId;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes(fontName);
            Params[0].fontName = Calculation.BytesToIntptr(Font);
            byte[] str = Encoding.Default.GetBytes(strAreaTxtContent);
            Params[0].strAreaTxtContent = Calculation.BytesToIntptr(str);
            if (PlayImmediately == 1)
            {
                err = bx_sdk_dual.bxDual_dynamicAreaS_AddTxtDetails_6G(ipAdder, port, (bx_sdk_dual.E_ScreenColor_G56)ScreenColor, (byte)Params.Length, Params);
            }
            else
            {
                err = bx_sdk_dual.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(ipAdder, port, (bx_sdk_dual.E_ScreenColor_G56)ScreenColor, (byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            return err;
        }
        //更新动态区图片
        public static int dynamicAreaimg_6(byte[] ipAdder, ushort port, byte ScreenColor, byte uAreaId, ushort x, ushort y, ushort w, ushort h,
            byte DisplayMode, byte Speed, ushort StayTime, byte RepeatTime, ushort ValidLen, byte CartoonFrameRate,
            bx_sdk_dual.E_arrMode arrMode, ushort fontSize, uint color, byte fontBold, byte fontItalic,
            bx_sdk_dual.E_txtDirection tdirection, ushort txtSpace, byte Valign, byte Halign, string fontName, string strAreaTxtContent,
            byte PlayImmediately, ushort RelateProNum, ushort[] RelateProSerial, bx_sdk_dual.EQSound_6G stSoundData)
        {
            int err = 0;
            bx_sdk_dual.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = x;
            aheader.AreaY = y;
            aheader.AreaWidth = w;
            aheader.AreaHeight = h;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            aheader.stSoundData = stSoundData;

            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.ValidLen = ValidLen;
            pheader.CartoonFrameRate = CartoonFrameRate;
            pheader.BackNotValidFlag = 0;
            pheader.arrMode = arrMode;
            pheader.fontSize = fontSize;
            pheader.color = color;
            pheader.fontBold = fontBold;
            pheader.fontItalic = fontItalic;
            pheader.tdirection = tdirection;
            pheader.txtSpace = txtSpace;
            pheader.Valign = Valign;
            pheader.Halign = Halign;
            bx_sdk_dual.DynamicAreaParams[] Params = new bx_sdk_dual.DynamicAreaParams[1];
            Params[0].uAreaId = uAreaId;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes(fontName);
            Params[0].fontName = Calculation.BytesToIntptr(Font);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(strAreaTxtContent);
            Params[0].strAreaTxtContent = Calculation.BytesToIntptr(str);
            if (PlayImmediately == 1)
            {
                err = bx_sdk_dual.bxDual_dynamicAreaS_AddAreaPic_6G(ipAdder, port, (bx_sdk_dual.E_ScreenColor_G56)ScreenColor, (byte)Params.Length, Params);
            }
            else
            {
                err = bx_sdk_dual.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(ipAdder, port, (bx_sdk_dual.E_ScreenColor_G56)ScreenColor, (byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            return err;
        }
    }
}
