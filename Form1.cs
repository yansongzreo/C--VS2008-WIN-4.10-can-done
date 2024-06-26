﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

/*------------兼容ZLG的数据类型---------------------------------*/

//1.ZLGCAN系列接口卡信息的数据类型。
public struct VCI_BOARD_INFO 
{ 
	public UInt16 hw_Version;
    public UInt16 fw_Version;
    public UInt16 dr_Version;
    public UInt16 in_Version;
    public UInt16 irq_Num;
    public byte   can_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst=20)] public byte []str_Serial_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public byte[] str_hw_Type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] Reserved;
}

/////////////////////////////////////////////////////
//2.定义CAN信息帧的数据类型。
unsafe public struct VCI_CAN_OBJ  //使用不安全代码
{
    public uint ID;
    public uint TimeStamp;        //时间标识
    public byte TimeFlag;         //是否使用时间标识
    public byte SendType;         //发送标志。保留，未用
    public byte RemoteFlag;       //是否是远程帧
    public byte ExternFlag;       //是否是扩展帧
    public byte DataLen;          //数据长度
    public fixed byte Data[8];    //数据
    public fixed byte Reserved[3];//保留位

}

//3.定义初始化CAN的数据类型
public struct VCI_INIT_CONFIG 
{
    public UInt32 AccCode;
    public UInt32 AccMask;
    public UInt32 Reserved;
    public byte Filter;   //0或1接收所有帧。2标准帧滤波，3是扩展帧滤波。
    public byte Timing0;  //波特率参数，具体配置，请查看二次开发库函数说明书。
    public byte Timing1;
    public byte Mode;     //模式，0表示正常模式，1表示只听模式,2自测模式
}

/*------------其他数据结构描述---------------------------------*/
//4.USB-CAN总线适配器板卡信息的数据类型1，该类型为VCI_FindUsbDevice函数的返回参数。
public struct VCI_BOARD_INFO1
{
    public UInt16 hw_Version;
    public UInt16 fw_Version;
    public UInt16 dr_Version;
    public UInt16 in_Version;
    public UInt16 irq_Num;
    public byte can_Num;
    public byte Reserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)] public byte []str_Serial_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] str_hw_Type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] str_Usb_Serial;
}

/*------------数据结构描述完成---------------------------------*/

