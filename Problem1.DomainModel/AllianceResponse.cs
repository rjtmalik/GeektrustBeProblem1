using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Model
{
    public struct AllianceResponse
    {
        public AllianceResponse(string rulerName, IEnumerable<string> allies)
        {
            this.Allies = allies;
            this.RulerName = rulerName;
            StringBuilder builder = new StringBuilder();
            var countOfAllies = allies.Count();
            foreach (var ally in allies)
            {
                builder.Append(string.Concat(ally[0], new string(ally.Skip(1).ToArray()).ToLowerInvariant()));
                countOfAllies = countOfAllies - 1;
                if (countOfAllies > 0)
                {
                    builder.Append(", ");
                }
            }
            this.UIFriendlyListOfAllies = builder.ToString();
        }
        public string RulerName { get; private set; }
        public IEnumerable<string> Allies { get; private set; }

        public string UIFriendlyListOfAllies { get; private set; }
    }
}
