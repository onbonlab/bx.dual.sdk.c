using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDK_CSharp_Form
{
    //BX-5使用接口
    public class Interface_5
    {
        //创建节目
        public static int Creat_Program(byte FileType,uint ProgramID,byte ProgramStyle,byte ProgramPriority,byte ProgramPlayTimes,ushort ProgramTimeSpan,
            byte ProgramWeek,ushort ProgramLifeSpan_sy,byte ProgramLifeSpan_sm,byte ProgramLifeSpan_sd,ushort ProgramLifeSpan_ey,byte ProgramLifeSpan_em,
            byte ProgramLifeSpan_ed)
        {
            bx_sdk_dual.EQprogramHeader header;
            header.FileType = FileType;
            header.ProgramID = ProgramID;
            header.ProgramStyle = ProgramStyle;
            header.ProgramPriority = ProgramPriority;
            header.ProgramPlayTimes = ProgramPlayTimes;
            header.ProgramTimeSpan = ProgramTimeSpan;
            header.ProgramWeek = ProgramWeek;
            header.ProgramLifeSpan_sy = ProgramLifeSpan_sy;
            header.ProgramLifeSpan_sm = ProgramLifeSpan_sm;
            header.ProgramLifeSpan_sd = ProgramLifeSpan_sd;
            header.ProgramLifeSpan_ey = ProgramLifeSpan_ey;
            header.ProgramLifeSpan_em = ProgramLifeSpan_em;
            header.ProgramLifeSpan_ed = ProgramLifeSpan_ed;
            int err = bx_sdk_dual.bxDual_program_addProgram(ref header);
            return err;
        }
        //添加时段
        public static void Creat_ProgramaddPlayPeriod()
        {
            bx_sdk_dual.EQprogrampTime_G56 Time;
            Time.StartHour = 0x14;
            Time.StartMinute = 0x37;
            Time.StartSecond = 0x00;
            Time.EndHour = 0x14;
            Time.EndMinute = 0x38;
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
            int err = bx_sdk_dual.bxDual_program_addPlayPeriodGrp(ref headerGrp);
            Console.WriteLine("program_addPlayPeriodGrp:" + err);
        }
        //节目添加边框
        public static void ProgramAddFrame()
        {
            bx_sdk_dual.EQscreenframeHeader sfheader;
            sfheader.FrameDispFlag = 0x01;
            sfheader.FrameDispStyle = 0x01;
            sfheader.FrameDispSpeed = 0x10;
            sfheader.FrameMoveStep = 0x01;
            sfheader.FrameWidth = 2;
            sfheader.FrameBackup = 0;
            byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
            bx_sdk_dual.bxDual_program_addFrame(ref sfheader, img);
        }
        //创建区域
        public static int Creat_Area(byte AreaType, ushort x, ushort y, ushort w, ushort h, ushort areaID)
        {
            bx_sdk_dual.EQareaHeader aheader;
            aheader.AreaType = AreaType;
            aheader.AreaX = x;
            aheader.AreaY = y;
            aheader.AreaWidth = w;
            aheader.AreaHeight = h;
            int err = bx_sdk_dual.bxDual_program_AddArea(areaID, ref aheader);
            return err;
        }
        //区域添加边框
        public static void AreaAddFrame(ushort areaID)
        {
            bx_sdk_dual.EQareaframeHeader afheader;
            afheader.AreaFFlag = 0x01;
            afheader.AreaFDispStyle = 0x01;
            afheader.AreaFDispSpeed = 0x08;
            afheader.AreaFMoveStep = 0x01;
            afheader.AreaFWidth = 3;
            afheader.AreaFBackup = 0;
            byte[] img = Encoding.Default.GetBytes("黄10.png");
            bx_sdk_dual.bxDual_program_picturesAreaAddFrame(areaID, ref afheader, img);
        }
        //添加内容
        public static int Creat_AddStr(ushort areaID, string txt, string font, byte DisplayMode, byte Speed, ushort StayTime, byte RepeatTime, ushort ValidLen,
            bx_sdk_dual.E_arrMode arrMode, ushort fontSize, uint color, byte fontBold, byte fontItalic,bx_sdk_dual.E_txtDirection tdirection, ushort txtSpace, byte Valign, byte Halign)
        {
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(txt);
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes(font);
            bx_sdk_dual.EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.ValidLen = ValidLen;
            pheader.arrMode = arrMode;
            pheader.fontSize = fontSize;
            pheader.color = color;
            pheader.fontBold = fontBold;
            pheader.fontItalic = fontItalic;
            pheader.tdirection = tdirection;
            pheader.txtSpace = txtSpace;
            pheader.Valign = Valign;
            pheader.Halign = Halign;
            int err = bx_sdk_dual.bxDual_program_picturesAreaAddTxt(areaID, str, Font, ref pheader);
            return err;
        }
        //添加图片
        public static int Creat_Addimg(ushort areaID, string txt, ushort picID, byte DisplayMode, byte Speed, ushort StayTime, byte RepeatTime, ushort ValidLen,
            bx_sdk_dual.E_arrMode arrMode, ushort fontSize, uint color, byte fontBold, byte fontItalic, bx_sdk_dual.E_txtDirection tdirection, ushort txtSpace, byte Valign, byte Halign)
        {
            bx_sdk_dual.EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.ValidLen = ValidLen;
            pheader.arrMode = arrMode;
            pheader.fontSize = fontSize;
            pheader.color = color;
            pheader.fontBold = fontBold;
            pheader.fontItalic = fontItalic;
            pheader.tdirection = tdirection;
            pheader.txtSpace = txtSpace;
            pheader.Valign = Valign;
            pheader.Halign = Halign;
            byte[] img = Encoding.GetEncoding("GBK").GetBytes(txt);
            int err = bx_sdk_dual.bxDual_program_pictureAreaAddPic(areaID, picID, ref pheader, img);
            return err;
        }
        //添加时间
        public static int Creat_Addtime(ushort areaID,bx_sdk_dual.EQtimeAreaData_G56 timeData)
        {
            int err = bx_sdk_dual.bxDual_program_timeAreaAddContent(areaID, ref timeData);
            //int err = bx_sdk_dual.program_fontPath_timeAreaAddContent(areaID, ref timeData2);
            return err;
        }
        //添加表盘
        public static int Creat_AddClock(ushort areaID,bx_sdk_dual.EQAnalogClockHeader_G56 acheader,int ClockStyle, bx_sdk_dual.ClockColor_G56 ClockColor)
        {
            int err = bx_sdk_dual.bxDual_program_timeAreaAddAnalogClock(areaID, ref acheader, (bx_sdk_dual.E_ClockStyle)ClockStyle, ref ClockColor);
            return err;
        }
        //发送 节目
        public static int Net_SengProgram(byte[] ipAdder,ushort port)
        {
            int err = bx_sdk_dual.bxDual_cmd_ofsStartFileTransf(ipAdder, port);
            bx_sdk_dual.EQprogram program = new bx_sdk_dual.EQprogram();
            err = bx_sdk_dual.bxDual_program_IntegrateProgramFile(ref program);
            err = bx_sdk_dual.bxDual_cmd_ofsWriteFile(ipAdder, port, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            err = bx_sdk_dual.bxDual_cmd_ofsEndFileTransf(ipAdder, port);
            err = bx_sdk_dual.bxDual_program_deleteProgram();
            return err;
        }
        public static int Com_SengProgram(byte[] com,byte bart)
        {
            bx_sdk_dual.EQprogram program = new bx_sdk_dual.EQprogram();
            int err = bx_sdk_dual.bxDual_program_IntegrateProgramFile(ref program);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsStartFileTransf(com, bart);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsWriteFile(com, bart, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsEndFileTransf(com, bart);
            err = bx_sdk_dual.bxDual_program_deleteProgram();
            return err;
        }
        //更新动态区文本
        public static int dynamicAreastr_5(byte[] ipAdder, ushort port, byte ScreenColor, byte uAreaId,byte RunMode,ushort Timeout, 
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,bx_sdk_dual.EQareaframeHeader Frame,byte DisplayMode, byte Speed, 
            ushort StayTime, byte RepeatTime,bx_sdk_dual.E_arrMode arrMode, ushort fontSize, uint color, byte fontBold, byte fontItalic,
            bx_sdk_dual.E_txtDirection tdirection, ushort txtSpace, byte Valign, byte Halign, string fontName, string strAreaTxtContent,
            byte PlayImmediately, byte RelateAllPro,ushort RelateProNum, ushort[] RelateProSerial)
        {
            int err = 0;
            bx_sdk_dual.EQfontData oFont;
            oFont.arrMode = arrMode;
            oFont.fontSize = fontSize;
            oFont.color = color;
            oFont.fontBold = fontBold;
            oFont.fontItalic = fontItalic;
            oFont.tdirection = tdirection;
            oFont.txtSpace = txtSpace;
            oFont.Valign = Valign;
            oFont.Halign = Halign;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes(fontName);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(strAreaTxtContent);

            err = bx_sdk_dual.bxDual_dynamicArea_AddAreaWithTxt_5G(ipAdder, port, (bx_sdk_dual.E_ScreenColor_G56)ScreenColor, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                            PlayImmediately, uAreaX, uAreaY, uWidth, uHeight, Frame, DisplayMode, 0, Speed, StayTime, RepeatTime, oFont, Font, str);
            return err;
        }
        //更新动态区文本
        public static int dynamicAreaimg_5(byte[] ipAdder, ushort port, byte ScreenColor, byte uAreaId, byte RunMode, ushort Timeout,
            ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, bx_sdk_dual.EQareaframeHeader Frame, byte DisplayMode, byte Speed,
            ushort StayTime, byte RepeatTime, string strAreaTxtContent,byte PlayImmediately, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial)
        {
            int err = 0;
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(strAreaTxtContent);

            err = bx_sdk_dual.bxDual_dynamicArea_AddAreaWithPic_5G(ipAdder, port, (bx_sdk_dual.E_ScreenColor_G56)ScreenColor, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                            PlayImmediately, uAreaX, uAreaY, uWidth, uHeight, Frame, DisplayMode, 0, Speed, StayTime, RepeatTime, str);
            return err;
        }
    }
}
