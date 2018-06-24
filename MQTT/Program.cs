using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace MQTT
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    static class Global
    {
        public static MqttClient client= null;
        public static string pubTopic = "master_computer";
        public static string subTopic = "slave_computer";
        public static string dpTopic = "$dp";
        public static void Publish(string buff)
        {
            if (client is MqttClient && client.IsConnected)
            {
                client.Publish(pubTopic, Encoding.UTF8.GetBytes(buff));
            }
        }
    }
}
