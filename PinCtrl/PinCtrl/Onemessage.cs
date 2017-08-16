using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinCtrl
{
    public class Onemessage
    {
        public ushort vehlong;
        public ushort vehhigh;
        public Int16 vehRSU;
        public string vehchecktime = "";
        public string vehtype = "";
        public string vehstatus = "";//过车状态
        public Int16 Obu_X;
        public Int16 Obu_Y;
        public string PlateNumber = "";//OBU车牌号码
        public string ObuVehicleClass = "";//OBU车型
        public string ObuTradeTime = "";//OBU交易时间
        public ushort vehnum;
        public Int16 Location;  //位置
        //public vehdata[] vdata;
    }
}
