using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.StatePattern
{
    public interface IElectricBulbState
    {
        void SwitchOn(ElectricBulb bulb);
        void SwitchOff(ElectricBulb bulb);
        void ReportState();
    }
}
