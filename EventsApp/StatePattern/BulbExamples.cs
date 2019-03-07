using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.StatePattern
{
    public class BulbExamples
    {
        public static void Scenario1()
        {
            ExecuteStandardSequence(new ElectricBulb());
        }

        public static void Scenario2()
        {
            ElectricBulb bulb = new ElectricBulb();
            bulb.OnStateChanged += (sender, args) => Console.WriteLine("State changed");
            ExecuteStandardSequence(bulb);
        }

        private static void ExecuteStandardSequence(ElectricBulb bulb)
        {
            bulb.ReportStatus();
            bulb.SwitchOn();
            bulb.ReportStatus();
            bulb.SwitchOff();
            bulb.ReportStatus();
            bulb.SwitchOff();
            bulb.ReportStatus();
            bulb.SwitchOn();
            bulb.ReportStatus();
            bulb.SwitchOn();
            bulb.ReportStatus();
        }
    }
}
