using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BTWrapper
{
    class SmoothData
    {
        double[] data = new double[10];
        //コンストラクタ
        SmoothData()
        {

        }
        //インデクサ
        public double this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        //各値
        public double ReadModeXmu
        {
            get { return data[0]; }
            set { data[0] = value; }
        }
        //1～4謎
        public double PolynomialOrder
        {
            get { return data[5]; }
            set { data[5] = value; }
        }
        public double Energy0
        {
            get { return data[6]; }
            set { data[6] = value; }
        }
        public double StartK
        {
            get { return data[7]; }
            set { data[7] = value; }
        }
        public double EndK
        {
            get { return data[8]; }
            set { data[8] = value; }
        }
        //9謎
    }
    class BTinpData
    {
        string line1;

        string[] line2 = new string[17];
        #region line2params_property
        public string L2P1_itermax
        {
            get { return line2[0]; }
            set { line2[0] = value; }
        }
        public string L2P2_mxpath
        {
            get { return line2[1]; }
            set { line2[1] = value; }
        }
        public string L2P3_mxspath
        {
            get { return line2[2]; }
            set { line2[2] = value; }
        }
        public string L2P4_c3path
        {
            get { return line2[3]; }
            set { line2[3] = value; }
        }
        public string L2P5_kni
        {
            get { return line2[4]; }
            set { line2[4] = value; }
        }
        public string L2P6_ircorr
        {
            get { return line2[5]; }
            set { line2[5] = value; }
        }
        public string L2P7_itrunc
        {
            get { return line2[6]; }
            set { line2[6] = value; }
        }
        public string L2P8_inpex
        {
            get { return line2[7]; }
            set { line2[7] = value; }
        }
        public string L2P9_minxq
        {
            get { return line2[8]; }
            set { line2[8] = value; }
        }
        public string L2P10_malphopt
        {
            get { return line2[9]; }
            set { line2[9] = value; }
        }
        public string L2P11_n0bkg
        {
            get { return line2[10]; }
            set { line2[10] = value; }
        }
        public string L2P12_ipbkg
        {
            get { return line2[11]; }
            set { line2[11] = value; }
        }
        public string L2P13_iamatc
        {
            get { return line2[12]; }
            set { line2[12] = value; }
        }
        public string L2P14_nord
        {
            get { return line2[13]; }
            set { line2[13] = value; }
        }
        public string L2P15_ircfct
        {
            get { return line2[14]; }
            set { line2[14] = value; }
        }
        public string L2P16_iboot
        {
            get { return line2[15]; }
            set { line2[15] = value; }
        }
        public string L2P17_lalph
        {
            get { return line2[16]; }
            set { line2[16] = value; }
        }
        #endregion
        string[] line3 = new string[8];
        #region line3params_property
        public string L3P1_bkgw
        {
            get { return line3[0]; }
            set { line3[0] = value; }
        }
        public string L3P2_dels02
        {
            get { return line3[1]; }
            set { line3[1] = value; }
        }
        public string L3P3_dele0
        {
            get { return line3[2]; }
            set { line3[2] = value; }
        }
        public string L3P4_delrp
        {
            get { return line3[3]; }
            set { line3[3] = value; }
        }
        public string L3P5_delsp
        {
            get { return line3[4]; }
            set { line3[4] = value; }
        }
        public string L3P6_delc3
        {
            get { return line3[5]; }
            set { line3[5] = value; }
        }
        public string L3P7_deldg
        {
            get { return line3[6]; }
            set { line3[6] = value; }
        }
        public string L3P8_delstd
        {
            get { return line3[7]; }
            set { line3[7] = value; }
        }
        #endregion
        string[] line4 = new string[9];
        #region line4params_property
        public string L4P1_q_min
        {
            get { return line4[0]; }
            set { line4[0] = value; }
        }
        public string L4P2_errxla
        {
            get { return line4[1]; }
            set { line4[1] = value; }
        }
        public string L4P3_erramp
        {
            get { return line4[2]; }
            set { line4[2] = value; }
        }
        public string L4P4_errpha
        {
            get { return line4[3]; }
            set { line4[3] = value; }
        }
        public string L4P5_errrad
        {
            get { return line4[4]; }
            set { line4[4] = value; }
        }
        public string L4P6_errsig
        {
            get { return line4[5]; }
            set { line4[5] = value; }
        }
        public string L4P7_cstd
        {
            get { return line4[6]; }
            set { line4[6] = value; }
        }
        public string L4P8_S02
        {
            get { return line4[7]; }
            set { line4[7] = value; }
        }
        public string L4P9_E0
        {
            get { return line4[8]; }
            set { line4[8] = value; }
        }
        #endregion
        string[] line5 = new string[14];
        #region line5params_property
        public string L5P1_errexp
        {
            get { return line5[0]; }
            set { line5[0] = value; }
        }
        public string L5P2_erre1
        {
            get { return line5[1]; }
            set { line5[1] = value; }
        }
        public string L5P3_erre2
        {
            get { return line5[2]; }
            set { line5[2] = value; }
        }
        public string L5P4_erre3
        {
            get { return line5[3]; }
            set { line5[3] = value; }
        }
        public string L5P5_erre4
        {
            get { return line5[4]; }
            set { line5[4] = value; }
        }
        public string L5P6_erre5
        {
            get { return line5[5]; }
            set { line5[5] = value; }
        }
        public string L5P7_erre6
        {
            get { return line5[6]; }
            set { line5[6] = value; }
        }
        public string L5P8_errexk1
        {
            get { return line5[7]; }
            set { line5[7] = value; }
        }
        public string L5P9_errexk2
        {
            get { return line5[8]; }
            set { line5[8] = value; }
        }
        public string L5P10_errexk3
        {
            get { return line5[9]; }
            set { line5[9] = value; }
        }
        public string L5P11_errexk4
        {
            get { return line5[10]; }
            set { line5[10] = value; }
        }
        public string L5P12_errexk5
        {
            get { return line5[11]; }
            set { line5[11] = value; }
        }
        public string L5P13_errexk6
        {
            get { return line5[12]; }
            set { line5[12] = value; }
        }
        public string L5P14_errf56
        {
            get { return line5[13]; }
            set { line5[13] = value; }
        }
        #endregion
        string[] line6 = new string[17];
        #region line6params_property
        public string L6P1_nfed
        {
            get { return line6[0]; }
            set { line6[0] = value; }
        }
        public string L6P2_ifed
        {
            get { return line6[1]; }
            set { line6[1] = value; }
        }
        public string L6P3_fedt
        {
            get { return line6[2]; }
            set { line6[2] = value; }
        }
        public string L6P4_fedf1
        {
            get { return line6[3]; }
            set { line6[3] = value; }
        }
        public string L6P5_fedf2
        {
            get { return line6[4]; }
            set { line6[4] = value; }
        }
        public string L6P6_fedf3
        {
            get { return line6[5]; }
            set { line6[5] = value; }
        }
        public string L6P7_fedf4
        {
            get { return line6[6]; }
            set { line6[6] = value; }
        }
        public string L6P8_delfed1
        {
            get { return line6[7]; }
            set { line6[7] = value; }
        }
        public string L6P9_delfed2
        {
            get { return line6[8]; }
            set { line6[8] = value; }
        }
        public string L6P10_delfed3
        {
            get { return line6[9]; }
            set { line6[9] = value; }
        }
        public string L6P11_delfed4
        {
            get { return line6[10]; }
            set { line6[10] = value; }
        }
        public string L6P12_debt
        {
            get { return line6[11]; }
            set { line6[11] = value; }
        }
        public string L6P13_deldebt
        {
            get { return line6[12]; }
            set { line6[12] = value; }
        }
        public string L6P14_rsh1
        {
            get { return line6[13]; }
            set { line6[13] = value; }
        }
        public string L6P15_rsh2
        {
            get { return line6[14]; }
            set { line6[14] = value; }
        }
        public string L6P16_rsh3
        {
            get { return line6[15]; }
            set { line6[15] = value; }
        }
        public string L6P17_o2m
        {
            get { return line6[16]; }
            set { line6[16] = value; }
        }
        #endregion
        string[] line6a = new string[9];
        string[] line7 = new string[8];
        #region line7params_property
        public string L7P1_mum
        {
            get { return line7[0]; }
            set { line7[0] = value; }
        }
        public string L7P2_ism
        {
            get { return line7[1]; }
            set { line7[1] = value; }
        }
        public string L7P3_e0l1
        {
            get { return line7[2]; }
            set { line7[2] = value; }
        }
        public string L7P4_e0l2
        {
            get { return line7[3]; }
            set { line7[3] = value; }
        }
        public string L7P5_e0l3
        {
            get { return line7[4]; }
            set { line7[4] = value; }
        }
        public string L7P6_osca
        {
            get { return line7[5]; }
            set { line7[5] = value; }
        }
        public string L7P7_oscr
        {
            get { return line7[6]; }
            set { line7[6] = value; }
        }
        public string L7P8_oscs
        {
            get { return line7[7]; }
            set { line7[7] = value; }
        }
        #endregion
        string[] line8 = new string[9];

        public string[] Line8
        {
            get { return line8; }
            set { line8 = value; }
        }
        #region line8params_property
        public string L8P1_ifilt
        {
            get { return line8[0]; }
            set { line8[0] = value; }
        }
        public string L8P2_qwin
        {
            get { return line8[1]; }
            set { line8[1] = value; }
        }
        public string L8P3_rwin
        {
            get { return line8[2]; }
            set { line8[2] = value; }
        }
        public string L8P4_qwin1
        {
            get { return line8[3]; }
            set { line8[3] = value; }
        }
        public string L8P5_qwin2
        {
            get { return line8[4]; }
            set { line8[4] = value; }
        }
        public string L8P6_rwin1
        {
            get { return line8[5]; }
            set { line8[5] = value; }
        }
        public string L8P7_rwin2
        {
            get { return line8[6]; }
            set { line8[6] = value; }
        }
        public string L8P8_nqfft
        {
            get { return line8[7]; }
            set { line8[7] = value; }
        }
        public string L8P9_ftrm
        {
            get { return line8[8]; }
            set { line8[8] = value; }
        }
        #endregion
        List<string> line9 = new List<string>();
        public List<string> Line9
        {
            get { return line9; }
            set { line9 = value; }
        }
        List<string> line10 = new List<string>();
        public List<string> Line10
        {
            get { return line10; }
            set { line10 = value; }
        }
        List<string> line11 = new List<string>();
        public List<string> Line11
        {
            get { return line11; }
            set { line11 = value; }
        }
        string[] line12 = new string[2];
        public string L12P1_mix
        {
            get { return line12[0]; }
            set { line12[0] = value; }
        }
        public string L12P2_mixdir
        {
            get { return line12[1]; }
            set { line12[1] = value; }
        }

        public void SaveFile(string file)
        {
            //各パラメータがintで出力かdouble(デフォルト)で出力か
            bool[] paramoutput_int = new bool[
                line2.GetLength(0) + line3.GetLength(0) + line4.GetLength(0) + line5.GetLength(0)
              + line6.GetLength(0) + line7.GetLength(0) + line8.GetLength(0) + line9.Count
              + line10.Count + line11.Count + line12.GetLength(0)];


            using (StreamWriter sw = new StreamWriter(file, false, BTMainForm.CharEncode))
            {
                //  for(int i=0;i<line2.GetLength(
            }
        }

    }
}