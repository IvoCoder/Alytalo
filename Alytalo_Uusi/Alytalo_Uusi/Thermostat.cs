using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alytalo_Uusi
{
    public class Thermostat
    {

        public int Temperature { get; set; }

        public void LampotilanAsetus (int NewTemperature)
        {
            Temperature = NewTemperature;
        }
    }
}
