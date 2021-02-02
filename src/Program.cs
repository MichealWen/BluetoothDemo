//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using InTheHand.Net;
//using InTheHand.Net.Bluetooth;
//using InTheHand.Net.Sockets;
//using System.IO;

//namespace ConsoleApp1
//{
//    class LanYa
//    {
//        public string blueName { get; set; } //蓝牙名字
//        public BluetoothAddress blueAddress { get; set; } //蓝牙的唯一标识符
//        public ClassOfDevice blueClassOfDevice { get; set; } //蓝牙是何种类型
//        public bool IsBlueAuth { get; set; } //指定设备通过验证
//        public bool IsBlueRemembered { get; set; } //记住设备
//        public DateTime blueLastSeen { get; set; }
//        public DateTime blueLastUsed { get; set; }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            BluetoothRadio radio = BluetoothRadio.PrimaryRadio;//获取蓝牙适配器
//            if (radio == null)
//            {
//                Console.WriteLine("没有找到本机蓝牙设备!");
//            }
//            else
//            {
//                Console.WriteLine("ClassOfDevice: " + radio.ClassOfDevice);
//                Console.WriteLine("HardwareStatus: " + radio.HardwareStatus);
//                Console.WriteLine("HciRevision: " + radio.HciRevision);
//                Console.WriteLine("HciVersion: " + radio.HciVersion);
//                Console.WriteLine("LmpSubversion: " + radio.LmpSubversion);
//                Console.WriteLine("LmpVersion: " + radio.LmpVersion);
//                Console.WriteLine("LocalAddress: " + radio.LocalAddress);
//                Console.WriteLine("Manufacturer: " + radio.Manufacturer);
//                Console.WriteLine("Mode: " + radio.Mode);
//                Console.WriteLine("Name: " + radio.Name);
//                Console.WriteLine("Remote:" + radio.Remote);
//                Console.WriteLine("SoftwareManufacturer: " + radio.SoftwareManufacturer);
//                Console.WriteLine("StackFactory: " + radio.StackFactory);
//            }
//            //Console.ReadKey();


//            List<LanYa> lanYaList = new List<LanYa>(); //搜索到的蓝牙的集合
//            BluetoothClient client = new BluetoothClient();
//            radio.Mode = RadioMode.Connectable;
//            BluetoothDeviceInfo[] devices = client.DiscoverDevices();//搜索蓝牙 10秒钟
//            int count = 0;
//            foreach (var item in devices)
//            {
//                count++;
//                Console.WriteLine("===========蓝牙设备" + count + "================");
//                Console.WriteLine("device name:" + item.DeviceName);//输出每个蓝牙设备的名字
//                Console.WriteLine("device address:" + item.DeviceAddress);//输出每个蓝牙设备的名字
//                Console.WriteLine("ClassOfDevice:" + item.ClassOfDevice);
//                Console.WriteLine("Authenticated:" + item.Authenticated);
//                Console.WriteLine("Remembered:" + item.Remembered);
//                Console.WriteLine("LastSeen:" + item.LastSeen);
//                Console.WriteLine("LastUsed:" + item.LastUsed);
//                lanYaList.Add(new LanYa { blueName = item.DeviceName, blueAddress = item.DeviceAddress, blueClassOfDevice = item.ClassOfDevice, IsBlueAuth = item.Authenticated, IsBlueRemembered = item.Remembered, blueLastSeen = item.LastSeen, blueLastUsed = item.LastUsed });//把搜索到的蓝牙添加到集合中
//            }
//            Console.WriteLine("device count:" + devices.Length);//输出搜索到的蓝牙设备个数


//            ////蓝牙的配对
//            //BluetoothClient blueclient = new BluetoothClient();
//            //Guid mGUID1 = BluetoothService.Handsfree; //蓝牙服务的uuid

//            //blueclient.Connect(s.blueAddress, mGUID) //开始配对 蓝牙4.0不需要setpin


//            BluetoothDeviceInfo dev = devices[0];

//            //客户端
//            BluetoothClient bl = new BluetoothClient();//
//            Guid mGUID = Guid.Parse("0000fff4-0000-1000-8000-00805F9B34FB");//蓝牙串口服务的uuiid

