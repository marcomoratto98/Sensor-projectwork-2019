using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Sensors
{
    class VirtualDataSensor: IDataSensor, ISensor
    {
        private decimal n = 0;
        private bool aperturaPorte = false;
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
        public decimal GetPeopleNumber()
        {
            Random random = new Random();
            return new decimal(random.Next(1, 15));
        }
        public decimal GetAutobusNumber()
        {
            Random random = new Random();
            return new decimal(random.Next(1, 3));
        }
        public string GetLinea()
        {
            Random random = new Random();
            decimal x = new decimal(random.Next(0, 2));
            if (x % 2 == 0)
                return "2";
            else
                return "1";
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
            return "{\"distance\":[\"46.000" + GetDistanceN() + "\",\"" + "13.000" + GetDistanceE() + "\"], \"people\":\"" + n + "\",\"date\":\"" + DateTime.Now + "\",\"porte\":\"" + aperturaPorte + "\",\"numeroAutobus\":\"" + GetAutobusNumber() + "\",\"linea\":\"" + GetLinea() + "\"}";
        }
    }
}
