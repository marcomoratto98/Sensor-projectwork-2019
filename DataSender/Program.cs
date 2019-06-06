using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;

namespace DataSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = new RedisClient("127.0.0.1");
            string url = new AppSettingsReader().GetValue("URLAPI", typeof(string)).ToString();
            //int counter = 0;
            //string line;
            //string[] split;

            /*
            try
            {
                StreamReader file = new StreamReader(@"..\..\..\config.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("URLAPI:"))
                    {
                        split = line.Split(new char[] { ':' }, 2);
                        url = split[1].ToString();
                    }
                    counter++;
                }
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("File non trovato");
            }*/

            while (true)
            {
                    try
                    {
                        var httpWebRequestData = (HttpWebRequest)WebRequest.Create(url);
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
