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
            Application.Run(new Principale());

            // init sensors
            List<ISensor> sensors = new List<ISensor>
            {
                new VirtualDistanceSensor()
            };

            // configure Redis
            var redis = new RedisClient("127.0.0.1");

            while (true)
            {
                foreach (ISensor sensor in sensors)
                {
                    // get current sensor value
                    var data = sensor.ToJson();
                    Console.WriteLine(data);

                    // push to redis queue
                    redis.LPush("sensors_data", data);

                    // wait 10 second
                    System.Threading.Thread.Sleep(200);

                }
            }
        }
    }
}
