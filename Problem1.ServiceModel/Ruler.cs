using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.ServiceModel
{
    public class Ruler
    {
        public string RulerName { get; set; }
        public List<string> Allies { get; set; }

        public string UIFriendlyListOfAllies { get; set; }
    }
}
