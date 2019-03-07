using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.IndexerExample
{
    public class IndexerExamples
    {
        public static void Scenario1()
        {
            NamesContainer container = new NamesContainer();
            Console.WriteLine(container["Penko"]);
            Console.WriteLine(container["Metodi"]);

            container["Sashko"] = "Kukumicin";
            Console.WriteLine(container["Sashko"]);
        }
    }
}
