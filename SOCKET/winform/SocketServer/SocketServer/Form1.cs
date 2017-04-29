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

namespace SocketServer
{
    public partial class SocketServer : Form
    {
        private static Socket s;
        private static int port;
        private static List<Socket> clientlist=new List<Socket>();
        bool flag = false;
        public SocketServer()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void  button1_Click(object sender, EventArgs e)
        {
            try
            {
                port = Convert.ToInt32(textBox1.Text);
            }
            catch{
                MessageBox.Show("请填写正确的端口号");
                return;
            }
            new Thread(thread).Start();           
            
        }
        private void thread() {
            this.flag = true;
            s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            try
            {
                s.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
                MessageBox.Show("开始监听" + port + "端口");
            }
            catch {
                MessageBox.Show("端口不能监听可能被占用");
                return;
            }
            
            
            s.Listen(50);
           
            while (flag)
            {
                try
                {
                    Socket re = s.Accept();

                    Thread thread = new Thread(new ParameterizedThreadStart(mythread));

                    thread.Start(re);
                }
                catch { }
            }
            s.Dispose();



        }
        private void mythread(Object re) {
            clientlist.Add((Socket)re);
            Invoke(new Action<int>(x => { label4.Text = "客户端数目：" + x; }), clientlist.Count);
            NetworkStream netstream = new NetworkStream((Socket)re);
            byte[] buf = new byte[1024];
            var len=0;
            var str = "";

            try
            {
                while ((len = netstream.Read(buf, 0, 1024)) > 0)
                {
                    for (var i = 0; i < len; i++)
                    {
                        str += buf[i].ToString("X").PadLeft(2, '0') + " ";
                    }
                    Invoke(new Action<String>(x => { tag1txt1.Text += x; }), str);

                }

            }
            catch
            {
                clientlist.Remove((Socket)re);
                Invoke(new Action<int>(x => { label4.Text = "客户端数目：" + x; }),clientlist.Count); 
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clientlist.Count; i++)
            {
                clientlist[i].Dispose();
                clientlist.RemoveAt(i);
            }
            s.Dispose();
            MessageBox.Show("连接关闭！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var buf = StrToHexByte(tag1txt2.Text);
                for (var i = 0; i < clientlist.Count; i++)
                {
                    clientlist[i].Send(buf);            
                }
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = false;
            try
            {
                s.Dispose();
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //for (var i = 0; i < clientlist.Count; i++)
            //{
            //    clientlist[i].Connected
            //}
            clientlist.RemoveAll(x => x.Poll(10, SelectMode.SelectRead));
            label4.Text = "客户端数目：" + clientlist.Count;
        }
    }
}
