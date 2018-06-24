using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTT
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            //this.Controls.Remove(pictureBox1);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Controls.Remove(pictureBox1);
            var userElement = webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("username")[0];
            //var passwordElement = webBrowser1.Document.GetElementById("password");
            //var submit =webBrowser1.Document.GetElementsByTagName("button")[0];
            userElement.Focus();
            SendKeys.Send("viewer");
            SendKeys.Send("\r");
            SendKeys.Send("{TAB}");
            SendKeys.Send("viewer");
            SendKeys.Send("\r");
            //Delay(20);
            //submit.InvokeMember("click");
        }
        private void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权            
            }
            return;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
            this.Dispose();
            this.Close();
        }

        private void Form4_ControlRemoved(object sender, ControlEventArgs e)
        {
        }
    }
}
