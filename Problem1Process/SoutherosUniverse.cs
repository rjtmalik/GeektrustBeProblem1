using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace Problem1.Process
{
    public class SoutherosUniverse
    {
        public SoutherosUniverse()
        {
            _kingdoms = MemorizeAvailableKingdoms();
        }

        private Kingdom[] _kingdoms;

        /// <summary>
        /// Gets all kingdoms present in the southeros universe
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        private Kingdom[] MemorizeAvailableKingdoms()
        {
            var result = new Kingdom[] { };
            using (XmlReader reader = XmlReader.Create(Path.Combine(Directory.GetCurrentDirectory(), "Country.xml")))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "Name":
                                string name = reader.ReadString();

                                reader.ReadToNextSibling("Embelem");
                                string embelem = reader.ReadString();

                                reader.ReadToNextSibling("King");
                                string king = reader.ReadString();
                                result = result.Concat(new Kingdom[] { new Kingdom(name, embelem, king) }).ToArray();
                                break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the allies if the invasion succeeds
        /// </summary>
        /// <param name="invadorName"></param>
        /// <param name="invadedKingdomsAndMsgs"></param>
        /// <returns></returns>
        public string[] Invasion(string invadorName, string[] invadedKingdomsAndMsgs)
        {
            var invadorKingdom = _kingdoms.FirstOrDefault(x => x.IsMe(invadorName));
            if (invadorKingdom == null) throw new Exception($"{invadorName} is not a kingdom of Southeros.");

            if (invadedKingdomsAndMsgs.Length < 3)
            {
                return new string[] { };
            }

            foreach (var invasion in invadedKingdomsAndMsgs)
            {
                var splitted = invasion.Split(new char[] { ',' }, StringSplitOptions.None);
                var invadedName = splitted[0];
                var target = _kingdoms.FirstOrDefault(x => x.IsMe(invadedName));
                if (target == null) throw new Exception($"{invadedName} is not a kingdom of Southeros.");
                if (string.Equals(target.Name, invadorKingdom.Name, StringComparison.OrdinalIgnoreCase))
                    throw new Exception($"{invadorKingdom.Name} can't invade herself.");
                var message = splitted[1];
                invadorKingdom.TryForgingAlliance(target, message);
            }

            var allies = invadorKingdom.Allies();
            var allyAddedMultipleTimes = allies.GroupBy(x => x.Name).FirstOrDefault(x => x.Count() > 1);
            if (allyAddedMultipleTimes != null) throw new Exception($"{allyAddedMultipleTimes.Key} is present multiple times");
            if (allies.Length > 2)
            {
                return allies.Select(x => x.Name).ToArray();
            }
            return new string[] { };
        }
    }
}
