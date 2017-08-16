using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace PinCtrl
{
    public class ClientSocketThreadObj
    {
        public object OperLock = new object();
        public string RemoteIp;
        public Thread Current;
        public Socket ClientSocket;
        public bool ThreadIsWorking = true;
        public DateTime RecvTime = DateTime.Now;
        public int isRecvingData = 0;//正在接数 0-没有接数 1-正在接数
        public List<byte[]> RecvDataCache = new List<byte[]>();//接数缓存

        public ManualResetEvent mREvent_UpdateDevProgram01Package = new ManualResetEvent(false);
        public byte[] Rep01Package = new byte[10240];
        public int isRecving01Package = 0;

        public ManualResetEvent mREvent_UpdateDevProgram02Package = new ManualResetEvent(false);
        public byte[] Rep02Package = new byte[10240];
        public int isRecving02Package = 0;
       
        public ManualResetEvent mREvent_UpdateDevProgram04Package = new ManualResetEvent(false);
        public byte[] Rep04Package = new byte[10240];
        public int isRecving04Package = 0;

        public ManualResetEvent mREvent_UpdateDevProgram05Package = new ManualResetEvent(false);
        public byte[] Rep05Package = new byte[10240];
        public int isRecving05Package = 0;

        public ManualResetEvent mREvent_UpdateDevProgram06Package = new ManualResetEvent(false);
        public byte[] Rep06Package = new byte[10240];
        public int isRecving06Package = 0;

        public ManualResetEvent mREvent_UpdateDevProgram07Package = new ManualResetEvent(false);
        public byte[] Rep07Package = new byte[10240];
        public int isRecving07Package = 0;

        public void InitUpdateDevProgram()
        {
            mREvent_UpdateDevProgram01Package.Reset();
            mREvent_UpdateDevProgram02Package.Reset();
            mREvent_UpdateDevProgram04Package.Reset();
            mREvent_UpdateDevProgram05Package.Reset();
            mREvent_UpdateDevProgram06Package.Reset();
            mREvent_UpdateDevProgram07Package.Reset();

            isRecving01Package = 0;
            isRecving02Package = 0;
            isRecving04Package = 0;
            isRecving05Package = 0;
            isRecving06Package = 0;
            isRecving07Package = 0;
        }
    }
}
