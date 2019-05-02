using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataReader.Sensors;
using CSRedis;

namespace DataReader
{
    public partial class Principale : Form
    {
        public Principale()
        {
            InitializeComponent();
        }

        IRedisClient redis = new RedisClient("127.0.0.1");
        private void BtnPorte_Click(object sender, EventArgs e)
        {
            ISensor porte = new VirtualDoorSensor();
            var data = porte.ToJson();
            Console.WriteLine(data);

            redis.LPush("doors_data", data);
        }

        private void Principale_Load(object sender, EventArgs e)
        {
            
        }
    }
}
