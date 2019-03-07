using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.StatePattern
{
    public class ElectricBulb
    {
        public IElectricBulbState State { get; set; }
        public event EventHandler OnStateChanged;

        public ElectricBulb()
        {
            this.State = new ElectricBulbOffState();
        }

        public ElectricBulb(IElectricBulbState state)
        {
            this.State = state;
        }

        public void SwitchOn()
        {
            this.State.SwitchOn(this);
        }

        public void SwitchOff()
        {
            this.State.SwitchOff(this);
        }

        public void ReportStatus()
        {
            this.State.ReportState();
        }

        public void RaiseOnStateChanged()
        {
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
