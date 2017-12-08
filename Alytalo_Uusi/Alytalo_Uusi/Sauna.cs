using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alytalo_Uusi
{
   public class Sauna
    {

        public bool Switched { get; set; }
        public double SaunaTemperature { get; set; }

        public void AsetaSauna (int tila)
        {
            if ( tila == 0)
                {
                    Switched = false;
                    SaunaTemperature = 20.01;
                }
            else
                {
                    Switched = true;
                }
        }

    }
}
