using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Sensors
{
    class VirtualDoorSensor : IDoorSensor, ISensor
    {
        public void SetDoor(decimal people)
        { }

        public decimal GetPeopleNumber()
        {
            Random random = new Random();
            return new decimal(random.Next(1, 15));
        }

        public string ToJson()
        {
            return "{\"people\":\"" + GetPeopleNumber() + "\",\"date\":\"" + DateTime.Now + "\"}";
        }
    }
}
