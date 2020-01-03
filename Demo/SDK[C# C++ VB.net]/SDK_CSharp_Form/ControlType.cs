using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDK_CSharp_Form
{
    public class ControlType
    {
        // 控制器类型
        private const ushort BX_5AT = 0x0051;
        private const ushort BX_5A0 = 0x0151;
        private const ushort BX_5A1 = 0x0251;
        private const ushort BX_5A2 = 0x0351;
        private const ushort BX_5A3 = 0x0451;
        private const ushort BX_5A4 = 0x0551;
        private const ushort BX_5A1_WIFI = 0x0651;
        private const ushort BX_5A2_WIFI = 0x0751;
        private const ushort BX_5A4_WIFI = 0x0851;
        private const ushort BX_5A = 0x0951;
        private const ushort BX_5A2_RF = 0x1351;
        private const ushort BX_5A4_RF = 0x1551;
        private const ushort BX_5AT_WIFI = 0x1651;
        private const ushort BX_5AL = 0x1851;

        private const ushort AX_AT = 0x2051;
        private const ushort AX_A0 = 0x2151;

        private const ushort BX_5MT = 0x0552;
        private const ushort BX_5M1 = 0x0052;
        private const ushort BX_5M1X = 0x0152;
        private const ushort BX_5M2 = 0x0252;
        private const ushort BX_5M3 = 0x0352;
        private const ushort BX_5M4 = 0x0452;

        private const ushort BX_5E1 = 0x0154;
        private const ushort BX_5E2 = 0x0254;
        private const ushort BX_5E3 = 0x0354;

        private const ushort BX_5UT = 0x0055;
        private const ushort BX_5U0 = 0x0155;
        private const ushort BX_5U1 = 0x0255;
        private const ushort BX_5U2 = 0x0355;
        private const ushort BX_5U3 = 0x0455;
        private const ushort BX_5U4 = 0x0555;
        private const ushort BX_5U5 = 0x0655;
        private const ushort BX_5U = 0x0755;
        private const ushort BX_5UL = 0x0855;

        private const ushort AX_UL = 0x2055;
        private const ushort AX_UT = 0x2155;
        private const ushort AX_U0 = 0x2255;
        private const ushort AX_U1 = 0x2355;
        private const ushort AX_U2 = 0x2455;

        private const ushort BX_5Q0 = 0x0056;
        private const ushort BX_5Q1 = 0x0156;
        private const ushort BX_5Q2 = 0x0256;
        private const ushort BX_5Q0P = 0x1056;
        private const ushort BX_5Q1P = 0x1156;
        private const ushort BX_5Q2P = 0x1256;
        private const ushort BX_5QL = 0x1356;

        private const ushort BX_5QS1 = 0x0157;
        private const ushort BX_5QS2 = 0x0257;
        private const ushort BX_5QS = 0x0357;
        private const ushort BX_5QS1P = 0x1157;
        private const ushort BX_5QS2P = 0x1257;
        private const ushort BX_5QSP = 0x1357;

        private const ushort BX_6M0 = 0x0062;
        private const ushort BX_6M1 = 0x0162;
        private const ushort BX_6M2 = 0x0262;
        private const ushort BX_6M3 = 0x0362;
        private const ushort BX_6M = 0x0462;
        private const ushort BX_6MT = 0x0562;

        private const ushort BX_6M0_YY = 0x1062;
        private const ushort BX_6M1_YY = 0x1162;
        private const ushort BX_6M2_YY = 0x1262;
        private const ushort BX_6M3_YY = 0x1362;
        private const ushort BX_6M_YY = 0x1462;

        private const ushort BX_6X1 = 0x2162;
        private const ushort BX_6X2 = 0x2262;
        private const ushort BX_6X3 = 0x2362;

        private const ushort BX_6U0 = 0x0063;
        private const ushort BX_6U1 = 0x0163;
        private const ushort BX_6U2 = 0x0263;
        private const ushort BX_6U3 = 0x0363;
        private const ushort BX_6U = 0x0463;
        private const ushort BX_6UT = 0x0563;

        private const ushort BX_6U0_YY = 0x1063;
        private const ushort BX_6U1_YY = 0x1163;
        private const ushort BX_6U2_YY = 0x1263;
        private const ushort BX_6U3_YY = 0x1363;
        private const ushort BX_6U_YY = 0x1463;

        private const ushort BX_6A0 = 0x2063;
        private const ushort BX_6A1 = 0x2163;
        private const ushort BX_6A2 = 0x2263;
        private const ushort BX_6A3 = 0x2363;
        private const ushort BX_6A = 0x2463;

        private const ushort BX_6A0_YY = 0x3063;
        private const ushort BX_6A1_YY = 0x3163;
        private const ushort BX_6A2_YY = 0x3263;
        private const ushort BX_6A3_YY = 0x3363;
        private const ushort BX_6A_YY = 0x3463;

        private const ushort BX_6A0_G = 0x4063;
        private const ushort BX_6A1_G = 0x4163;
        private const ushort BX_6A2_G = 0x4263;
        private const ushort BX_6A3_G = 0x4363;
        private const ushort BX_6AT_G = 0x4463;

        private const ushort BX_6S1 = 0x5163;
        private const ushort BX_6S2 = 0x5263;
        private const ushort BX_6S3 = 0x5363;

        private const ushort BX_6W0 = 0x0064;
        private const ushort BX_6W1 = 0x0164;
        private const ushort BX_6W2 = 0x0264;
        private const ushort BX_6W3 = 0x0364;
        private const ushort BX_6W = 0x0464;
        private const ushort BX_6WT = 0x0564;

        private const ushort BX_6E1 = 0x0174;
        private const ushort BX_6E2 = 0x0274;
        private const ushort BX_6E3 = 0x0374;
        private const ushort BX_6E1X = 0x0474;
        private const ushort BX_6E2X = 0x0574;

        private const ushort BX_6Q1 = 0x0166;
        private const ushort BX_6Q2 = 0x0266;
        private const ushort BX_6Q2L = 0x0466;
        private const ushort BX_6Q3 = 0x0366;
        private const ushort BX_6Q3L = 0x0566;

        public static ushort[] controlType = new ushort[111] { BX_5AT, BX_5A0, BX_5A1, BX_5A2, BX_5A3, BX_5A4, BX_5A1_WIFI, BX_5A2_WIFI,BX_5A4_WIFI,BX_5A,
                                        BX_5A2_RF,BX_5A4_RF,BX_5AT_WIFI,BX_5AL,AX_AT,AX_A0,BX_5MT,BX_5M1,BX_5M1X,BX_5M2,BX_5M3,BX_5M4,
                                        BX_5E1,BX_5E2,BX_5E3,BX_5UT,BX_5U0,BX_5U1,BX_5U2,BX_5U3,BX_5U4,BX_5U5,BX_5U,BX_5UL,
                                        AX_UL,AX_UT,AX_U0,AX_U1,AX_U2,BX_5Q0,BX_5Q1,BX_5Q2,BX_5Q0P,BX_5Q1P,BX_5Q2P,BX_5QL,BX_5QS1,
                                        BX_5QS2,BX_5QS,BX_5QS1P,BX_5QS2P,BX_5QSP,
                                        BX_6M0,BX_6M1,BX_6M2,BX_6M3,BX_6M,BX_6MT,BX_6M0_YY,BX_6M1_YY,BX_6M2_YY,BX_6M3_YY,BX_6M_YY,BX_6X1,BX_6X2,BX_6X3,
                                        BX_6U0,BX_6U1,BX_6U2,BX_6U3,BX_6U,BX_6UT,BX_6U0_YY,BX_6U1_YY,BX_6U2_YY,BX_6U3_YY,BX_6U_YY,
                                        BX_6A0,BX_6A1,BX_6A2,BX_6A3,BX_6A,BX_6A0_YY,BX_6A1_YY,BX_6A2_YY,BX_6A3_YY,BX_6A_YY,BX_6A0_G,BX_6A1_G,BX_6A2_G,BX_6A3_G,BX_6AT_G,
                                        BX_6S1,BX_6S2,BX_6S3,BX_6W0,BX_6W1,BX_6W2,BX_6W3,BX_6W,BX_6WT,
                                        BX_6E1,BX_6E2,BX_6E3,BX_6E1X,BX_6E2X,BX_6Q1,BX_6Q2,BX_6Q2L,BX_6Q3,BX_6Q3L};
    }
}