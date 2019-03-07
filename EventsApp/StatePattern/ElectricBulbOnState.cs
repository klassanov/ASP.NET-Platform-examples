using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.StatePattern
{
    public class ElectricBulbOnState : IElectricBulbState
    {
        public void SwitchOn(ElectricBulb bulb)
        {
            Console.WriteLine("The bulb is already on!!!");           
        }       

        public void SwitchOff(ElectricBulb bulb)
        {
            Console.WriteLine("Switching off");
            bulb.State = new ElectricBulbOffState();
            bulb.RaiseOnStateChanged();
        }

        public void ReportState()
        {
            Console.WriteLine("On");
        }
    }
}
