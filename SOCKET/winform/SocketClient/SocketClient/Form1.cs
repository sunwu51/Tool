using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        private static Socket s;
        private static String host;
        private static int port;
        bool flag = false;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                try
                {
                    host = textBox1.Text;
                    port = Convert.ToInt32(textBox2.Text);
                    s = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    s.Connect(new IPEndPoint(IPAddress.Parse(host), port));
                    MessageBox.Show("连接成功");
                    flag = true;
                    new Thread(new ParameterizedThreadStart(thread)).Start(s);

                }
                catch
                {
                    MessageBox.Show("连接失败！");
                    return;
                }
            }
            else {
                MessageBox.Show("请先断开原有连接");
            }
            
        }
        private void thread(Object s) {
            var socket = (Socket)s;
            var buf = new byte[1024];
            var len = 0;
            try
            {
                while ((len = socket.Receive(buf)) > 0)
                {
                    var str = "";
                    for (var i = 0; i < len; i++)
                    {
                        str += buf[i].ToString("X").PadLeft(2, '0') + " ";
                    }
                    Invoke(new Action<String>(x => { textBox3.Text += x; }), str);
                }
            }
            catch {

            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try { s.Dispose(); s = null;flag = false; }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { s.Dispose();s = null; }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!flag) {
                MessageBox.Show("请先建立连接");
                return;
            }
            try
            {
                var buf = StrToHexByte(textBox4.Text);
                s.Send(buf);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("字符串格式非hex");
            }
        }
        public static byte[] StrToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

    }
}