//            //byte[] def = { 0x13, 0x00, 0x05, 0x15, 0x11, 0x08, 0x01, 0x10, 0x02, 0x01, 0x12, 0x14 };

//            //string s = "D05FB81A21CE";
//            //byte[] def = Encoding.Default.GetBytes(s);
//            //string str2 = BitConverter.ToString(def);
//            //Console.WriteLine(str2);

//            //BluetoothAddress abc = new BluetoothAddress(def);

//            //try
//            //{
//            //    //bl.Connect(abc, mGUID);
//            //    bl.Connect(dev.DeviceAddress, mGUID);
//            //    Console.WriteLine("连接成功");
//            //    //"连接成功";
//            //}
//            //catch (Exception x)
//            //{
//            //    Console.WriteLine("连接异常");
//            //    //异常
//            //}

//            //var v = bl.GetStream();
//            //byte[] sendData = Encoding.Default.GetBytes(“人生苦短，我用python”);
//            //v.Write(sendData, 0, sendData.Length); //发送


//            //服务器端
//            //BluetoothListener bluetoothListener = new BluetoothListener(mGUID);
//            //bluetoothListener.Start();//开始监听

//            //bl = bluetoothListener.AcceptBluetoothClient();//接收


//            //while (true)
//            //{
//            //    Console.WriteLine("111111111");
//            //    byte[] buffer = new byte[100];
//            //    Stream peerStream = bl.GetStream();

//            //    peerStream.Read(buffer, 0, buffer.Length);

//            //    string data = Encoding.UTF8.GetString(buffer).ToString().Replace("\0", "");//去掉后面的\0字节
//            //}
//            Console.ReadKey();

//        }
//    }
//}




//using System;
//using System.IO;
//using System.Net.Sockets;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//// [注意1]：要添加如下三个命名空间 
//using InTheHand.Net;
//using InTheHand.Net.Bluetooth;
//using InTheHand.Net.Sockets;
//namespace TestBluetooth
//{
//    class Program
//    {
//        static void Main(string[] args) { 
//            BluetoothRadio bluetoothRadio = BluetoothRadio.PrimaryRadio; 
//            if (bluetoothRadio == null) { 
//                Console.WriteLine("没有找到本机蓝牙设备!"); 
//            } else { 
//                Program p = new Program(); 
//                p.localAdapterInfo(bluetoothRadio); 
//                p.openDoor(); 
//            } 
//        } /** * 连接目标蓝牙设备发送开门指令 * **/
//        private void openDoor()
//        {
//            BluetoothClient cli = new BluetoothClient(); BluetoothAddress addr = null; BluetoothEndPoint ep = null; try
//            { // [注意2]：要注意MAC地址中字节的对应关系，直接来看顺序是相反的，例如 // 如下对应的MAC地址为——12:34:56:78:9a:bc 
//                addr = new BluetoothAddress(new byte[] { 0xbc, 0x9a, 0x78, 0x56, 0x34, 0x12 }); ep = new BluetoothEndPoint(addr, BluetoothService.SerialPort); cli.Connect(ep); // 连接蓝牙 
//                if (cli.Connected)
//                {
//                    Stream peerStream = cli.GetStream(); peerStream.WriteByte(0xBB); // 发送开门指令 
//                }
//            }
//            catch (SocketException e) { Console.WriteLine(e.Message); }
//            finally
//            {
//                if (cli != null)
//                { // [注意3]：要延迟一定时间(例如1000毫秒) //避免因连接后又迅速断开而导致蓝牙进入异常(**)状态 
//                    Thread.Sleep(1000); cli.Close();
//                }
//            }
//        } /** * * 显示本地蓝牙的信息 * * **/
//        private void localAdapterInfo(BluetoothRadio bluetoothRadio) { 
//            Console.WriteLine("ClassOfDevice: " + bluetoothRadio.ClassOfDevice); 
//            Console.WriteLine("HardwareStatus: " + bluetoothRadio.HardwareStatus); 
//            Console.WriteLine("HciRevision: " + bluetoothRadio.HciRevision); 
//            Console.WriteLine("HciVersion: " + bluetoothRadio.HciVersion); 
//            Console.WriteLine("LmpSubversion: " + bluetoothRadio.LmpSubversion); 
//            Console.WriteLine("LmpVersion: " + bluetoothRadio.LmpVersion); 
//            Console.WriteLine("LocalAddress: " + bluetoothRadio.LocalAddress); 
//            Console.WriteLine("Manufacturer: " + bluetoothRadio.Manufacturer); 
//            Console.WriteLine("Mode: " + bluetoothRadio.Mode); 
//            Console.WriteLine("Name: " + bluetoothRadio.Name); 
//            Console.WriteLine("Remote:" + bluetoothRadio.Remote); 
//            Console.WriteLine("SoftwareManufacturer: " + bluetoothRadio.SoftwareManufacturer); 
//            Console.WriteLine("StackFactory: " + bluetoothRadio.StackFactory); 
//        }
//    }
//}

