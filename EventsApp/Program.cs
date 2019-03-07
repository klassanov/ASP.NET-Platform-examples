using EventsApp.EventsExamples;
using EventsApp.IndexerExample;
using EventsApp.StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Examples.Scenario1();
            //Examples.Scenario2();
            // Examples.Scenario3();
            //Examples.Scenario4();

            //BulbExamples.Scenario1();
            //BulbExamples.Scenario2();

            IndexerExamples.Scenario1();

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
