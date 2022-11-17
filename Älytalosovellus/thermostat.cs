using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Älytalosovellus
{
    class thermostat
    {
        public int Temperature { get; set; }

        public void setTemperature(int uusilampo)
        {
            this.Temperature = uusilampo;
        }

    }
}
