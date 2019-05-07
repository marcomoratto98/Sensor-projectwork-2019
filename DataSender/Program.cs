using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace DataSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = new RedisClient("127.0.0.1");

            while (true)
            {
                    try
                    {
                        var httpWebRequestDistance = (HttpWebRequest)WebRequest.Create("http://localhost:3000/api/distance/");
                        httpWebRequestDistance.ContentType = "application/json";  
                        httpWebRequestDistance.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequestDistance.GetRequestStream()))
                        {
                            string distanceJson = redis.BLPop(30, "sensors_data");
                            streamWriter.Write(distanceJson);
                            streamWriter.Flush();
                            streamWriter.Close();
                        
                        }

                        var httpResponseDistance = (HttpWebResponse)httpWebRequestDistance.GetResponse();
                        using (var streamReader = new StreamReader(httpResponseDistance.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
            }
        }
    }
}
