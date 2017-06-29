using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace Gauge
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        //点精度转16
        //Single sin = 5;
        //var sinbyte = BitConverter.GetBytes(sin);
        //16=》单精度
        //BitConverter.ToSingle(sinbyte, 0)
        //反置
        //float m = BitConverter.ToSingle(bytes.Reverse().ToArray(), 0);


        public MainWindow()
        {
            InitializeComponent();
            this.combo.ItemsSource = yldw;
            this.combo.DisplayMemberPath = "Name";

            #region MyRegion



            //string s = "021020080004";
            //MatchCollection matches = Regex.Matches(s, @"[0-9A-Fa-f]{2}");
            //byte[] bytes = new byte[matches.Count];
            //for (int i = 0; i < bytes.Length; i++)
            //    bytes[i] = byte.Parse(matches[i].Value, NumberStyles.AllowHexSpecifier);
            //float m = BitConverter.ToSingle(bytes.Reverse().ToArray(), 0);

            ////byte[] temp = new byte[] { 0x02, 0x04, 0x08,0x00, 0x00, 0x40, 0xA0, 0x00, 0x00, 0x3f, 0x00 };//{ 0x02, 0x10, 0x20, 0x08, 0x00, 0x04 };

            ////byte[] temp = new byte[] { 0x02, 0x10, 0x20, 0x08, 0x00, 0x04, 0x08, 0x00, 0x00, 0x3f, 0x00, 0x00, 0x00, 0x3f, 0x00 };

            //byte[] temp = new byte[] { 0x00, 0x00, 0x00, 0x3f };//{ 0x00, 0x00, 0xA0, 0x40 };//{ 0x00, 0x00, 0x00, 0x3f };//new byte[] { 0x3C, 0x23, 0xD7, 0x0A };//{ 0x02, 0x67, 0x45, 0x01, 0x00, 0x02 };
            //var bit = BitConverter.ToSingle(temp, 0);
            //float sin = 50;
            //var sinbyte = BitConverter.GetBytes(sin);
            // // byte[] temp = Encoding.Default.GetBytes("1234".ToCharArray());
            //byte[] temp1 = Encoding.Default.GetBytes("1234".ToCharArray());//new byte[] { 0x00, 0x00, 0x3f, 0x00 };

            //var sss = Encoding.Default.GetString(temp);


            //byte[] bytes2 = new byte[] { 0x02, 0x10, 0x20, 0x08, 0x00, 0x04 };//BitConverter.GetBytes(0.1);
            //byte[] bytes2 = new byte[] { 0x04, 0x00, 0x08, 0x20, 0x10, 0x02 };
            // byte[] bytes2 = new byte[] { 0x10, 0x02, 0x08, 0x20, 0x04, 0x00 };
            //byte[] bytes2 = new byte[] { 0x00, 0x04, 0x20, 0x08, 0x02, 0x10 };
            //int iii = 1;
            // byte b = Convert.ToByte(iii);

            // long lon = 1;

            // byte[] abyte = BitConverter.GetBytes(0x02);
            // var lll = lon >> 24;

            // asdasd();
            // var h1 = "1".ToCharArray();
            //// string b = Convert.ToString(h1, 16);
            // byte[] h11 = new byte[] { 0x1 };
            // int h222 = 2;
            // var bit = BitConverter.GetBytes(h222);
            // var sss = Encoding.Default.GetString(h11);

            // byte[] bytes2 = new byte[] { 0x02, 0x10, 0x20, 0x08, 0x04, 0x00 };
            // //var bit2 = BitConverter.ToSingle(bytes, 0);

            // byte[] temp = new byte[] { 0x02, 0x10, 0x20, 0x08, 0x00, 0x04, 0x08, 0x00, 0x00, 0x3f, 0x00, 0x00, 0x00, 0x3f, 0x00 };//{ 0x02, 0x04, 0x08, 0x00, 0x00, 0x40, 0xA0, 0x00, 0x00, 0x3f, 0x00 };


            // var crc = CRC16Helper.CRC16(temp, 0, temp.Length - 1);


            #endregion

        }


        //public void asdasd()
        //{
        //    string input = "1";
        //    char[] values = input.ToCharArray();
        //    foreach (char letter in values)
        //    {// Get the integral value of the character.
        //        int value = Convert.ToInt32(letter);
        //        // Convert the decimal value to a hexadecimal value in string form.
        //        string hexOutput = String.Format("{0:X}", value);
        //        Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
        //    } 
        //}


        public List<ConfigModel> dqtd = new List<ConfigModel>
        {
            new ConfigModel(){ Name = "关闭所有通道",Value =  0x00},
            new ConfigModel(){ Name = "通道1",Value =  0x01},
            new ConfigModel(){ Name = "通道2",Value =  0x02},
            new ConfigModel(){ Name = "通道3",Value =  0x03},
            new ConfigModel(){ Name = "通道4",Value =  0x04},
            new ConfigModel(){ Name = "通道5",Value =  0x05},
            new ConfigModel(){ Name = "通道6",Value =  0x06},
            new ConfigModel(){ Name = "通道7",Value =  0x07},
            new ConfigModel(){ Name = "通道8",Value =  0x08},
        };
        
        public List<ConfigModel> dqsx = new List<ConfigModel>()
        {
            new ConfigModel(){ Name = "关闭所有功能",Value =  0x00},
            new ConfigModel(){ Name = "电压(V)",Value =  0x81},
            new ConfigModel(){ Name = "电流(mA)",Value =  0x82},
            new ConfigModel(){ Name = "变送器(Tr)",Value =  0x83},
            new ConfigModel(){ Name = "压力开关",Value =  0x84},
            new ConfigModel(){ Name = "电阻（2W）",Value =  0x85},
            new ConfigModel(){ Name = "电阻(4W)",Value =  0x86},
            new ConfigModel(){ Name = "毫伏(mV)",Value =  0x87},
            new ConfigModel(){ Name = "频率(Hz)",Value =  0x88},
            new ConfigModel(){ Name = "电源（DvR）",Value =  0x89},
            new ConfigModel(){ Name = "热电偶（Tc）",Value =  0x8A},
            new ConfigModel(){ Name = "热电阻（Rtd）",Value =  0x8B},
            new ConfigModel(){ Name = "累计脉冲个数",Value =  0x8C},
            new ConfigModel(){ Name = "电压信号输出",Value =  0x91},
            new ConfigModel(){ Name = "电流信号输出",Value =  0x92},
        };

      
        
        public List<ConfigModel> yldw = new List<ConfigModel>
        {
            new ConfigModel(){ Name = "Pa",Value = 0x00},
            new ConfigModel(){ Name = "kPa",Value =  0x01},
            new ConfigModel(){ Name = "MPa",Value =  0x02},
            new ConfigModel(){ Name = "mbar",Value =  0x03},
            new ConfigModel(){ Name = "bar",Value =  0x04},
            new ConfigModel(){ Name = "psi",Value =  0x05},
            new ConfigModel(){ Name = "mmHg",Value =  0x06},
            new ConfigModel(){ Name = "mmH2O",Value =  0x07},
            new ConfigModel(){ Name = "kgf/cm2",Value =  0x08},
        };


        SerialPort sp = new SerialPort();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (sp.IsOpen)
                MessageBox.Show("串口已打开,请先关闭");
            sp.PortName = com.Text.Trim();
            sp.BaudRate = int.Parse(bt.Text.Trim());
            sp.StopBits = StopBits.One;
            sp.DataBits = 8;
            sp.Parity = Parity.None;

            sp.DataReceived += Sp_DataReceived;

            sp.Open();
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = sender as System.IO.Ports.SerialPort;
            byte[] bytesData = new byte[0];
            byte[] bytesTemp = new byte[0];
            int bytesRead;
            byte result = 0x00;
            //获取接收缓冲区中字节数
            bytesRead = serialPort.BytesToRead;
            //保存上一次没处理完的数据
            if (bytesData.Length > 0)
            {
                bytesTemp = new byte[bytesData.Length];
                bytesData.CopyTo(bytesTemp, 0);
                bytesData = new byte[bytesRead + bytesData.Length];
                bytesTemp.CopyTo(bytesData, 0);
            }
            else
            {
                bytesData = new byte[bytesRead];
                bytesTemp = new byte[0];
            }
            //保存本次接收的数据
            for (int i = 0; i < bytesRead; i++)
            {
                bytesData[bytesTemp.Length + i] = Convert.ToByte(serialPort.ReadByte());//read all data
            }
            //后加的代码，否则容易下标越界IndexOutOfRangeException
            if (bytesData.Length < 3)
                return;
            for (int i = 0; i < bytesData.Length; i++)
            {
                //if ((bytesData[i] == 0xAA) && (bytesData[i + 2] == 0x0D))
                //{
                //    result = bytesData[i + 1];
                //    if (result != 0x00)
                //    {
                //        _resultData = new Random(Guid.NewGuid().GetHashCode()).Next(50, 100);
                //        _resutlStatus = true;

                //    }
                //    //_resutlStatus = result
                //    i += 2;
                //}
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (sp.IsOpen)
                sp.Close();
        }
        /// <summary>
        /// 仅读取压力值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            byte[] by = new byte[4];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x04;
            by[2] = 0x20;
            by[3] = 0x00;

            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);
            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);
        }
        /// <summary>
        /// 仅读取电测值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            byte[] by = new byte[4];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x04;
            by[2] = 0x20;
            by[3] = 0x02;

            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);

            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);
        }

        /// <summary>
        /// 设置压力单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            byte[] by = new byte[7];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x06;
            by[2] = 0x20;
            by[3] = 0x07;

            by[4] = 0x02;

            if (this.combo.SelectedItem == null)
            {
                MessageBox.Show("请选择压力单位");
                return;
            }


            by[5] = 0x00;
            by[6] = (this.combo.SelectedItem as ConfigModel).Value;

            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);

            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);

        }
        /// <summary>
        /// 当前压力单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            byte[] by = new byte[4];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x04;
            by[2] = 0x20;
            by[3] = 0x07;

            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);

            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);
        }
        /// <summary>
        /// 压力清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            byte[] by = new byte[6];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x67;
            by[2] = 0x45;
            by[3] = 0x01;

            by[4] = 0x00;
            by[5] = 0x02;

            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);
           
            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);
        }

        /// <summary>
        /// 造压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            byte[] by = new byte[10];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x10;
            by[2] = 0x21;
            by[3] = 0x00;

            by[4] = 0x00;
            by[5] = 0x04;

            var zyz = this.zy.Text.Trim();
            //点精度转16
            //Single sin = 5;
            //var sinbyte = BitConverter.GetBytes(sin);
            Single sin = Single.Parse(zyz);
            var sinby = BitConverter.GetBytes(sin);

            by[6] = sinby[1];
            by[7] = sinby[0];
            by[8] = sinby[3];
            by[9] = sinby[2];

            

            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);

            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);
        }
        /// <summary>
        /// 造压+微调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            byte[] by = new byte[15];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x10;
            by[2] = 0x20;
            by[3] = 0x08;

            by[4] = 0x00;
            by[5] = 0x04;

            by[6] = 0x08;

            var zyz = this.zy.Text.Trim();
            //点精度转16
            //Single sin = 5;
            //var sinbyte = BitConverter.GetBytes(sin);
            Single sin = Single.Parse(zyz);
            var sinby = BitConverter.GetBytes(sin);

            by[7] = sinby[1];
            by[8] = sinby[0];
            by[9] = sinby[3];
            by[10] = sinby[2];

            by[11] = sinby[1];
            by[12] = sinby[0];
            by[13] = sinby[3];
            by[14] = sinby[2];



            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);

            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);
        }

        /// <summary>
        /// 获取厂商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            byte[] by = new byte[4];
            by[0] = (byte)int.Parse(dz.Text.Trim());
            by[1] = 0x23;
            by[2] = 0x22;
            by[3] = 0x10;

            var crc = CRC16Helper.CRC16(by, 0, by.Length - 1);
            var bit = BitConverter.GetBytes(crc);

            byte[] by2 = new byte[by.Length + 2];
            for (int i = 0; i < by.Length; i++)
            {
                by2[i] = by[i];
            }
            by2[by.Length] = bit[1];
            by2[by.Length + 1] = bit[0];


            if (sp.IsOpen)
                sp.Write(by2, 0, by2.Length);
        }
    }


    public class ConfigModel
    {
        public string Name { get; set; }

        public byte Value { get; set; }
    }
}
