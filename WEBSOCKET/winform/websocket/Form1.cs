using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace websocket
{
    public partial class websocket : Form
    {
        private static wsserver ws;
        public static bool autoback = false;
        public websocket()
        {
            InitializeComponent();
            ws = new wsserver(new Action<int>(shownum));
           
        }
        public void shownum(int num) {
            Invoke(new Action<int>((x) => { label2.Text = "当前连接数：" + x; }),num);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ws.isopen())
            {
                MessageBox.Show("已经开启");
                return;
            }
            try
            {
                ws.init(Convert.ToInt32(textBox1.Text));
                textBox1.ReadOnly = true;
                label1.Text = "服务已开启";
            }
            catch
            {
                MessageBox.Show("初始化失败");
            }
            
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ws.send(textBox2.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            websocket.autoback = checkBox1.Checked;
        }
    }
}
