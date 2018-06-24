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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Global.client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            textBox1.Text += "@Receive:" + e.Topic + "->\t" + System.Text.Encoding.UTF8.GetString(e.Message) + "\r\n";
        }

        //void client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        //{
        //    // write your code
        //}

        //void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        //{
        //    // write your code
        //}

        //void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        //{
        //    // write your code
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            string buff = textBox2.Text;
            Global.Publish(buff);
        }
    }
    
}
