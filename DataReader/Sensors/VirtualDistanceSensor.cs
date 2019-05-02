using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Sensors
{
    class VirtualDistanceSensor: IDistanceSensor, ISensor
    {
        public void SetDistance(decimal distance)
        { }

        public decimal GetDistanceN()
        {
            Random random = new Random();
            return new decimal(random.Next(100, 999));
        }

        public decimal GetDistanceE()
        {
            Random random = new Random();
            return new decimal(random.Next(100, 999));
        }

        public string ToJson()
        {
            return "{\"distance\":[\"46.000" + GetDistanceN() + "\",\"" + "13.000" + GetDistanceE() +"\"],\"date\":\"" + DateTime.Now + "\"}";
        }
    }
}
