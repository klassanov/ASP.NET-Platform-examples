using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.StatePattern
{
    public class ElectricBulbOffState : IElectricBulbState
    {
        public void SwitchOn(ElectricBulb bulb)
        {
            Console.WriteLine("Switching On");
            bulb.State = new ElectricBulbOnState();
            bulb.RaiseOnStateChanged();
        }

        public void SwitchOff(ElectricBulb bulb)
        {
            Console.WriteLine("The bulb is already off!!!");
        }

        public void ReportState()
        {
            Console.WriteLine("Off");
        }
    }
}
