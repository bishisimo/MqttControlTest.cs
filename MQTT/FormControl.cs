using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void FormControl_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Global.client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            send_order("cmd","check");
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var data = new Dictionary<string, decimal>();
            JsonConvert.PopulateObject(Encoding.UTF8.GetString(e.Message), data);
            if ( data.Keys.Contains("state"))
            {
                switch (data["state"])
                {
                    case 0:
                        progressBar1.Value = 0;
                        break;
                    case 1:
                        progressBar1.Value = 100;
                        break;
                    case 2:
                        progressBar1.Value = 50;
                        break;
                    default:
                        break;
                }
            }
            else if (data.Keys.Contains("OB"))
            {
                textBox1.Text += comboBox1.SelectedItem.ToString() + ":\t" + data["OB"] + "\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //{ "work_process":{ "SV":80,"appointment":2,"setTime":10} }
            var sv = numericUpDown1.Value;
            var appointment=  numericUpDown2.Value;
            var setTime= numericUpDown3.Value;
            var work_process = new Dictionary<string, decimal>();
            work_process.Add("SV", sv);
            work_process.Add("appointment", appointment);
            work_process.Add("setTime", setTime);
            //var dic = new Dictionary<string, Dictionary<string, decimal>>();
            //dic.Add("work_process", work_process);
            //string output = JsonConvert.SerializeObject(dic);
            //Global.Publish(output);
            send_order("work_process", work_process);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var value = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    value = "SV";
                    break;
                case 1:
                    value = "P";
                    break;
                case 2:
                    value = "I";
                    break;
                case 3:
                    value = "D";
                    break;
                default:
                    break;
            }
            send_order("read_mark", value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            send_order("cmd","on_off");
        }

        void send_order<T>(string cmd,T target)
        {
            var dic = new Dictionary<string, T>
            {
                { cmd, target }
            };
            string output = JsonConvert.SerializeObject(dic);
            Global.Publish(output);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            send_order("AT", 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            send_order("cmd", "updata");
        }
    }
}
