using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using System.IO.Ports;

namespace SDK_CSharp_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //初始化
            bx_sdk_dual.bxDual_InitSdk();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //通讯方式
            cmb_mode.SelectedIndex = 1;
            //波特率 默认57600
            cmb_Bart.SelectedIndex = 1;
            //插入队列语音 默认掉电不保存
            cmb_VoiceFlg.SelectedIndex = 0;
            //插入队列语音 默认从头播放
            cmb_StoreFlag.SelectedIndex = 0;
            //点阵类型  默认R+G
            cmb_program_Pixel.SelectedIndex = 0;
            //控制卡产品代数 默认BX-6
            cmb_BX_56.SelectedIndex = 1;
            //屏型  默认双基色
            cmb_program_Color.SelectedIndex = 1;
            //节目区域类型 默认图文区
            cmb_P_AreaType.SelectedIndex = 0;
            //节目图文运行特效 默认快速打出
            cmb_P_DisplayMode.SelectedIndex = 2;
            //控制卡型号 默认6E1X
            cmb_program_ControllerType.SelectedIndex = 104;
            //节目字体颜色 默认红色
            cmb_P_color.SelectedIndex = 1;
            //节目字体方向 默认正常
            cmb_P_txtDirection.SelectedIndex = 0;
            //节目字体水平位置 默认自动
            cmb_P_Valign.SelectedIndex = 0;
            //节目字体垂直位置 默认自动
            cmb_P_Halign.SelectedIndex = 0;
            //动态区
            //屏型  默认双基色
            cmb_dynamic_Color.SelectedIndex = 1;
            //动态图文运行特效 默认快速打出
            cmb_D_DisplayMode.SelectedIndex = 2;
            //动态字体颜色 默认红色
            cmb_D_color.SelectedIndex = 1;
            //动态字体方向 默认正常
            cmb_D_txtDirection.SelectedIndex = 0;
            //动态字体水平位置 默认自动
            cmb_D_Valign.SelectedIndex = 0;
            //动态字体垂直位置 默认自动
            cmb_D_Halign.SelectedIndex = 0;
            //动态区默认优先显示
            cmb_D_PlayImmediately.SelectedIndex = 1;
            //动态区运行模式
            cmb_D_Runmode.SelectedIndex = 0;
            //动态区边框特效
            cmb_D_AreaFDispStyle.SelectedIndex = 0;
            //节目时间区
            cmb_time_DateStyle.SelectedIndex = 0;
            cmb_time_TimeStyle.SelectedIndex = 0;
            cmb_time_WeekStyle.SelectedIndex = 0;
            cmb_time_color.SelectedIndex = 1;
            cmb_time_fontAlign.SelectedIndex = 0;
            cmb_ClockStyle.SelectedIndex = 0;
        }

        //发送节目
        private void btn_SendProgram_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                if (Calculation.SendMode == 0)
                {
                    byte[] com = Encoding.GetEncoding("GBK").GetBytes(cmb_COM.Text);
                    byte bart = (byte)(cmb_Bart.SelectedIndex + 1);
                    if (cmb_BX_56.SelectedIndex == 0)
                    {
                        err = Interface_5.Com_SengProgram(com, bart);
                    }
                    else
                    {
                        err = Interface_6.Com_SengProgram(com, bart);
                    }
                }
                else
                {
                    byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
                    ushort port = (ushort)num_port.Value;
                    if (cmb_BX_56.SelectedIndex == 0)
                    {
                        err = Interface_5.Net_SengProgram(ipAdder, port);
                    }
                    else
                    {
                        err = Interface_6.Net_SengProgram(ipAdder, port);
                    }
                }
                if (err == 0)
                {
                    MessageBox.Show("节目发送成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //设置屏参相关
        private void btn_setScreenParams_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                bx_sdk_dual.E_ScreenColor_G56 color = (bx_sdk_dual.E_ScreenColor_G56)(cmb_program_Color.SelectedIndex + 1);
                ushort ControllerType = ControlType.controlType[cmb_program_ControllerType.SelectedIndex];
                bx_sdk_dual.E_DoubleColorPixel_G56 doubleColor = (bx_sdk_dual.E_DoubleColorPixel_G56)(cmb_program_Pixel.SelectedIndex + 1);
                err = bx_sdk_dual.bxDual_program_setScreenParams_G56(color, ControllerType, doubleColor);
                if (err == 0)
                {
                    MessageBox.Show("设置成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //创建节目
        private void btn_CreatProgram_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                byte FileType = 0x00;
                uint ProgramID = (uint)num_ProgramID.Value;
                byte ProgramStyle = 0x00;
                byte ProgramPriority = 0x00;
                byte ProgramPlayTimes = (byte)num_ProgramPlayTimes.Value;
                ushort ProgramTimeSpan = (ushort)num_ProgramTimeSpan.Value;
                byte SpecialFlag = 0x00;
                byte CommExtendParaLen = 0x00;
                ushort ScheduNum = 0x00;
                ushort LoopValue = 0x00;
                byte Intergrate = 0x00;
                byte TimeAttributeNum = (byte)(check_TimeAttributeNum.Checked ? 1 : 0);
                ushort TimeAttribute0Offset = 0x00;
                //星期
                #region
                int index;
                bool flag;
                byte BIT = 0;
                if (checkMon.Checked == true)
                {
                    index = 1;
                    flag = true;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                else
                {
                    index = 1;
                    flag = false;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                if (checkTues.Checked == true)
                {
                    index = 2;
                    flag = true;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                else
                {
                    index = 2;
                    flag = false;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                if (checkWed.Checked == true)
                {
                    index = 3;
                    flag = true;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                else
                {
                    index = 3;
                    flag = false;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                if (checkThur.Checked == true)
                {
                    index = 4;
                    flag = true;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                else
                {
                    index = 4;
                    flag = false;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                if (checkFri.Checked == true)
                {
                    index = 5;
                    flag = true;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                else
                {
                    index = 5;
                    flag = false;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                if (checkSat.Checked == true)
                {
                    index = 6;
                    flag = true;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                else
                {
                    index = 6;
                    flag = false;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                if (checkSun.Checked == true)
                {
                    index = 7;
                    flag = true;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                else
                {
                    index = 7;
                    flag = false;
                    BIT = Calculation.set_bit(BIT, index, flag);
                }
                byte ProgramWeek = BIT;
                #endregion
                ushort ProgramLifeSpan_sy = 0xffff;//0xffff–年月日均无效，可以无限期播放 0xfffe-年无效 
                byte ProgramLifeSpan_sm = 0xfe;
                byte ProgramLifeSpan_sd = 0xfe;
                ushort ProgramLifeSpan_ey = 0xffff;
                byte ProgramLifeSpan_em = 0xfe;
                byte ProgramLifeSpan_ed = 0xfe;
                if (check_TimeAttributeNum.Checked)
                {
                    ProgramLifeSpan_sy = ushort.Parse(dTP_ProgramLifeSpan_strart.Value.Year.ToString(), NumberStyles.HexNumber);
                    ProgramLifeSpan_sm = Calculation.ConvertBCDToInt((byte)dTP_ProgramLifeSpan_strart.Value.Month);
                    ProgramLifeSpan_sd = Calculation.ConvertBCDToInt((byte)dTP_ProgramLifeSpan_strart.Value.Day);
                    ProgramLifeSpan_ey = ushort.Parse(dTP_ProgramLifeSpan_stop.Value.Year.ToString(), NumberStyles.HexNumber);
                    ProgramLifeSpan_em = Calculation.ConvertBCDToInt((byte)dTP_ProgramLifeSpan_stop.Value.Month);
                    ProgramLifeSpan_ed = Calculation.ConvertBCDToInt((byte)dTP_ProgramLifeSpan_stop.Value.Day);
                }

                if (cmb_BX_56.SelectedIndex == 0)
                {
                    err = Interface_5.Creat_Program(FileType, ProgramID, ProgramStyle, ProgramPriority, ProgramPlayTimes, ProgramTimeSpan,
                         ProgramWeek, ProgramLifeSpan_sy, ProgramLifeSpan_sm, ProgramLifeSpan_sd, ProgramLifeSpan_ey, ProgramLifeSpan_em,
                         ProgramLifeSpan_ed);
                }
                else
                {
                    err = Interface_6.Creat_Program(FileType, ProgramID, ProgramStyle, ProgramPriority, ProgramPlayTimes, ProgramTimeSpan, SpecialFlag,
                         CommExtendParaLen, ScheduNum, LoopValue, Intergrate, TimeAttributeNum, TimeAttribute0Offset, ProgramWeek, ProgramLifeSpan_sy,
                         ProgramLifeSpan_sm, ProgramLifeSpan_sd, ProgramLifeSpan_ey, ProgramLifeSpan_em, ProgramLifeSpan_ed);
                }
                if (err == 0)
                {
                    MessageBox.Show("节目创建成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //创建节目区域
        private void btn_P_CreatArea_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                byte AreaType=(byte)cmb_P_AreaType.SelectedIndex;
                ushort AreaX = (ushort)num_P_AreaX.Value;
                ushort AreaY = (ushort)num_P_AreaY.Value;
                ushort AreaWidth = (ushort)num_P_AreaWidth.Value;
                ushort AreaHeight = (ushort)num_P_AreaHeight.Value;
                ushort areaID = (ushort)num_P_AreaID.Value;
                if (cmb_BX_56.SelectedIndex == 0)
                {
                    err = Interface_5.Creat_Area(AreaType, AreaX, AreaY, AreaWidth, AreaHeight, areaID);
                }
                else
                {
                    err = Interface_6.Creat_Area(AreaType, AreaX, AreaY, AreaWidth, AreaHeight, areaID);
                }
                if (err == 0)
                {
                    MessageBox.Show("区域添加成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //节目添加文本
        private void btn_P_AreaAddStr_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                ushort areaID = (ushort)num_P_AreaID.Value;
                byte DisplayMode = (byte)cmb_P_DisplayMode.SelectedIndex;
                byte Speed = (byte)num_P_Speed.Value;
                ushort StayTime = (ushort)num_P_StayTime.Value;
                byte RepeatTime = (byte)num_P_RepeatTime.Value;
                ushort ValidLen = (ushort)num_P_AreaWidth.Value;
                byte CartoonFrameRate = (byte)num_P_CartoonFrameRate.Value;
                byte BackNotValidFlag = (byte)0;
                bx_sdk_dual.E_arrMode arrMode = (bx_sdk_dual.E_arrMode)(check_P_arrMode.Checked ? 0 : 1);
                ushort fontSize = (ushort)num_P_fontSize.Value;
                uint color = (uint)cmb_P_color.SelectedIndex;
                byte fontBold = (byte)(check_P_fontBold.Checked ? 1 : 0);
                byte fontItalic = (byte)(check_P_fontItalic.Checked ? 1 : 0);
                bx_sdk_dual.E_txtDirection tdirection = (bx_sdk_dual.E_txtDirection)cmb_P_txtDirection.SelectedIndex;
                ushort txtSpace = (byte)num_P_txtSpace.Value;
                byte Valign = (byte)cmb_P_Valign.SelectedIndex;
                byte Halign = (byte)cmb_P_Halign.SelectedIndex;
                string txt = txt_P_str.Text;
                string font = txt_P_font.Text;
                if (cmb_BX_56.SelectedIndex == 0)
                {
                    err = Interface_5.Creat_AddStr(areaID, txt, font, DisplayMode, Speed, StayTime, RepeatTime, ValidLen,
                        arrMode, fontSize, color, fontBold, fontItalic, tdirection, txtSpace, Valign, Halign);
                }
                else
                {
                    err = Interface_6.Creat_AddStr(areaID, txt, font, DisplayMode, Speed, StayTime, RepeatTime, ValidLen,CartoonFrameRate, 
                        BackNotValidFlag, arrMode, fontSize, color, fontBold, fontItalic, tdirection, txtSpace, Valign, Halign);
                }
                if (err == 0)
                {
                    MessageBox.Show("文本添加成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //节目语音
        private void btn_ProgramSound_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                if (cmb_BX_56.SelectedIndex == 0)
                {

                }
                else
                {

                }
                if (err == 0)
                {
                    MessageBox.Show("节目添加成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //发送语音队列
        private void btn_sendSoundIndepend_Click(object sender, EventArgs e)
        {
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
            int err = 0;

            if (Calculation.list_stSoundData.Count > 0) 
            {
                bx_sdk_dual.EQSoundDepend_6G[] list_stSoundData = Calculation.list_stSoundData.ToArray();
                err = bx_sdk_dual.bxDual_dynamicArea_UpdateSoundIndepend(ipAdder, 5005, list_stSoundData, (byte)Calculation.list_stSoundData.Count, (byte)cmb_StoreFlag.SelectedIndex);
            }
        }
        //发送插入语音
        private void btn_InsertSound_Click(object sender, EventArgs e)
        {
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
            int err = 0;

            SOUND sd = new SOUND();
            DialogResult ret = sd.ShowDialog();

            if (ret == DialogResult.OK)
            {
                err = bx_sdk_dual.bxDual_dynamicArea_InsertSoundIndepend(ipAdder, 5005, SOUND.InstSoundData, (byte)cmb_VoiceFlg.SelectedIndex, (byte)cmb_StoreFlag.SelectedIndex);
                    if (err == 0)
                    {
                        MessageBox.Show("成功");
                    }
                    else
                    {
                        MessageBox.Show("失败" + err);
                    }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        //添加队列语音
        private void btn_AddSoundIndepend_Click(object sender, EventArgs e)
        {
            SOUND sd = new SOUND();
            DialogResult ret = sd.ShowDialog();

            if (ret == DialogResult.OK)
            {
                Calculation.list_stSoundData.Add(SOUND.InstSoundData);
                listB_Sound.Items.Add(SOUND.InstSoundData.VoiceID);
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        //删除队列语音
        private void btn_DelSoundIndepend_Click(object sender, EventArgs e)
        {
            if (listB_Sound.Items.Count > 0)
            {
                int index = listB_Sound.SelectedIndex;
                Calculation.list_stSoundData.RemoveAt(index);
                listB_Sound.Items.Remove(listB_Sound.SelectedItem);
            }
            else { MessageBox.Show("请选择队列编号!"); }
        }
        //广播获取控制卡状态，只能接受一个控制卡数据
        private void btn_ping_udp_Click(object sender, EventArgs e)
        {
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
            int err = 0;
            bx_sdk_dual.Ping_data data = new bx_sdk_dual.Ping_data();
            err = bx_sdk_dual.bxDual_cmd_udpPing(ref data);
            if (err == 0)
            {
                txt_ping_ControllerType.Text = data.ControllerType.ToString();
                txt_ping_FirmwareVersion.Text = System.Text.Encoding.Default.GetString(data.FirmwareVersion);
                cmb_ping_ScreenParaStatus.SelectedIndex = data.ScreenParaStatus;
                txt_ping_Address.Text = data.Address.ToString();
                cmb_ping_Baudrate.SelectedIndex = data.Baudrate;
                txt_ping_W.Text = data.ScreenWidth.ToString();
                txt_ping_H.Text = data.ScreenHeight.ToString();
                if (data.Color == 1) { cmb_ping_Color.SelectedIndex = 0; }
                else if (data.Color == 3) { cmb_ping_Color.SelectedIndex = 1; }
                else if (data.Color == 7) { cmb_ping_Color.SelectedIndex = 2; }
                else { cmb_ping_Color.SelectedIndex = 3; }
                txt_ping_CurrentBrigtness.Text = data.CurrentBrigtness.ToString();
                cmb_ping_CurrentOnOffStatus.SelectedIndex = data.CurrentOnOffStatus;
                txt_ping_IP.Text = System.Text.Encoding.Default.GetString(data.ipAdder);
            }
            else { MessageBox.Show(Calculation.GetError(err)); }
        }
        //指定IP获取控制卡状态
        private void btn_ping_tcp_Click(object sender, EventArgs e)
        {
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
            int err = 0;
            bx_sdk_dual.Ping_data data = new bx_sdk_dual.Ping_data();
            err = bx_sdk_dual.bxDual_cmd_tcpPing(ipAdder, 5005, ref data);
            if (err == 0)
            {
                txt_ping_ControllerType.Text = data.ControllerType.ToString();
                txt_ping_FirmwareVersion.Text = System.Text.Encoding.Default.GetString(data.FirmwareVersion);
                cmb_ping_ScreenParaStatus.SelectedIndex = data.ScreenParaStatus;
                txt_ping_Address.Text = data.Address.ToString();
                cmb_ping_Baudrate.SelectedIndex = data.Baudrate;
                txt_ping_W.Text = data.ScreenWidth.ToString();
                txt_ping_H.Text = data.ScreenHeight.ToString();
                if (data.Color == 1) { cmb_ping_Color.SelectedIndex = 0; }
                else if (data.Color == 3) { cmb_ping_Color.SelectedIndex = 1; }
                else if (data.Color == 7) { cmb_ping_Color.SelectedIndex = 2; }
                else { cmb_ping_Color.SelectedIndex = 3; }
                txt_ping_CurrentBrigtness.Text = data.CurrentBrigtness.ToString();
                cmb_ping_CurrentOnOffStatus.SelectedIndex = data.CurrentOnOffStatus;
                txt_ping_IP.Text = txt_IP.Text;
            }
            else { MessageBox.Show(Calculation.GetError(err)); }
        }
        //网络搜索
        private void btn_NetworkSearch_Click(object sender, EventArgs e)
        {
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
            int err = 0;
            bx_sdk_dual.NetSearchCmdRet CmdRet = new bx_sdk_dual.NetSearchCmdRet();
            err = bx_sdk_dual.bxDual_cmd_tcpNetworkSearch_6G(ipAdder, 5005, ref CmdRet);
            if (err == 0)
            {
                //Mac 地址
                richT_SearchData.Text = "Mac:" + CmdRet.Mac[0].ToString("X2") + CmdRet.Mac[1].ToString("X2") + CmdRet.Mac[2].ToString("X2") + CmdRet.Mac[3].ToString("X2") + CmdRet.Mac[4].ToString("X2") + CmdRet.Mac[5].ToString("X2") + System.Environment.NewLine;
                //控制器 IP 地址
                richT_SearchData.Text += "IP:" + Calculation.BytesToString(CmdRet.IP) + System.Environment.NewLine;
                //子网掩码
                richT_SearchData.Text += "SubNetMask:" + Calculation.BytesToString(CmdRet.SubNetMask) + System.Environment.NewLine;
                //网关
                richT_SearchData.Text += "Gate:" + Calculation.BytesToString(CmdRet.Gate) + System.Environment.NewLine;
                //端口
                richT_SearchData.Text += "Port:" + CmdRet.Port + System.Environment.NewLine;
                //1 表示 DHCP 2 表示手动设置
                if (CmdRet.IPMode == 1)
                {
                    richT_SearchData.Text += "IPMode:DHCP" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "IPMode:表示手动设置" + System.Environment.NewLine;
                }
                //0 表示 IP 设置失败 1 表示 IP 设置成功
                if (CmdRet.IPMode == 0)
                {
                    richT_SearchData.Text += "IPStatus:IP 设置失败" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "IPStatus:IP 设置成功" + System.Environment.NewLine;
                }
                //0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
                if (CmdRet.ServerMode == 0)
                {
                    richT_SearchData.Text += "ServerMode:服务器模式使能    普通模式" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 1)
                {
                    richT_SearchData.Text += "ServerMode:服务器模式禁止    普通模式" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 2)
                {
                    richT_SearchData.Text += "ServerMode:服务器模式禁止    web模式" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "ServerMode:服务器模式使能    web模式" + System.Environment.NewLine;
                }
                //服务器 IP 地址
                richT_SearchData.Text += "ServerIPAddress:" + Calculation.BytesToString(CmdRet.ServerIPAddress) + System.Environment.NewLine;
                //服务器端口号
                richT_SearchData.Text += "ServerPort:" + CmdRet.ServerPort + System.Environment.NewLine;
                //服务器访问密码
                richT_SearchData.Text += "ServerAccessPassword:" + System.Text.Encoding.Default.GetString(CmdRet.ServerAccessPassword) + System.Environment.NewLine;
                //20S 心跳时间间隔（单位：秒）
                richT_SearchData.Text += "HeartBeatInterval:" + CmdRet.HeartBeatInterval + System.Environment.NewLine;
                //用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
                richT_SearchData.Text += "CustomID:" + System.Text.Encoding.Default.GetString(CmdRet.CustomID) + System.Environment.NewLine;
                //条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
                richT_SearchData.Text += "BarCode:" + System.Text.Encoding.Default.GetString(CmdRet.BarCode) + System.Environment.NewLine;
                //其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
                richT_SearchData.Text += "ControllerType:" + (CmdRet.ControllerType[1] * 256 + CmdRet.ControllerType[0]) / 10 + System.Environment.NewLine;
                //Firmware 版本号
                richT_SearchData.Text += "FirmwareVersion:" + System.Text.Encoding.Default.GetString(CmdRet.FirmwareVersion) + System.Environment.NewLine;
                //控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
                if (CmdRet.ScreenParaStatus == 0)
                {
                    richT_SearchData.Text += "ScreenParaStatus:控制器中没有参数配置文件，必须先加载屏参" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "ScreenParaStatus:控制器中有参数配置文件" + System.Environment.NewLine;
                }
                //0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
                richT_SearchData.Text += "Address:" + CmdRet.Address + System.Environment.NewLine;
                //0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
                if (CmdRet.Baudrate == 1)
                {
                    richT_SearchData.Text += "Baudrate:9600" + System.Environment.NewLine;
                }
                else if (CmdRet.Baudrate == 2)
                {
                    richT_SearchData.Text += "Baudrate:57600" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "Baudrate:保持原有波特率不变" + System.Environment.NewLine;
                }
                //显示屏宽度
                richT_SearchData.Text += "ScreenWidth:" + CmdRet.ScreenWidth + System.Environment.NewLine;
                //显示屏高度
                richT_SearchData.Text += "ScreenHeight:" + CmdRet.ScreenHeight + System.Environment.NewLine;
                //0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
                if (CmdRet.Color == 1)
                {
                    richT_SearchData.Text += "Color:单色" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 3)
                {
                    richT_SearchData.Text += "Color:双色" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 7)
                {
                    richT_SearchData.Text += "Color:三色" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "Color:灰度全彩" + System.Environment.NewLine;
                }
                //调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
                if (CmdRet.BrightnessAdjMode == 0)
                {
                    richT_SearchData.Text += "BrightnessAdjMode:手动调亮" + System.Environment.NewLine;
                }
                else if (CmdRet.BrightnessAdjMode == 1)
                {
                    richT_SearchData.Text += "BrightnessAdjMode:定时调亮" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "BrightnessAdjMode:自动调亮" + System.Environment.NewLine;
                }
                //当前亮度值
                richT_SearchData.Text += "CurrentBrigtness:" + CmdRet.CurrentBrigtness + System.Environment.NewLine;
                //Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
                if (CmdRet.TimingOnOff == 0)
                {
                    richT_SearchData.Text += "TimingOnOff:无定时开关机" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "TimingOnOff:有定时开关机" + System.Environment.NewLine;
                }
                //开关机状态
                if (CmdRet.CurrentOnOffStatus == 0)
                {
                    richT_SearchData.Text += "CurrentOnOffStatus:开机" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "CurrentOnOffStatus:关机" + System.Environment.NewLine;
                }
                //扫描配置编号
                richT_SearchData.Text += "ScanConfNumber:扫描配置编号 " + CmdRet.ScanConfNumber + System.Environment.NewLine;
                //一路数据带几行
                richT_SearchData.Text += "RowsPerChanel:" + CmdRet.RowsPerChanel + System.Environment.NewLine;
                //对于无灰度系统，返回 0；对于有灰度系 1
                if (CmdRet.GrayFlag == 0)
                {
                    richT_SearchData.Text += "GrayFlag:无灰度系统" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "GrayFlag:有灰度系统" + System.Environment.NewLine;
                }
                //最小单元宽度
                richT_SearchData.Text += "UnitWidth:最小单元宽度 " + CmdRet.UnitWidth + System.Environment.NewLine;
                //6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
                if (CmdRet.modeofdisp == 0)
                {
                    richT_SearchData.Text += "modeofdisp:6Q 显示模式 888 " + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "modeofdisp:6Q 显示模式 565 " + System.Environment.NewLine;
                }
                //当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
                richT_SearchData.Text += "NetTranMode:" + CmdRet.NetTranMode + System.Environment.NewLine;
                //包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
                if (CmdRet.PackageMode == 0)
                {
                    richT_SearchData.Text += "PackageMode:小包模式，分包 600 byte" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "PackageMode:大包模式，分包 16K byte" + System.Environment.NewLine;
                }
                //是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
                if (CmdRet.BarcodeFlag == 0)
                {
                    richT_SearchData.Text += "BarcodeFlag:无条码" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "BarcodeFlag:有条码" + System.Environment.NewLine;
                }
                //控制器上已有节目个数
                richT_SearchData.Text += "ProgramNumber:控制器上已有节目个数 " + CmdRet.ProgramNumber + System.Environment.NewLine;
                //当前节目名
                richT_SearchData.Text += "CurrentProgram:当前节目名 " + System.Text.Encoding.Default.GetString(CmdRet.CurrentProgram) + System.Environment.NewLine;
                //Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
                if (CmdRet.ScreenLockStatus == 0)
                {
                    richT_SearchData.Text += "ScreenLockStatus:无屏幕锁定" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "ScreenLockStatus:屏幕锁定" + System.Environment.NewLine;
                }
                //Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
                if (CmdRet.ProgramLockStatus == 0)
                {
                    richT_SearchData.Text += "ProgramLockStatus:无节目锁定" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "ProgramLockStatus:节目锁定" + System.Environment.NewLine;
                }
                //控制器运行模式
                richT_SearchData.Text += "RunningMode:" + CmdRet.RunningMode + System.Environment.NewLine;
                //RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
                if (CmdRet.RTCStatus == 0)
                {
                    richT_SearchData.Text += "RTCStatus:RTC 异常" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "RTCStatus:RTC 正常" + System.Environment.NewLine;
                }
                //年
                richT_SearchData.Text += "RTCYear:" + (Calculation.ConvertBCDToInt(CmdRet.RTCYear[1]) * 100 + Calculation.ConvertBCDToInt(CmdRet.RTCYear[0])) + System.Environment.NewLine;
                //月
                richT_SearchData.Text += "RTCMonth:" + Calculation.ConvertBCDToInt(CmdRet.RTCMonth) + System.Environment.NewLine;
                //日
                richT_SearchData.Text += "RTCDate:" + Calculation.ConvertBCDToInt(CmdRet.RTCDate) + System.Environment.NewLine;
                //时
                richT_SearchData.Text += "RTCHour:" + Calculation.ConvertBCDToInt(CmdRet.RTCHour) + System.Environment.NewLine;
                //分
                richT_SearchData.Text += "RTCMinute:" + Calculation.ConvertBCDToInt(CmdRet.RTCMinute) + System.Environment.NewLine;
                //秒
                richT_SearchData.Text += "RTCSecond:" + Calculation.ConvertBCDToInt(CmdRet.RTCSecond) + System.Environment.NewLine;
                //星期，范围为 1~7，7 表示周日
                richT_SearchData.Text += "RTCWeek:星期" + CmdRet.RTCWeek + System.Environment.NewLine;
                //温度传感器当前值 第一个字节0为正1为负 数值/10
                if ((CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) != 0xffff)
                {
                    if (CmdRet.Temperature1[0] == 0)
                    {
                        richT_SearchData.Text += "Temperature1:+" + (CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) / 10 + System.Environment.NewLine;
                    }
                    else
                    {
                        richT_SearchData.Text += "Temperature1:-" + (CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) / 10 + System.Environment.NewLine;
                    }
                }
                else
                {
                    richT_SearchData.Text += "Temperature1:无温度传感器" + System.Environment.NewLine;
                }
                //温湿度传感器温度当前值 第一个字节0为正1为负 数值/10
                if ((CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) != 0xffff)
                {
                    if (CmdRet.Temperature2[0] == 0)
                    {
                        richT_SearchData.Text += "Temperature2:+" + (CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) / 10 + System.Environment.NewLine;
                    }
                    else
                    {
                        richT_SearchData.Text += "Temperature2:-" + (CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) / 10 + System.Environment.NewLine;
                    }
                }
                else
                {
                    richT_SearchData.Text += "Temperature2:无温度传感器" + System.Environment.NewLine;
                }
                //湿度传感器当前值  数值/10
                if ((CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) != 0xffff)
                {
                    richT_SearchData.Text += "Humidity:" + (CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "Humidity:无湿度传感器" + System.Environment.NewLine;
                }
                //噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
                if ((CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) != 0xffff)
                {
                    richT_SearchData.Text += "Noise:" + (CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "Noise:无噪声传感器+" + System.Environment.NewLine;
                }
                //0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
                if (CmdRet.LogoFlag == 0)
                {
                    richT_SearchData.Text += "LogoFlag:未设置 Logo 节目" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "LogoFlag:设置了 Logo 节目" + System.Environment.NewLine;
                }
                //0：未设置开机延时 1：开机延时时长
                if (CmdRet.PowerOnDelay == 0)
                {
                    richT_SearchData.Text += "PowerOnDelay:未设置开机延时" + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "PowerOnDelay:开机延时时长 " + CmdRet.PowerOnDelay + System.Environment.NewLine;
                }
                //风速(除以 10 为当前值) 0xfffff 时无效
                if ((CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) != 0xffff)
                {
                    richT_SearchData.Text += "WindSpeed:" + (CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "WindSpeed:无风速传感器" + System.Environment.NewLine;
                }
                //风向(当前值) 0xfffff 时无效
                if ((CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) != 0xffff)
                {
                    richT_SearchData.Text += "WindDirction:(0:0°北风 1:45°东北风 2:90°东风 3:135°东南风 4:180°南风 5:225°西南风 6:270°西风 7:315°西北风)" + (CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "WindDirction:无风向传感器" + System.Environment.NewLine;
                }
                //PM2.5 值(当前值)0xfffff 时无效
                if ((CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) != 0xffff)
                {
                    richT_SearchData.Text += "PM2_5:" + (CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "PM2_5:无PM2_5传感器" + System.Environment.NewLine;
                }
                //PM10 值(当前值)0xfffff 时无效
                if ((CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) != 0xffff)
                {
                    richT_SearchData.Text += "PM10:" + (CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) + System.Environment.NewLine;
                }
                else
                {
                    richT_SearchData.Text += "PM10:无PM10传感器" + System.Environment.NewLine;
                }
                //LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
                string ControllerName = "";
                for (int i = 0; i < CmdRet.ControllerName.Length; i++) { ControllerName += CmdRet.ControllerName[i].ToString("X2").ToUpper(); }
                richT_SearchData.Text += "ControllerName:" + ControllerName + System.Environment.NewLine;
                //屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
                string ScreenLocation = "";
                for (int i = 0; i < CmdRet.ScreenLocation.Length; i++) { ScreenLocation += CmdRet.ScreenLocation[i].ToString("X2").ToUpper(); }
                richT_SearchData.Text += "ScreenLocation:" + ScreenLocation + System.Environment.NewLine;
                //控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
                string NameLocalationCRC32 = "";
                for (int i = 0; i < CmdRet.NameLocalationCRC32.Length; i++) { NameLocalationCRC32 += CmdRet.NameLocalationCRC32[i].ToString("X2").ToUpper(); }
                richT_SearchData.Text += "NameLocalationCRC32:" + NameLocalationCRC32 + System.Environment.NewLine;
            }
            else { MessageBox.Show(Calculation.GetError(err)); }
        }
        //区域类型设置  目前支持图文 时间
        private void cmb_P_AreaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmb_P_AreaType.SelectedIndex != 0) && (cmb_P_AreaType.SelectedIndex != 2))
            { cmb_P_AreaType.SelectedIndex = 0; }
        }
        //节目添加图片路径
        private void btn_P_Addpng_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false; 
            openFileDialog1.Filter = "所有支持文件|*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_P_png.Text = openFileDialog1.FileName;
            }
        }

        //通讯方式选择
        private void cmb_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculation.SendMode = cmb_mode.SelectedIndex;
            if (cmb_mode.SelectedIndex == 0) { groupBox7.Enabled = false; groupBox11.Enabled = true; }
            else { groupBox7.Enabled = true; groupBox11.Enabled = false; }
        }
        //搜索串口
        private void btn_seachCOM_Click(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();
            if (names.Length > 0)
            {
                cmb_COM.Items.Clear();
                for (int n = 0; n < names.Length; n++)
                {
                    cmb_COM.Items.Add(names[n]);
                }
                cmb_COM.SelectedIndex = 0;
            }
        }
        //节目添加图片
        private void btn_P_AreaAddPng_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                ushort areaID = (ushort)num_P_AreaID.Value;
                byte DisplayMode = (byte)cmb_P_DisplayMode.SelectedIndex;
                byte Speed = (byte)num_P_Speed.Value;
                ushort StayTime = (ushort)num_P_StayTime.Value;
                byte RepeatTime = (byte)num_P_RepeatTime.Value;
                ushort ValidLen = (ushort)num_P_AreaWidth.Value;
                byte CartoonFrameRate = (byte)num_P_CartoonFrameRate.Value;
                byte BackNotValidFlag = (byte)0;
                bx_sdk_dual.E_arrMode arrMode = (bx_sdk_dual.E_arrMode)(check_P_arrMode.Checked ? 0 : 1);
                ushort fontSize = (ushort)num_P_fontSize.Value;
                uint color = (uint)cmb_P_color.SelectedIndex;
                byte fontBold = (byte)(check_P_fontBold.Checked ? 1 : 0);
                byte fontItalic = (byte)(check_P_fontItalic.Checked ? 1 : 0);
                bx_sdk_dual.E_txtDirection tdirection = (bx_sdk_dual.E_txtDirection)cmb_P_txtDirection.SelectedIndex;
                ushort txtSpace = (ushort)num_P_txtSpace.Value;
                byte Valign = (byte)cmb_P_Valign.SelectedIndex;
                byte Halign = (byte)cmb_P_Halign.SelectedIndex;
                string txt = txt_P_png.Text;
                ushort picID = (ushort)num_P_pngID.Value;
                if (cmb_BX_56.SelectedIndex == 0)
                {
                    err = Interface_5.Creat_Addimg(areaID, txt, picID, DisplayMode, Speed, StayTime, RepeatTime, ValidLen,
                        arrMode, fontSize, color, fontBold, fontItalic, tdirection, txtSpace, Valign, Halign);
                }
                else
                {
                    err = Interface_6.Creat_Addimg(areaID, txt, picID, DisplayMode, Speed, StayTime, RepeatTime, ValidLen, CartoonFrameRate,
                        BackNotValidFlag, arrMode, fontSize, color, fontBold, fontItalic, tdirection, txtSpace, Valign, Halign);
                }
                if (err == 0)
                {
                    MessageBox.Show("节目添加成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //删除显示屏所有节目
        private void btn_DelAllProgram_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                if (Calculation.SendMode == 0)
                {
                    byte[] com = Encoding.GetEncoding("GBK").GetBytes(cmb_COM.Text);
                    byte bart = (byte)(cmb_Bart.SelectedIndex + 1);
                    err = Interface_56.Com_DelProgram(com, bart);
                }
                else
                {
                    byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
                    ushort port = (ushort)num_port.Value;
                    err = Interface_56.Net_DelProgram(ipAdder, port);
                }
                if (err == 0)
                {
                    MessageBox.Show("节目删除成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //更新动态区文本
        private void btn_Dynamic_str_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
                ushort port = (ushort)num_port.Value;
                byte ScreenColor = (byte)(cmb_dynamic_Color.SelectedIndex + 1);
                byte AreaId = (byte)num_D_AreaID.Value;
                string strAreaTxtContent = txt_D_str.Text + "\0";
                string fontName = txt_D_font.Text;
                ushort AreaX = (ushort)num_D_AreaX.Value;
                ushort AreaY = (ushort)num_D_AreaY.Value;
                ushort AreaWidth = (ushort)num_D_AreaWidth.Value;
                ushort AreaHeight = (ushort)num_D_AreaHeight.Value;
                byte DisplayMode = (byte)cmb_D_DisplayMode.SelectedIndex;
                byte Speed = (byte)num_D_Speed.Value;
                ushort StayTime = (ushort)num_D_StayTime.Value;
                byte RepeatTime = (byte)num_D_RepeatTime.Value;
                ushort ValidLen = (ushort)num_D_AreaWidth.Value;
                byte CartoonFrameRate = (byte)num_D_CartoonFrameRate.Value;
                bx_sdk_dual.E_arrMode arrMode = (bx_sdk_dual.E_arrMode)(check_D_arrMode.Checked ? 0 : 1);
                ushort fontSize = (ushort)num_D_fontSize.Value;
                uint color = (uint)cmb_D_color.SelectedIndex;
                byte fontBold = (byte)(check_D_fontBold.Checked ? 1 : 0);
                byte fontItalic = (byte)(check_D_fontItalic.Checked ? 1 : 0);
                bx_sdk_dual.E_txtDirection tdirection = (bx_sdk_dual.E_txtDirection)cmb_D_txtDirection.SelectedIndex;
                ushort txtSpace = (ushort)num_D_txtSpace.Value;
                byte Valign = (byte)cmb_D_Valign.SelectedIndex;
                byte Halign = (byte)cmb_D_Halign.SelectedIndex;
                //播放优先级
                byte RunMode = (byte)cmb_D_Runmode.SelectedIndex;
                ushort Timeout = (ushort)num_D_Timeout.Value;
                byte PlayImmediately = (byte)cmb_D_PlayImmediately.SelectedIndex;
                byte RelateAllPro =1;
                ushort RelateProNum = 0;
                ushort[] RelateProSerial = new ushort[0];
                if (check_WithProgram.Checked)
                {
                    RelateAllPro = 0;
                    string[] str_Area = txt_RelateProSerial.Text.Trim().Split(',');
                    RelateProNum = (ushort)str_Area.Length;
                    RelateProSerial = new ushort[str_Area.Length];
                    for (int i = 0; i < str_Area.Length; i++)
                    {
                        RelateProSerial[i] = ushort.Parse(str_Area[i]);
                    }
                }
                else { RelateAllPro = 1;RelateProNum = 0; RelateProSerial = null; }
                if (cmb_BX_56.SelectedIndex == 0)
                {
                    bx_sdk_dual.EQareaframeHeader Frame;
                    Frame.AreaFFlag = 0;
                    Frame.AreaFDispStyle = 0;
                    Frame.AreaFDispSpeed = 0;
                    Frame.AreaFMoveStep = 0;
                    Frame.AreaFWidth = 0;
                    Frame.AreaFBackup = 0;
                    if (chk_D_AreaFFlag.Checked)
                    {
                        Frame.AreaFFlag = 1;
                        Frame.AreaFDispStyle = (byte)cmb_D_AreaFDispStyle.SelectedIndex;
                        Frame.AreaFDispSpeed = (byte)num_D_AreaFDispSpeed.Value;
                        Frame.AreaFMoveStep = (byte)num_D_AreaFMoveStep.Value;
                        Frame.AreaFWidth = (byte)num_D_AreaFWidth.Value;
                        Frame.AreaFBackup = 0;
                    }
                    err = Interface_5.dynamicAreastr_5(ipAdder, port, ScreenColor, AreaId, RunMode, Timeout, AreaX, AreaY, AreaWidth, AreaHeight, Frame, DisplayMode, Speed,
                        StayTime, RepeatTime, arrMode, fontSize, color, fontBold, fontItalic, tdirection, txtSpace, Valign, Halign, fontName, strAreaTxtContent,
                        PlayImmediately, RelateAllPro, RelateProNum, RelateProSerial);
                }
                else
                {
                    bx_sdk_dual.EQSound_6G stSoundData = new bx_sdk_dual.EQSound_6G();
                    stSoundData.SoundFlag = 0;
                    stSoundData.SoundPerson = 0;
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
                    if (check_Sound.Checked)
                    {
                        stSoundData.SoundFlag = 1;
                        stSoundData.SoundPerson = (byte)cmb_SoundPerson.SelectedIndex;
                        stSoundData.SoundVolum = (byte)cmb_SoundVolum.SelectedIndex;
                        stSoundData.SoundSpeed = (byte)cmb_SoundSpeed.SelectedIndex;
                        stSoundData.SoundDataMode = (byte)cmb_SoundDataMode.SelectedIndex;
                        if ((int)cmb_SoundReplayTimes.SelectedIndex < 15)
                        {
                            stSoundData.SoundReplayTimes = (uint)cmb_SoundReplayTimes.SelectedIndex;
                        }
                        else { stSoundData.SoundReplayTimes = 0xFFFFFFFF; }
                        stSoundData.SoundReplayDelay = (int)num_SoundReplayDelay.Value;
                        stSoundData.SoundReservedParaLen = 0x03;
                        stSoundData.Soundnumdeal = (byte)cmb_Soundnumdeal.SelectedIndex;
                        stSoundData.Soundlanguages = (byte)cmb_Soundlanguages.SelectedIndex;
                        stSoundData.Soundwordstyle = (byte)cmb_Soundwordstyle.SelectedIndex;
                        byte[] SoundAreaText=new byte[0];
                        switch (cmb_SoundDataMode.SelectedIndex)
                        {
                            case 0:
                                SoundAreaText = System.Text.Encoding.GetEncoding("GB2312").GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                            case 1:
                                SoundAreaText = System.Text.Encoding.GetEncoding("GBK").GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                            case 2:
                                SoundAreaText = System.Text.Encoding.GetEncoding("Big5").GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                            case 3:
                                SoundAreaText = System.Text.Encoding.Unicode.GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                        }
                        stSoundData.SoundData = Calculation.BytesToIntptr(SoundAreaText);
                        stSoundData.SoundDataLen = SoundAreaText.Length;
                    }
                    err = Interface_6.dynamicAreastr_6(ipAdder, port, ScreenColor, AreaId, AreaX, AreaY, AreaWidth, AreaHeight, DisplayMode, Speed, 
                        StayTime, RepeatTime, ValidLen, CartoonFrameRate, arrMode, fontSize, color, fontBold, fontItalic, tdirection,
                        txtSpace, Valign, Halign, fontName, strAreaTxtContent, PlayImmediately, RelateProNum, RelateProSerial, stSoundData);
                }
                if (err == 0)
                {
                    MessageBox.Show("动态区更新成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //更新动态区图片
        private void btn_Dynamic_png_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
                ushort port = (ushort)num_port.Value;
                byte ScreenColor = (byte)(cmb_dynamic_Color.SelectedIndex + 1);
                byte AreaId = (byte)num_D_AreaID.Value;
                string strAreaTxtContent = txt_D_png.Text + "\0";
                string fontName = txt_D_font.Text;
                ushort AreaX = (ushort)num_D_AreaX.Value;
                ushort AreaY = (ushort)num_D_AreaY.Value;
                ushort AreaWidth = (ushort)num_D_AreaWidth.Value;
                ushort AreaHeight = (ushort)num_D_AreaHeight.Value;
                byte DisplayMode = (byte)cmb_D_DisplayMode.SelectedIndex;
                byte Speed = (byte)num_D_Speed.Value;
                ushort StayTime = (ushort)num_D_StayTime.Value;
                byte RepeatTime = (byte)num_D_RepeatTime.Value;
                ushort ValidLen = (ushort)num_D_AreaWidth.Value;
                byte CartoonFrameRate = (byte)num_D_CartoonFrameRate.Value;
                bx_sdk_dual.E_arrMode arrMode = (bx_sdk_dual.E_arrMode)(check_D_arrMode.Checked ? 0 : 1);
                ushort fontSize = (ushort)num_D_fontSize.Value;
                uint color = (uint)cmb_D_color.SelectedIndex;
                byte fontBold = (byte)(check_D_fontBold.Checked ? 1 : 0);
                byte fontItalic = (byte)(check_D_fontItalic.Checked ? 1 : 0);
                bx_sdk_dual.E_txtDirection tdirection = (bx_sdk_dual.E_txtDirection)cmb_D_txtDirection.SelectedIndex;
                ushort txtSpace = (ushort)num_D_txtSpace.Value;
                byte Valign = (byte)cmb_D_Valign.SelectedIndex;
                byte Halign = (byte)cmb_D_Halign.SelectedIndex;
                //播放优先级
                byte RunMode = (byte)cmb_D_Runmode.SelectedIndex;
                ushort Timeout = (ushort)num_D_Timeout.Value;
                byte PlayImmediately = (byte)cmb_D_PlayImmediately.SelectedIndex;
                byte RelateAllPro =1;
                ushort RelateProNum = 0;
                ushort[] RelateProSerial = new ushort[0];
                if (check_WithProgram.Checked)
                {
                    RelateAllPro = 1;
                    string[] str_Area = txt_RelateProSerial.Text.Trim().Split(',');
                    RelateProNum = (ushort)str_Area.Length;
                    RelateProSerial = new ushort[str_Area.Length];
                    for (int i = 0; i < str_Area.Length; i++)
                    {
                        RelateProSerial[i] = ushort.Parse(str_Area[i]);
                    }
                }
                else { RelateAllPro = 0;RelateProNum = 0; RelateProSerial = null; }
                if (cmb_BX_56.SelectedIndex == 0)
                {
                    bx_sdk_dual.EQareaframeHeader Frame;
                    Frame.AreaFFlag = 0;
                    Frame.AreaFDispStyle = 0;
                    Frame.AreaFDispSpeed = 0;
                    Frame.AreaFMoveStep = 0;
                    Frame.AreaFWidth = 0;
                    Frame.AreaFBackup = 0;
                    if (chk_D_AreaFFlag.Checked)
                    {
                        Frame.AreaFFlag = 1;
                        Frame.AreaFDispStyle = (byte)cmb_D_AreaFDispStyle.SelectedIndex;
                        Frame.AreaFDispSpeed = (byte)num_D_AreaFDispSpeed.Value;
                        Frame.AreaFMoveStep = (byte)num_D_AreaFMoveStep.Value;
                        Frame.AreaFWidth = (byte)num_D_AreaFWidth.Value;
                        Frame.AreaFBackup = 0;
                    }
                    err = Interface_5.dynamicAreaimg_5(ipAdder, port, ScreenColor, AreaId, RunMode, Timeout, AreaX, AreaY, AreaWidth, AreaHeight, Frame, DisplayMode, Speed,
                        StayTime, RepeatTime, strAreaTxtContent,PlayImmediately, RelateAllPro, RelateProNum, RelateProSerial);
                }
                else
                {
                    bx_sdk_dual.EQSound_6G stSoundData = new bx_sdk_dual.EQSound_6G();
                    stSoundData.SoundFlag = 0;
                    stSoundData.SoundPerson = 0;
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
                    if (check_Sound.Checked)
                    {
                        stSoundData.SoundFlag = 1;
                        stSoundData.SoundPerson = (byte)cmb_SoundPerson.SelectedIndex;
                        stSoundData.SoundVolum = (byte)cmb_SoundVolum.SelectedIndex;
                        stSoundData.SoundSpeed = (byte)cmb_SoundSpeed.SelectedIndex;
                        stSoundData.SoundDataMode = (byte)cmb_SoundDataMode.SelectedIndex;
                        if ((int)cmb_SoundReplayTimes.SelectedIndex < 15)
                        {
                            stSoundData.SoundReplayTimes = (uint)cmb_SoundReplayTimes.SelectedIndex;
                        }
                        else { stSoundData.SoundReplayTimes = 0xFFFFFFFF; }
                        stSoundData.SoundReplayDelay = (int)num_SoundReplayDelay.Value;
                        stSoundData.SoundReservedParaLen = 0x03;
                        stSoundData.Soundnumdeal = (byte)cmb_Soundnumdeal.SelectedIndex;
                        stSoundData.Soundlanguages = (byte)cmb_Soundlanguages.SelectedIndex;
                        stSoundData.Soundwordstyle = (byte)cmb_Soundwordstyle.SelectedIndex;
                        byte[] SoundAreaText = new byte[0];
                        switch (cmb_SoundDataMode.SelectedIndex)
                        {
                            case 0:
                                SoundAreaText = System.Text.Encoding.GetEncoding("GB2312").GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                            case 1:
                                SoundAreaText = System.Text.Encoding.GetEncoding("GBK").GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                            case 2:
                                SoundAreaText = System.Text.Encoding.GetEncoding("Big5").GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                            case 3:
                                SoundAreaText = System.Text.Encoding.Unicode.GetBytes(txt_SoundTxt.Text.Trim());
                                break;
                        }
                        stSoundData.SoundData = Calculation.BytesToIntptr(SoundAreaText);
                        stSoundData.SoundDataLen = SoundAreaText.Length;
                    }
                    err = Interface_6.dynamicAreaimg_6(ipAdder, port, ScreenColor, AreaId, AreaX, AreaY, AreaWidth, AreaHeight, DisplayMode, Speed, 
                        StayTime, RepeatTime, ValidLen, CartoonFrameRate, arrMode, fontSize, color, fontBold, fontItalic, tdirection,
                        txtSpace, Valign, Halign, fontName, strAreaTxtContent, PlayImmediately, RelateProNum, RelateProSerial, stSoundData);
                }
                if (err == 0)
                {
                    MessageBox.Show("动态区更新成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); } 
        }
        // 动态区添加图片文件
        private void btn_D_Addpng_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "所有支持文件|*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_D_png.Text = openFileDialog1.FileName;
            }
        }
        //删除所有动态区
        private void btn_DelAllDynamic_Click(object sender, EventArgs e)
        {
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes(txt_IP.Text);
            ushort port = (ushort)num_port.Value;
            int err = bx_sdk_dual.bxDual_dynamicArea_DelArea_5G(ipAdder, port, 0xff);
            if (err == 0)
            {
                MessageBox.Show("动态区删除成功");
            }
            else { MessageBox.Show(Calculation.GetError(err)); }
        }
        //节目添加时间内容
        private void btn_P_AreaAddTime_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                ushort areaID = (ushort)num_P_AreaID.Value;
                bx_sdk_dual.EQtimeAreaData_G56 timeData;
                timeData.linestyle = (bx_sdk_dual.E_arrMode)(check_time_linestyle.Checked ? 0 : 1);
                timeData.color = (uint)(bx_sdk_dual.E_Color_G56)cmb_time_color.SelectedIndex;
                byte[] Font = Encoding.GetEncoding("GBK").GetBytes(txt_time_fontName.Text);
                timeData.fontName = Calculation.BytesToIntptr(Font); 
                timeData.fontSize = (byte)num_time_fontSize.Value;
                timeData.fontBold = (byte)(check_time_fontBold.Checked ? 1 : 0);
                timeData.fontItalic = (byte)(check_time_fontItalic.Checked ? 1 : 0);
                timeData.fontUnderline = (byte)(check_time_fontUnderline.Checked ? 1 : 0);
                timeData.fontAlign = (byte)cmb_time_fontAlign.SelectedIndex;
                timeData.date_enable = (byte)(check_time_date_enable.Checked ? 1 : 0);
                timeData.datestyle = (bx_sdk_dual.E_DateStyle)cmb_time_DateStyle.SelectedIndex;
                timeData.time_enable = (byte)(check_time_time_enable.Checked ? 1 : 0);
                timeData.timestyle = (bx_sdk_dual.E_TimeStyle)cmb_time_TimeStyle.SelectedIndex;
                timeData.week_enable = (byte)(check_time_week_enable.Checked ? 1 : 0);
                timeData.weekstyle = (bx_sdk_dual.E_WeekStyle)(cmb_time_WeekStyle.SelectedIndex + 1);
                if (cmb_BX_56.SelectedIndex == 0)
                {
                    err = Interface_5.Creat_Addtime(areaID, timeData);
                }
                else
                {
                    err = Interface_6.Creat_Addtime(areaID, timeData);
                }
                if (err == 0)
                {
                    MessageBox.Show("节目添加时间成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        //节目添加表盘设置
        private void btn_P_Clock_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                ushort areaID = (ushort)num_P_AreaID.Value;
                bx_sdk_dual.EQAnalogClockHeader_G56 acheader;
                acheader.OrignPointX = (ushort)num_clock_OrignPointX.Value;
                acheader.OrignPointY = (ushort)num_clock_OrignPointY.Value;
                acheader.UnitMode = 0x00;
                acheader.HourHandWidth = (byte)num_HourHandWidth.Value;
                acheader.HourHandLen = (byte)num_HourHandLen.Value;
                acheader.HourHandColor = (uint)cmb_hour_color.SelectedIndex;
                acheader.MinHandWidth = (byte)num_MinHandWidth.Value;
                acheader.MinHandLen = (byte)num_MinHandLen.Value;
                acheader.MinHandColor = (uint)cmb_minute_color.SelectedIndex;
                acheader.SecHandWidth = (byte)num_SecHandWidth.Value;
                acheader.SecHandLen = (byte)num_SecHandLen.Value;
                acheader.SecHandColor = (uint)cmb_second_color.SelectedIndex;
                bx_sdk_dual.ClockColor_G56 ClockColor;
                ClockColor.Color369 = (uint)btn_Color369.BackColor.ToArgb();
                ClockColor.ColorDot = (uint)btn_ColorDot.BackColor.ToArgb();
                ClockColor.ColorBG = (uint)btn_ColorBG.BackColor.ToArgb();
                int ClockStyle = cmb_ClockStyle.SelectedIndex;
                if (cmb_BX_56.SelectedIndex == 0)
                {
                    err = Interface_5.Creat_AddClock(areaID, acheader, ClockStyle,ClockColor);
                }
                else
                {
                    err = Interface_6.Creat_AddClock(areaID, acheader,ClockStyle, ClockColor);
                }
                if (err == 0)
                {
                    MessageBox.Show("节目添加表盘成功");
                }
                else { MessageBox.Show(Calculation.GetError(err)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void btn_Color369_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            if (col.ShowDialog() == DialogResult.OK)
            {
                btn_Color369.BackColor = col.Color;
            }
        }

        private void btn_ColorDot_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            if (col.ShowDialog() == DialogResult.OK)
            {
                btn_ColorDot.BackColor = col.Color;
            }
        }

        private void btn_ColorBG_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            if (col.ShowDialog() == DialogResult.OK)
            {
                btn_ColorBG.BackColor = col.Color;
            }
        }
        

    }
}
