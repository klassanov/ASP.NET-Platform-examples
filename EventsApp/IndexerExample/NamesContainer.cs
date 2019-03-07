using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.IndexerExample
{
    public class NamesContainer
    {
        private Dictionary<string, string> NamesDict;

        public NamesContainer()
        {
            NamesDict = new Dictionary<string, string>()
            {
                { "Penko", "Patarinski" },
                {"Metodi", "Georgiev" },
                {"Alexander", "Klassanov" }
            };            
        }        

        public string this[string name]
        {
            get { return NamesDict[name]; }
            set { NamesDict[name] = value; }
        }
    }
}
