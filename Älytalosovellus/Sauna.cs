using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Älytalosovellus
{
    class Sauna
    {

        public Boolean Switched { get; set; }
        public double Lampotila { get; set; }
        public double saunaMaxTemp;
        public Sauna()
        {
            this.Switched = false;
            this.Lampotila = 22;
        }

        public void laitaSaunaPaalle()
        {
            this.Switched = true;
        }
        public void laitaSaunaPoisPaalta()
        {
            this.Switched = false;
        }
        public void SaunanLampoYlos()
        {
            Lampotila = Lampotila + 0.5;
        }
        public void SaunanLampoAlas()
        {
            Lampotila = Lampotila - 1;
        }
        public double SaunaMaxTemp
        {
            get
            {
                return saunaMaxTemp;
            }

            set
            {
                if ((value > 22) && (value <= 70))
                {
                    saunaMaxTemp = value;
                }
                else
                {
                    saunaMaxTemp = 22;
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
