using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Sensors
{
     interface IDataSensor
     {
        void SetDistance(decimal distance);
        decimal GetDistanceN();
        decimal GetDistanceE();
        decimal GetPeopleNumber();
    }
}
