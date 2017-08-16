using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using Aspose.Cells;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace PinCtrl
{

    public partial class MainForm : Form
    {
        [DllImport("AnalyzerCtrl.dll", EntryPoint = "OpenAnalyzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool OpenAnalyzer(string DevName, int DevNo);
        [DllImport("AnalyzerCtrl.dll", EntryPoint = "CloseAnalyzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAnalyzer(int DevNo);
        [DllImport("AnalyzerCtrl.dll", EntryPoint = "GetBandPower", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetBandPower();
        [DllImport("AnalyzerCtrl.dll", EntryPoint = "SetAnalyzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetAnalyzer(float fFreq, int iSpan, int iAmptdYS,float fMark, int iBandSpan, int iAveNum);//G和M无需转换
        [DllImport("AnalyzerCtrl.dll", EntryPoint = "GetBandWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetBandWidth();
        [DllImport("AnalyzerCtrl.dll", EntryPoint = "ExecOrder_ANA", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExecOrder_ANA(String Order);
        [DllImport("AnalyzerCtrl.dll", EntryPoint = "IsOpened", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsOpened();
        private SerialPort comm = new SerialPort();
        
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        public Semaphore SemaphoreParsePackage = new Semaphore(100, 100);
        public double g_dNowLocation = 0;//当前角度
        public double g_dBandPower = 0;//功率值
        public double g_dBandWidth = 0;//带宽
        bool IsGetLocation = false;//是否已获取到角度
        //bool IsGetBandPower = false;
        //Thread th_getAnaly = null;
        //Thread th_getLocationCor = null;
        public int g_iTimerCount = 0;
        public double g_dWithTime = 0.0;
        public int g_iFirstC = 0;
        public MainForm()
        {
            InitializeComponent();      
        }
        static uint[] crctab =  
        {
	        0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7,
	        0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF,
	        0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6,
	        0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE,
	        0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485,
	        0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
	        0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4,
	        0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC,
	        0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 0x2802, 0x3823,
	        0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
	        0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0x0A50, 0x3A33, 0x2A12,
	        0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
	        0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41,
	        0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
	        0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70,
	        0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78,
	        0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F,
	        0x1080, 0x00A1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
	        0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E,
	        0x02B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
	        0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
	        0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
	        0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 0xC71D, 0xD73C,
	        0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
	        0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB,
	        0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3,
	        0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A,
	        0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92,
	        0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9,
	        0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
	        0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8,
	        0x6E17, 0x7E36, 0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
        };

        /* CRC  高位字节值表 */
        static Byte[] auchCRCHi = { 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 
	        0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 
	        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 
	        0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 
	        0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 
	        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 
	        0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 
	        0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 
	        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 
	        0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 
	        0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 
	        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 
	        0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 
	        0x40 
        };
        /* CRC 低位字节值表*/
        static Byte[] auchCRCLo = { 
	        0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4, 
	        0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 
	        0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 
	        0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3, 
	        0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7, 
	        0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 
	        0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 
	        0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26, 
	        0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2, 
	        0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 
	        0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 
	        0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5, 
	        0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
	        0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 
	        0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 
	        0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C, 
	        0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80, 
	        0x40 
        };
        //XCRC校验算法
        public ushort XCRC(byte[] pMsg, ushort sLen)
        {
            ushort l_u16CRC;
            
            l_u16CRC = 0;
            for (int i = 0; i < sLen; i++)
            {
                l_u16CRC = (ushort)(crctab[(l_u16CRC >> 8) ^ pMsg[i]] ^ (l_u16CRC << 8));

            }
            return l_u16CRC;
        }
        //CRC16校验
        public ushort CRC16(byte[] puchMsg, int len, ushort usDataLen) //校验函数
        {
            byte uchCRCHi = 0xFF; /* 高CRC字节初始化 */
            byte uchCRCLo = 0xFF; /* 低CRC 字节初始化 */
            int uIndex; /* CRC循环中的索引 */
            while ((usDataLen--) != 0) /* 传输消息缓冲区 */
            {
                uIndex = (int)(uchCRCLo ^ puchMsg[len++]); /* 计算CRC */
                uchCRCLo = (byte)(uchCRCHi ^ auchCRCHi[uIndex]);
                uchCRCHi = auchCRCLo[uIndex];
            }
            return ((ushort)(uchCRCHi << 8 | uchCRCLo));
        }

        //窗体初始化
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //初始化下拉串口名称列表框
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboPortName.Items.AddRange(ports);
            comboPortName.SelectedIndex = comboPortName.Items.Count > 0 ? 0 : -1;
            //comboBaudrate.SelectedIndex = comboBaudrate.Items.IndexOf("115200");

            //初始化SerialPort对象
            comm.NewLine = "\r\n";
            comm.RtsEnable = true;//根据实际情况

            //添加事件注册
            comm.DataReceived += comm_DataReceived;
            
            ///初始化表格
            dataGridView1.Columns.Add("FieldName", "编号");
            dataGridView1.Columns.Add("FieldName", "角度");
            dataGridView1.Columns.Add("FieldName", "功率值");
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 90;

            InitDataGridView1();

        }


        private void InitDataGridView1()//初始化DataGridView1
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 20; i++)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = (index + 1).ToString();

                for (int k = 1; k < 3; k++)
                {
                    dataGridView1.Rows[index].Cells[k].Value = "";

                }
            }
        }


        private void buttonOpenClose_Click_1(object sender, EventArgs e) //打开串口开关
        {
            //根据当前串口对象，来判断操作
            if (comm.IsOpen)
            {
                //打开时点击，则关闭串口
                comm.Close();
                WriteToView("串口关闭成功！");
                timer1.Stop();
            }
            else
            {
                //关闭时点击，则设置好端口，波特率后打开
                comm.PortName = comboPortName.Text;
                comm.BaudRate = 38400;
                try
                {
                    comm.Open();
                    WriteToView("串口打开成功！");
                }
                catch (Exception ex)
                {
                    //捕获到异常信息，创建一个新的comm对象，之前的不能用了。
                    comm = new SerialPort();
                    MessageBox.Show(ex.Message);
                }
            }
            //设置按钮的状态
            buttonOpenClose.Text = comm.IsOpen ? "关闭串口" : "打开串口";
 
        }


        delegate void MyDelegateShow(string content);

        private object lockObj = new object();//给ReceiveBuf加锁
        public Thread Current;
        public bool ThreadIsWorking = true;
        public DateTime RecvTime = DateTime.Now;
        public List<byte[]> RecvDataCache = new List<byte[]>();//接数缓存
        string strtemp = null;


        byte[] DataMessage = new byte[519];

        void comm_DataReceived(object Obj, SerialDataReceivedEventArgs e)   //串口接收数据
        {        
            while (ThreadIsWorking)
            {
                try
                {
                    byte[] recvByteMessage = new byte[1024];

                    int len = comm.BytesToRead;
                    comm.Read(recvByteMessage, 0, len);
                    if (len == 0)
                    {
                        break;//断开
                    }
                    if (len == 9)
                    {
                        try
                        {
                            int res = DataHander(recvByteMessage, len);   //全帧解析
                            if (res == -1)
                            {
                                return;
                            }
                            //strtemp = "当前角度: "+g_iNowLocation;
                        }
                        catch (Exception ex)
                        {
                            WriteToView("异常：" + ex.Message);
                        }
                    }
                    else
                    {
                        byte[] recvByteMessageTmp = new byte[len];//加入收数缓存
                        System.Array.Copy(recvByteMessage, recvByteMessageTmp, len);
                        //打印接收的数据
                        strtemp = "接收到数据: ";
                        for (int i = 0; i < len; i++)
                        {
                            strtemp += recvByteMessage[i].ToString("X2");
                            strtemp += " ";
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    WriteToView("异常：" + ex.Message);
                    return;
                }
                finally
                {
                    MyDelegateShow mds = new MyDelegateShow(WriteToView);
                    mds(strtemp);
                }
            }    
        }
        //获得位置处理函数
        public int DataHander(byte[] databuf, int slen)
        {
            //CRC 校验
            ushort crc = (ushort)(databuf[slen - 1] << 8 + databuf[slen - 2]);
            if (true)//crc == CRC16(databuf, 0, (ushort)(slen - 2)))
            {
                //校验通过
                if (databuf[1] == 0x03 && databuf[2] == 0x04)
                {
                    //得到位置角度,目前精确到度
                    g_dNowLocation = databuf[5]*1637216 + databuf[6]*65536 + databuf[3]*256 + databuf[4];
                    g_dNowLocation /= 1000;//转换到度
                    //g_dBandPower = GetBandPower();
                    IsGetLocation = true;
                    //IsGetBandPower = true;
                    //if (rbAround.Checked)
                        
                }
                //MyDelegate_DeleshowFun md = new MyDelegate_DeleshowFun(ParamHandFunc);
                //this.BeginInvoke(md, databuf);
                //IsGetLocation = false;
                //IsGetBandPower = false;
            }
            else
            {
                //校验不通过
                return -1;
            }
            return 0;
        }
        //取得输入框的数值
        public int gettbValue(TextBox tb)
        {
            string strSpeed = tb.Text.ToString();
            int Value = 0;
            bool result = Int32.TryParse(strSpeed, out Value);
            if (!result)
            {
                MessageBox.Show("请输入速度值和目标角度！");
            }
            else  //else for if(!result)
            {
            }
            return Value;
        }

        //public void ThreadGetNowLocation()
        //{ 

        //}
        //public void ThreadGetBandPower()
        //{
        //    g_dBandPower = GetBandPower();
        //}
        public delegate void MyDelegate_DeleshowFun(byte[] data);

        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "").Trim().ToUpper();
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        //private void ParamHandFunc(byte[] p_pRecvData)//参数处理函数
        //{
        //    Onemessage MessInfo = new Onemessage();          
        //}

        delegate void ShowMessageforTextCallBack1(string content);
        public void WriteToView(string content)  //显示函数
        {
            if (textBox1.InvokeRequired)//为true代表非创建控件的线程访问该控件
            {
                ShowMessageforTextCallBack1 showMessageforTextCallback1 = WriteToView;
                textBox1.Invoke(showMessageforTextCallback1, new object[] { content });
            }
            else
            {
                WriteToView4(textBox1, content);
            }
        }

        public void WriteToView4(TextBox TextBox, string content)//创建控件的线程,访问控件
        {
            try
            {
                if (TextBox.TextLength >= 500)
                {
                    TextBox.Text = "";
                }
                TextBox.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + content + "\r\n";
                TextBox.Focus();//获取焦点
                TextBox.Select(TextBox.TextLength, 0);//光标定位到文本最后
                TextBox.ScrollToCaret();//滚动到光标处
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show("请检查数据是否已保存，若已保存，点击确定后清空数据", "清空前请注意！", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
               
                //this.FormClosing -= new FormClosingEventHandler(this.Form1_FormClosing);//为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
                //Application.Exit();//退出整个应用程序
            }
            else
            {
                InitDataGridView1();     
            }
         
        }

        public void OutputExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd HHmm");
            string PathExcel = "";
            
            saveFileDialog1.Filter = "Excel files(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                PathExcel = saveFileDialog1.FileName;
                ExcelCreate excre = new ExcelCreate();             
                DataTable dt = new DataTable();
                dt.Columns.Add("编号");
                dt.Columns.Add("角度");
                dt.Columns.Add("功率值");
               
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["编号"] = (dataGridView1.Rows[i].Cells[0].Value);
                    dr["角度"] = (dataGridView1.Rows[i].Cells[1].Value);
                    dr["功率值"] =(dataGridView1.Rows[i].Cells[2].Value);
                    
                    dt.Rows.Add(dr);
                }

                string dt12 = DateTime.Now.ToString("yyyyMMddhhmmss");

                excre.OutFileToDisk(dt, "载波方向数据表", PathExcel);

                WriteToView("导出表Excel保存成功，路径为" + PathExcel);
            }
            //DateTime dtm = DateTime.Now;
            //string PathTxt = string.Format("{0}\\{1}\\", Application.StartupPath, dtm.Year.ToString("D4") + dtm.Month.ToString("D2") + dtm.Day.ToString("D2"));
            //if (!Directory.Exists(PathTxt))
            //{
            //    Directory.CreateDirectory(PathTxt);
            //}
            FileStream fs = null;
            string PathquExcel = PathExcel.Replace(".", "");
            string strFile = string.Format("{0}.txt",PathquExcel);
            fs = new FileStream(strFile, FileMode.Create, FileAccess.Write);
            if (fs != null)
            {
                string MessData = "";
                for (int s = 0; s < dataGridView1.Rows.Count - 1; s++)
                {
                    //MessData += (dataGridView1.Rows[s].Cells[0].Value)+"|";
                    MessData += (dataGridView1.Rows[s].Cells[1].Value) + "\t";
                    MessData += (dataGridView1.Rows[s].Cells[2].Value) + "\r\n";
                }
                //MessageBox.Show(MessData);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(MessData);
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            WriteToView("txt保存成功，路径为" + strFile);

        }
        public void Form1_FormClosing()
        {
            //为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
            this.FormClosing -= new FormClosingEventHandler(this.Form1_FormClosing);
            Application.Exit();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;//取消关闭事件
            Form2 f2 = new Form2();
            f2.f1 = this;
            if (DialogResult.OK == f2.ShowDialog())//让Form2以模式窗口显示，就是说Form2显示时 Form1无法成为焦点
              {
                 this.FormClosing -= new FormClosingEventHandler(this.Form1_FormClosing);//为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
                 Application.Exit();
              }
         }

          //Form2中两个按钮事件代码：
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
       {
            DialogResult = DialogResult.Cancel;
       }
       
        //寻零指令
        private void btnGoZero_Click(object sender, EventArgs e)
        {
            if (!comm.IsOpen)
            {
                MessageBox.Show("请打开串口~");
                return;
            }
            InitDataGridView1();
            byte[] sbuf = new byte[128];
            int slen = 0;
            sbuf[slen++] = 0x01;
            sbuf[slen++] = 0x10;
            sbuf[slen++] = 0x01;
            sbuf[slen++] = 0xf5;
            sbuf[slen++] = 0x00;
            sbuf[slen++] = 0x01;
            sbuf[slen++] = 0x02;
            sbuf[slen++] = 0x00;
            sbuf[slen++] = 0x01;
            ushort crc = CRC16(sbuf, 0, (ushort)slen);
            sbuf[slen++] = (byte)crc;
            sbuf[slen++] = (byte)(crc >> 8);
            comm.Write(sbuf, 0, slen);
            g_iTimerCount = 0;
            WriteToView("正在复位~~~");
            timer1.Stop();
        }
        //停止指令
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (!comm.IsOpen)
            {
                MessageBox.Show("请打开串口~");
                return;
            }
            byte[] sbuf = new byte[128];
            int slen = 0;
            sbuf[slen++] = 0x01;
            sbuf[slen++] = 0x10;
            sbuf[slen++] = 0x03;
            sbuf[slen++] = 0xe8;
            sbuf[slen++] = 0x00;
            sbuf[slen++] = 0x01;
            sbuf[slen++] = 0x02;
            sbuf[slen++] = 0x00;
            sbuf[slen++] = 0x0b;
            ushort crc = CRC16(sbuf, 0, (ushort)slen);
            sbuf[slen++] = (byte)crc;
            sbuf[slen++] = (byte)(crc >> 8);
            comm.Write(sbuf, 0, slen);
            WriteToView("已停止~~~");
            g_iTimerCount = 0;

        }
        //获取位置
        public double getLocation()
        {
            IsGetLocation = false;
            byte[] sbuf = new byte[128];
            int slen = 0;
            sbuf[slen++] = 0x01;
            sbuf[slen++] = 0x03;
            sbuf[slen++] = 0x04;
            sbuf[slen++] = 0x62;
            sbuf[slen++] = 0x00;
            sbuf[slen++] = 0x02;
            ushort crc = CRC16(sbuf, 0, (ushort)slen);
            sbuf[slen++] = (byte)crc;
            sbuf[slen++] = (byte)(crc >> 8);
            comm.Write(sbuf, 0, slen);
            int waiting = 0;
            while (!IsGetLocation)
            {
                waiting++;
                if (waiting == 655360000)
                    return -9999;

            }
            return g_dNowLocation;
        }
        //控制指令
        public int StepContrl(int speed, int cor)
        {
            byte[] sbuf = new byte[128];
            int slen = 0;
            try
            {
                sbuf[slen++] = 0x01;
                sbuf[slen++] = 0x10;
                sbuf[slen++] = 0x00;
                sbuf[slen++] = 0x14;
                sbuf[slen++] = 0x00;
                sbuf[slen++] = 0x04;
                sbuf[slen++] = 0x08;
                sbuf[slen++] = (byte)(speed >> 8);
                sbuf[slen++] = (byte)(speed);
                sbuf[slen++] = (byte)(speed >> 16);
                sbuf[slen++] = (byte)(speed >> 24);
                sbuf[slen++] = (byte)(cor >> 8);
                sbuf[slen++] = (byte)(cor);
                sbuf[slen++] = (byte)(cor >> 16);
                sbuf[slen++] = (byte)(cor >> 24);
                ushort crc = CRC16(sbuf, 0, (ushort)slen);
                sbuf[slen++] = (byte)crc;
                sbuf[slen++] = (byte)(crc >> 8);
                comm.Write(sbuf, 0, slen);
                return 0;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return -1;
            }
        }
        public void SingleGo()
        {
            int m_iSpeed = 0;
            int m_iCor = 1;
            m_iSpeed = gettbValue(tbSpeed);
            if (m_iSpeed < 500)
            {
                m_iSpeed = 500;
                WriteToView("转速太快，已修正到500毫秒每度");
            }
            g_dNowLocation = getLocation();
            //m_iCor = getLocation();
            //m_iCor +=1;
            //单步执行
            if (rbShun.Checked)
            {
                //顺时针转动
                StepContrl(m_iSpeed * 60, m_iCor * 1000);
            }
            else
            {
                //逆时针转动
                StepContrl(m_iSpeed * 60, m_iCor * 1000 * (-1));
            }
        }
        //开始转动
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(!comm.IsOpen)
            {
                MessageBox.Show("请打开串口~");
                return;
            }
            if (dataGridView1.Rows[0].Cells[2].Value.ToString() == "")
            {
                InitDataGridView1();
                if (rbSingle.Checked)
                {
                    SingleGo();
                    if (g_dNowLocation == -9999)
                    {
                        MessageBox.Show("获取位置超时，请检查转台是否连接正常");

                    }
                    updataValue();
                }
                else if (rbAround.Checked)
                {
                    timer1.Stop();
                    timer1.Interval = (int)(gettbValue(tbSpeed));
                    timer1.Start();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("检测到可能有数据存在，是否先保存？", "数据保存", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    OutputExcel(null, null);
                }
                else
                {
                    InitDataGridView1();
                    if (rbSingle.Checked)
                    {
                        SingleGo();
                        updataValue();
                    }
                    else if (rbAround.Checked)
                    {
                        timer1.Stop();
                        timer1.Interval = (int)(gettbValue(tbSpeed));
                        timer1.Start();
                    }
                }
            }
            
            
           
        }
        public void updataValue()
        {

            bool rowcheckflag = true;
            for (int m = 0; m < 20; m++)
            {
                if (dataGridView1.Rows[m].Cells[1].Value.ToString().Equals(""))
                {
                    //for (int k = 1; k < 3; k++)
                    //{
                        //g_iNowLocation = getLocation();
                    dataGridView1.Rows[m].Cells[1].Value = Convert.ToInt32(g_dNowLocation);
                    g_dBandPower = GetBandPower();
                    dataGridView1.Rows[m].Cells[2].Value = g_dBandPower;
                    //}
                    rowcheckflag = false;
                    break;
                }
            }
            if (rowcheckflag)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = index + 1;
                //for (int k = 1; k < 3; k++)
                //{
                    //dataGridView1.Rows[index].Cells[k].Value = m_bAloneFrame[k - 1];
                    //g_iNowLocation = getLocation();
                    dataGridView1.Rows[index].Cells[1].Value = Convert.ToInt32(g_dNowLocation);
                    g_dBandPower = GetBandPower();
                    dataGridView1.Rows[index].Cells[2].Value = g_dBandPower;

                //}
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;//显示最新一行
            }
        }
        //是否选择单步
        private void rbSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSingle.Checked)//单步选中
            {
                tbDu.Enabled = false;
            }
            else
            {
                tbDu.Enabled = true;
            }
        }

        //设置参数
        private void btnSetAy_Click(object sender, EventArgs e)
        {

            if (!IsOpened())
            {
                MessageBox.Show("请先打开频谱仪");
            }
            bool IsSetAnalyValue = false;
            try
            {
                String order = "";
                order = String.Format(":SYST:PRES\n");
                ExecOrder_ANA(order);
                order = String.Format("FREQ:CENT " + tbFreq.Text.ToString() + "GHz\n");						// Set FREQ Center Frequency
                ExecOrder_ANA(order);
                order = String.Format("FREQ:SPAN " + tbSpan.Text.ToString() + " MHz\n");
                ExecOrder_ANA(order);
                order = String.Format("DISP:WIND:TRAC:Y:RLEV " + tbYScale.Text.ToString() + " dBm\n");
                ExecOrder_ANA(order);
                order = String.Format("CALC:MARK:FUNC BPOW\n");
                ExecOrder_ANA(order);
                order = String.Format(":CALCulate:MARKer1:X " + tbMarker.Text.ToString() + " GHz\n");
                ExecOrder_ANA(order);
                order = String.Format(":CALC:MARK1:FUNC:BAND:SPAN " + tbBandSpan.Text.ToString() + " MHz\n");
                ExecOrder_ANA(order);
                order = String.Format(":TRACe1:TYPE AVERage\n");
                ExecOrder_ANA(order);
                order = String.Format(":AVERage:COUNt " + tbAverNumber.Text.ToString() + "\n");
                ExecOrder_ANA(order);

                IsSetAnalyValue = true;

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                IsSetAnalyValue = false;
            }
            //ExecOrder(order, (int)chuangti);
            //IsSetAnalyValue = SetAnalyzer(5.79f, 10, -10, 5.79f, 2, 20);
            ////IsSetAnalyValue = SetAnalyzer(float.Parse(tbFreq.Text.ToString()), int.Parse(tbSpan.Text.ToString()), int.Parse(tbYScale.Text.ToString()),
            ////    float.Parse(tbMarker.Text.ToString()), int.Parse(tbBandSpan.Text.ToString()), int.Parse(tbAverNumber.Text.ToString()));
            if (IsSetAnalyValue)
            {
                WriteToView("频谱仪参数设置成功");

            }
            else
            {
                WriteToView("频谱仪参数设置失败，请检查是否连接上或者参数是否设定");
            }
        }
        //打开/断开频谱仪
        private void btnConAnaly_Click(object sender, EventArgs e)
        {
            if (btnConAnaly.Text == "断开频谱仪")
            {
                //已经打开
                CloseAnalyzer(0);
                btnConAnaly.Text = "打开频谱仪";
            }
            else
            {
                bool IsConAnaly = OpenAnalyzer("N9010A", 0);
                if (IsConAnaly)
                {
                    btnConAnaly.Text = "断开频谱仪";
                    WriteToView("频谱仪打开成功");
                }
                else
                {
                    btnConAnaly.Text = "打开频谱仪";
                    WriteToView("频谱仪打开失败，请检查");
                }
            }
        }

        private void btnReadAy_Click(object sender, EventArgs e)
        {
            double bandpower= GetBandPower();
            double Location = getLocation();
            MessageBox.Show("当前功率："+bandpower.ToString()+"\r\n"+"当前角度："+Location.ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitDataGridView1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //updataValue();
            g_iTimerCount++;
            
            SingleGo();
            if (g_dNowLocation == -9999)
            {
                g_iTimerCount = 0;
                timer1.Stop();
                MessageBox.Show("获取位置超时，请检查转台是否连接正常");
                
            }
            updataValue();
            if ((gettbValue(tbDu))== g_iTimerCount)
            {
                g_iTimerCount = 0;
                timer1.Stop();
                DialogResult dr = MessageBox.Show("测试已完成,是否保存到Excel中", "测试完成", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    OutputExcel(null, null);
                }
                else
                { 
                
                }
            }

        }

        private void tbFreq_TextChanged(object sender, EventArgs e)
        {
            tbMarker.Text = tbFreq.Text;
        }
    }
}
