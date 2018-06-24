using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //var form = new Form2();
            //ChangeForm(form);
            //foreach (Control control in this.Controls)
            //{
            //    control.Anchor += Top;
            //    control.Anchor += Left;
            //    //control.Anchor += Right;
            //}

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //foreach (Control control in this.Controls)
            //{
                //control.Enabled = false;
            //}
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
            this.Dispose();
            this.Close();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] subTopics = { Global.subTopic };
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
            Global.client = new MqttClient("118.89.106.236");
            Global.client.Connect(Guid.NewGuid().ToString(), "tester2", "tester");
            Global.client.Subscribe(subTopics, qosLevels);
            progressBar1.Value = 100;
            var form = new FormControl();
            ChangeForm(form);
        }
        private void 文本控制台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.client is MqttClient)
            {
                var form = new Form3();
                ChangeForm(form);
            }
            else
            {
                MessageBox.Show("请先登录");
            }
        }
        private void 水浴箱控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.client is MqttClient)
            {
                var form = new FormControl();
                ChangeForm(form);
            }
            else
            {
                MessageBox.Show("请先登录");
            } 
        }

        private void 数据可视化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form4();
            ChangeForm(form);
        }
        void ChangeForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
            form.Dock = System.Windows.Forms.DockStyle.Fill;                  //设置样式是否填充整个panel ;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            form.Show();                      //窗体运行 
        }

        private void Form1_ControlRemoved(object sender, ControlEventArgs e)
        {
            switch (e.Control.Name)
            {
                case "Form3":
                    //Global.client.MqttMsgPublishReceived. += client_MqttMsgPublishReceived;
                    //Global.client.MqttMsgSubscribed += client_MqttMsgSubscribed;
                    //Global.client.MqttMsgPublished += client_MqttMsgPublished;
                    break;
                default:
                    break;
            }
        }
    }
}
