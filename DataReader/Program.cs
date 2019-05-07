using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataReader.Sensors;
using CSRedis;
using System.Windows.Forms;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISensor> sensors = new List<ISensor>
            {
                new VirtualDataSensor()
            };

            var redis = new RedisClient("127.0.0.1");
            Random rnd = new Random();

            while (true)
            {
                foreach (ISensor sensor in sensors)
                {
                    var num = rnd.Next(1, 100);
                    var data = "";

                    if (num > 80 && num < 100)
                    {
                        sensor.SetPorte(true);
                    }
                    else
                    {
                        sensor.SetPorte(false);
                    }
                    data = sensor.ToJson();
                    Console.WriteLine(data);
                    redis.LPush("sensors_data", data);
                    System.Threading.Thread.Sleep(10000);
                }
            }
        }
    }
}
