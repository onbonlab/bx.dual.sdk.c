using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDK_CSharp_Form
{
    public partial class SOUND : Form
    {
        public SOUND()
        {
            InitializeComponent();
            cmb_SoundPerson.SelectedIndex = 0;
            cmb_SoundVolum.SelectedIndex = 1;
            cmb_SoundSpeed.SelectedIndex = 2;
            cmb_SoundDataMode.SelectedIndex = 0;
            cmb_SoundReplayTimes.SelectedIndex = 0;
            cmb_Soundnumdeal.SelectedIndex = 0;
            cmb_Soundlanguages.SelectedIndex = 0;
            cmb_Soundwordstyle.SelectedIndex = 0;
        }

        public static byte[] SoundAreaText;
        public static bx_sdk_dual.EQSoundDepend_6G InstSoundData;
        private void button1_Click(object sender, EventArgs e)
        {
            InstSoundData.VoiceID = (byte)num_VoiceID.Value;
            InstSoundData.stSound.SoundFlag = 0x01;
            InstSoundData.stSound.SoundPerson = (byte)cmb_SoundPerson.SelectedIndex;
            InstSoundData.stSound.SoundVolum = (byte)cmb_SoundVolum.SelectedIndex;
            InstSoundData.stSound.SoundSpeed = (byte)cmb_SoundSpeed.SelectedIndex;
            InstSoundData.stSound.SoundDataMode = (byte)cmb_SoundDataMode.SelectedIndex;
            if ((int)cmb_SoundReplayTimes.SelectedIndex < 15)
            {
                InstSoundData.stSound.SoundReplayTimes = (uint)cmb_SoundReplayTimes.SelectedIndex;
            }
            else { InstSoundData.stSound.SoundReplayTimes = 0xFFFFFFFF; }
            InstSoundData.stSound.SoundReplayDelay = (int)num_SoundReplayDelay.Value;	
            InstSoundData.stSound.SoundReservedParaLen = 0x03;
            InstSoundData.stSound.Soundnumdeal = (byte)cmb_Soundnumdeal.SelectedIndex;		
            InstSoundData.stSound.Soundlanguages = (byte)cmb_Soundlanguages.SelectedIndex;
            InstSoundData.stSound.Soundwordstyle = (byte)cmb_Soundwordstyle.SelectedIndex;
            switch (cmb_SoundDataMode.SelectedIndex)
            {
                case 0:
                    SoundAreaText = System.Text.Encoding.GetEncoding("GB2312").GetBytes(txt_SoundText.Text.Trim());
                    break;
                case 1:
                    SoundAreaText = System.Text.Encoding.GetEncoding("GBK").GetBytes(txt_SoundText.Text.Trim());
                    break;
                case 2:
                    SoundAreaText = System.Text.Encoding.GetEncoding("Big5").GetBytes(txt_SoundText.Text.Trim());
                    break;
                case 3:
                    SoundAreaText = System.Text.Encoding.Unicode.GetBytes(txt_SoundText.Text.Trim());
                    break;
            }
            InstSoundData.stSound.SoundData = Calculation.BytesToIntptr(SoundAreaText);
            InstSoundData.stSound.SoundDataLen = SoundAreaText.Length;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