public struct CHGDESIPANDPORT 
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public byte[] szpwd;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public byte[] szdesip;
    public Int32 desport;

    public void Init()
    {
        szpwd = new byte[10];
        szdesip = new byte[20];
    }
}


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        const int DEV_USBCAN = 3;
        const int DEV_USBCAN2 = 4;
         /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="Reserved"></param>
        /// <returns></returns>
        /*------------兼容ZLG的函数描述---------------------------------*/
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_OpenDevice(UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_InitCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ClearBuffer(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_StartCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ResetCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pReceive, UInt32 Len, Int32 WaitTime);
        
        /*------------其他函数描述---------------------------------*/

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ConnectDevice(UInt32 DevType,UInt32 DevIndex);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_UsbDeviceReset(UInt32 DevType,UInt32 DevIndex,UInt32 Reserved);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_FindUsbDevice(ref VCI_BOARD_INFO1 pInfo);
        /*------------函数描述结束---------------------------------*/

        static UInt32 m_devtype = 4;//USBCAN2

        UInt32 m_bOpen = 0;
        UInt32 m_devind = 0;
        UInt32 m_canind = 0;

        VCI_CAN_OBJ[] m_recobj = new VCI_CAN_OBJ[1000];

        UInt32[] m_arrdevtype = new UInt32[20];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_DevIndex.SelectedIndex = 0;
            comboBox_CANIndex.SelectedIndex = 0;
            textBox_AccCode.Text = "00000000";
            textBox_AccMask.Text = "FFFFFFFF";
            textBox_Time0.Text = "00";
            textBox_Time1.Text = "14";
            comboBox_Filter.SelectedIndex = 0;              //接收所有类型
            comboBox_Mode.SelectedIndex = 0;                //还回测试模式
            comboBox_FrameFormat.SelectedIndex = 0;
            comboBox_FrameType.SelectedIndex = 0;
            textBox_ID.Text = "00000001";
            textBox_Data.Text = "00 01 02 03 04 05 06 07 ";

            //
            Int32 curindex = 0;
            comboBox_devtype.Items.Clear();

            curindex = comboBox_devtype.Items.Add("DEV_USBCAN");
            m_arrdevtype[curindex] =  DEV_USBCAN;
            //comboBox_devtype.Items[2] = "VCI_USBCAN1";
            //m_arrdevtype[2]=  VCI_USBCAN1 ;

            curindex = comboBox_devtype.Items.Add("DEV_USBCAN2");
            m_arrdevtype[curindex] = DEV_USBCAN2 ;
            //comboBox_devtype.Items[3] = "VCI_USBCAN2";
            //m_arrdevtype[3]=  VCI_USBCAN2 ;

             comboBox_devtype.SelectedIndex = 1;
            comboBox_devtype.MaxDropDownItems = comboBox_devtype.Items.Count;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bOpen==1)
            {
                VCI_CloseDevice(m_devtype, m_devind);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (m_bOpen==1)
            {
                VCI_CloseDevice(m_devtype, m_devind);
                m_bOpen = 0;
            }
            else
            {
                m_devtype = m_arrdevtype[comboBox_devtype.SelectedIndex];

                m_devind=(UInt32)comboBox_DevIndex.SelectedIndex;
                m_canind = (UInt32)comboBox_CANIndex.SelectedIndex;
                if (VCI_OpenDevice(m_devtype, m_devind, 0) == 0)
                {
                    MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                m_bOpen = 1;
                VCI_INIT_CONFIG config=new VCI_INIT_CONFIG();
                config.AccCode=System.Convert.ToUInt32("0x" + textBox_AccCode.Text,16);
                config.AccMask = System.Convert.ToUInt32("0x" + textBox_AccMask.Text, 16);
                config.Timing0 = System.Convert.ToByte("0x" + textBox_Time0.Text, 16);
                config.Timing1 = System.Convert.ToByte("0x" + textBox_Time1.Text, 16);
                config.Filter = (Byte)(comboBox_Filter.SelectedIndex+1);
                config.Mode = (Byte)comboBox_Mode.SelectedIndex;
                VCI_InitCAN(m_devtype, m_devind, m_canind, ref config);
            }
            buttonConnect.Text = m_bOpen==1?"断开":"连接";
            timer_rec.Enabled = m_bOpen==1?true:false;
        }

        unsafe private void timer_rec_Tick(object sender, EventArgs e)
        {
            UInt32 res = new UInt32();

            res = VCI_Receive(m_devtype, m_devind, m_canind, ref m_recobj[0],1000, 100);

            /////////////////////////////////////
            //IntPtr[] ptArray = new IntPtr[1];
            //ptArray[0] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * 50);
            //IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * 1);

            //Marshal.Copy(ptArray, 0, pt, 1);


            //res = VCI_Receive(m_devtype, m_devind, m_canind, pt, 50/*50*/, 100);
            ////////////////////////////////////////////////////////
            if (res == 0xFFFFF) res = 0;//当设备未初始化时，返回0xFFFFFFFF，不进行列表显示。
            String str = "";
            for (UInt32 i = 0; i < res; i++)
            {
                //VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));

                str = "接收到数据: ";
                str += "  帧ID:0x" + System.Convert.ToString(m_recobj[i].ID, 16);
                str += "  帧格式:";
                if (m_recobj[i].RemoteFlag == 0)
                    str += "数据帧 ";
                else
                    str += "远程帧 ";
                if (m_recobj[i].ExternFlag == 0)
                    str += "标准帧 ";
                else
                    str += "扩展帧 ";

                //////////////////////////////////////////
                if (m_recobj[i].RemoteFlag == 0)
                {
                    str += "数据: ";
                    byte len = (byte)(m_recobj[i].DataLen % 9);
                    byte j = 0;
                    fixed (VCI_CAN_OBJ* m_recobj1 = &m_recobj[i])
                    {
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[0], 16);
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[1], 16);
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[2], 16);
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[3], 16);
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[4], 16);
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[5], 16);
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[6], 16);
                        if (j++ < len)
                            str += " " + System.Convert.ToString(m_recobj1->Data[7], 16);
                    }
                }

                listBox_Info.Items.Add(str);
                listBox_Info.SelectedIndex = listBox_Info.Items.Count - 1;
            }
            //Marshal.FreeHGlobal(ptArray[0]);
            //Marshal.FreeHGlobal(pt);
        }

        private void button_StartCAN_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;
            VCI_StartCAN(m_devtype, m_devind, m_canind);
        }

        private void button_StopCAN_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;
            VCI_ResetCAN(m_devtype, m_devind, m_canind);
        }

        unsafe private void button_Send_Click(object sender, EventArgs e)
        {
            if(m_bOpen==0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = (byte)comboBox_FrameFormat.SelectedIndex;
            sendobj.ExternFlag = (byte)comboBox_FrameType.SelectedIndex;
            sendobj.ID = System.Convert.ToUInt32("0x"+textBox_ID.Text,16);
            int len = (textBox_Data.Text.Length+1) / 3;
            sendobj.DataLen =System.Convert.ToByte(len);
            String strdata = textBox_Data.Text;
            int i=-1;
            if(i++<len-1)
                sendobj.Data[0]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[1]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[2]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[3]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[4]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[5]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[6]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[7] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if(VCI_Transmit(m_devtype,m_devind,m_canind,ref sendobj,1)==0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            listBox_Info.Items.Clear();
        }

        unsafe private void button_Stop_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 1;
            String strdata = "02 ";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void button2_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 5;
            String strdata = "1d ff 00 00 00";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void button3_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 1;
            String strdata = "06 ";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

         unsafe private void button1_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 1;
            String strdata = "03 ";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

         unsafe private void button4_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "04 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button5_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "08 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button6_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "10 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button7_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "11 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button8_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "33 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button11_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "12 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button10_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "34 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button9_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "13 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button12_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "14 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button19_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "1B ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button18_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "35 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button17_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "36 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button16_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "16 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button15_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "17 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button14_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "18 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button13_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "19 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button20_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "1A ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

         unsafe private void button22_Click(object sender, EventArgs e)
         {
             if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "31 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

        unsafe private void button21_Click(object sender, EventArgs e)
        {
        if (m_bOpen == 0)
                 return;

             VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
             //sendobj.Init();
             sendobj.RemoteFlag = 0;
             sendobj.ExternFlag = 0;
             sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
             int len = (textBox_Data.Text.Length + 1) / 3;
             sendobj.DataLen = 1;
             String strdata = "32 ";
             int i = -1;
             if (i++ < len - 1)
                 sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

             if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
             {
                 MessageBox.Show("发送失败", "错误",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }

        unsafe private void button23_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 5;
            String strdata = "43 ff 00 00 00";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void button25_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 5;
            String strdata = "1c 00 20 00 00";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void button24_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 5;
            String strdata = "42 05 05 00 00";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void button27_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 5;
            String strdata = "1e 10 00 00 00";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void button26_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 5;
            String strdata = "44 05 05 00 00";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            if (i++ < len - 1)
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void button28_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.RemoteFlag = 0;
            sendobj.ExternFlag = 0;
            sendobj.ID = System.Convert.ToUInt32("0x" + "1", 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = 1;
            String strdata = "09 ";
            int i = -1;
            if (i++ < len - 1)
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if (VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        }
         }