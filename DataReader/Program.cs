using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataReader.Sensors;
using CSRedis;
using System.Threading;
using System.Configuration;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBus = int.Parse(ConfigurationManager.AppSettings["NAUTOBUS"]);
            int numLinea = int.Parse(ConfigurationManager.AppSettings["NLINEE"]);
            Random rnd = new Random();
            Thread[] threads = new Thread[numBus];

            for(int i=0; i<numBus; i++)
            {
                threads[i] = new Thread(() => Bus(i, rnd.Next(0, numLinea)));
                threads[i].Start();
                Thread.Sleep(1000);
            }
        }

        public static void Bus(int id, int l)
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
                    data = "{\"nautobus\": " + id + ",\"linea\": " + l + "," + sensor.ToJson();
                    Console.WriteLine(data);
                    redis.LPush("sensors_data", data);
                    Thread.Sleep(10000);
                }
            }
        }
    }
}
