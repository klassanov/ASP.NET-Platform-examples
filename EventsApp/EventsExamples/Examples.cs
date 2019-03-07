using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.EventsExamples
{
    public class Examples
    {
        public static void Scenario1()
        {
            Adder adder = new Adder();
            dgPointer pAdder = new dgPointer(adder.Add);
            int result = pAdder(3, 2);
            Console.WriteLine("Result: " + result);
        }

        public static void Scenario2()
        {
            Adder adder = new Adder();

            adder.OnEvenNumberResult += () => Console.WriteLine("Even result!");
            adder.OnEvenNumberResult += PrintEvenResult;
            adder.OnEvenNumberResult += new Adder.dgEventRaiser(PrintEvenResult2);

            Console.WriteLine("Result: " + adder.Add(1, 1));
            Console.WriteLine("Result: " + adder.Add(1, 2));
        }

        public static void Scenario3()
        {
            Adder adder = new Adder();
            adder.OnAdd += (sender, args) => Console.WriteLine("Add called");
            adder.OnAdd += OnAddHandler;

            adder.Add(1, 2);

        }

        public static void Scenario4()
        {
            Adder adder = new Adder();
            adder.OnAddPerformed += (sender, args) =>
            {
                Console.WriteLine("Add performed: " + args.Total + " " + args.Message);
            };

            adder.Add(3, 5);
        }

        private static void OnAddHandler(object sender, EventArgs args)
        {
            Console.WriteLine(sender.ToString() + ": Add called!!!");
        }

        private static void PrintEvenResult()
        {
            Console.WriteLine("Even result!!!");
        }

        private static void PrintEvenResult2()
        {
            Console.WriteLine("Even result!!!!!!!");
        }
    }
}
