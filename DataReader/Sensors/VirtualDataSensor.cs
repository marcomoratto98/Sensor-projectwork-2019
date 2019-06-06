using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Sensors
{
    class VirtualDataSensor : IDataSensor, ISensor
    {
        private decimal n = 0;
        private bool aperturaPorte = false;
        private Random random = new Random();
        
        public void SetDistance(decimal distance)
        { }

        public decimal GetDistanceN()
        {
            return new decimal(random.Next(100, 999));
        }

        public decimal GetDistanceE()
        {
            return new decimal(random.Next(100, 999));
        }
        public decimal GetPeopleNumber()
        {
            return new decimal(random.Next(1, 15));
        }
        public void SetPorte(bool apertura)
        {
            if (apertura)
                n = GetPeopleNumber();
            else
                n = 0;
            aperturaPorte = apertura;
        }

        public string ToJson()
        {
            return "\"distance\":[\"46.000" + GetDistanceN() + "\",\"" + "13.000" + GetDistanceE() + "\"], \"people\": " + n + ",\"date\":\"" + DateTime.Now + "\",\"porte\": " + aperturaPorte.ToString().ToLower() + "}";
        }
    }
}
