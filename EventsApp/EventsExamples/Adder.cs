using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.EventsExamples
{
    delegate int dgPointer(int x, int y);

    public class Adder
    {
        public delegate void dgEventRaiser();
        public event dgEventRaiser OnEvenNumberResult;

        public event EventHandler OnAdd;
        public event EventHandler<AdderEventArgs> OnAddPerformed;



        public int Add(int x, int y)
        {
            int result = x + y;
            if (result % 2 == 0 && OnEvenNumberResult != null)
            {
                OnEvenNumberResult();
            }

            OnAdd?.Invoke(this, EventArgs.Empty);
            OnAddPerformed?.Invoke(this, new AdderEventArgs { Total = result, Message = "OK" });

            return result;
        }
    }

    public class AdderEventArgs : EventArgs
    {
        public int Total { get; set; }
        public string Message { get; set; }
    }
}
