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
                        var httpWebRequestData = (HttpWebRequest)WebRequest.Create("http://localhost:3000/api/data/");
                        httpWebRequestData.ContentType = "application/json";  
                        httpWebRequestData.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequestData.GetRequestStream()))
                        {
                            string dataJson = redis.BLPop(30, "sensors_data");
                            streamWriter.Write(dataJson);
                            streamWriter.Flush();
                            streamWriter.Close();
                        
                        }

                        var httpResponseData = (HttpWebResponse)httpWebRequestData.GetResponse();
                        using (var streamReader = new StreamReader(httpResponseData.GetResponseStream()))
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