using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmp = CommunicateHexProtocolDecoder.Code(0x00, 0x00, 0x0002, new byte[] { });
            //BLECode.BluetoothLECode ble = new BLECode.BluetoothLECode("00001800-0000-1000-8000-00805f9b34fb", "00002a00-0000-1000-8000-00805f9b34fb", "00002a01-0000-1000-8000-00805f9b34fb");
            BLECode.BluetoothLECode ble = new BLECode.BluetoothLECode("0000fff0-0000-1000-8000-00805f9b34fb", "0000fff1-0000-1000-8000-00805f9b34fb", "0000fff1-0000-1000-8000-00805f9b34fb");
            ble.ValueChanged += Ble_ValueChanged;
            //ble.SelectDeviceFromIdAsync("d3:89:67:45:23:ab");
            ble.StartBleDeviceWatcher();
            while (true) Thread.Sleep(1000);
        }

        private static void Ble_ValueChanged(BLECode.MsgType type, string content, byte[] data = null)
        {
            if(content.Contains("Radar"))
            {
                Console.WriteLine("=================================");
                Console.WriteLine(content);
                string id = content.Substring(content.LastIndexOf("####")+4);
                Console.WriteLine("Connecting " + id);
                Console.WriteLine("=================================");
                System.Threading.Tasks.Task.Factory.StartNew(() => 
                {
                    BLECode.BluetoothLECode radarBLE = new BLECode.BluetoothLECode("0000fff0-0000-1000-8000-00805f9b34fb", "0000fff1-0000-1000-8000-00805f9b34fb", "0000fff1-0000-1000-8000-00805f9b34fb");
                    radarBLE.ValueChanged += (MsgType, msg, replayData) => 
                        {
                            if (replayData != null)
                            {
                                Console.WriteLine(msg + "应答：" + BitConverter.ToString(replayData));
                                if (replayData[replayData.Length-1] == 0xAA && replayData[replayData.Length-2] == 0xAA)
                                    radarBLE.Dispose();
                            }
                            else
                            {
                                Console.WriteLine(msg);
                            }
                        };
                    radarBLE.SelectDeviceFromIdAsync(id);
                    while (radarBLE.CurrentWriteCharacteristic == null) Thread.Sleep(10);
                    Console.WriteLine("-------------------------------获取版本号-------------------------------");
                    radarBLE.Write(CommunicateHexProtocolDecoder.Code(0x00, 0x00, 0x0002, new byte[] { }));
                    //Console.ReadKey();
                    //Console.WriteLine("==============重启=================");
                    //radarBLE.Write(CommunicateHexProtocolDecoder.Code(0x00, 0x00, 0x0005, new byte[] { }));
                    //Console.ReadKey();
                    //Console.WriteLine("==============重启=================");
                    //radarBLE.Write(CommunicateHexProtocolDecoder.Code(0x00, 0x00, 0x0005, new byte[] { }));
                    //Console.ReadKey();
                    //Console.WriteLine("==============重启=================");
                    //radarBLE.Write(CommunicateHexProtocolDecoder.Code(0x00, 0x00, 0x0005, new byte[] { }));
                    //Console.ReadKey();
                    //Console.WriteLine("==============重启=================");
                    //radarBLE.Write(CommunicateHexProtocolDecoder.Code(0x00, 0x00, 0x0005, new byte[] { }));
                    //Console.ReadKey();
                });
            }
        }
    }
}
