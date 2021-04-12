using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1.Process
{
    public class Kingdom
    {
        public Kingdom(string name, string embelem, string kingName)
        {
            Name = name;
            Embelem = embelem;
            KingName = kingName;
            _allies = new Kingdom[] { };
        }

        public string Name { get; private set; }
        public string Embelem { get; private set; }
        public string KingName { get; private set; }

        private Kingdom[] _allies;

        public void TryForgingAlliance(Kingdom targetKingdom, String message)
        {
            if (targetKingdom.Name == Name)
            {
                throw new Exception($"{Name} can't send message to herself");
            }
            var hasConceded = targetKingdom.WillConcede(message);
            if (hasConceded)
                _allies = _allies.Concat(new Kingdom[] { targetKingdom }).ToArray();
        }

        public bool WillConcede(string message)
        {
            var occurencesInEmbelem = GetOccurences(Embelem);
            var occurencesInMessage = GetOccurences(message);
            return IsSecretMessageAccepted(occurencesInEmbelem, occurencesInMessage);
        }

        private Dictionary<char, int> GetOccurences(string dataString)
        {
            var result = new Dictionary<char, int>();
            foreach (var item in dataString)
            {
                var lowerCased = char.ToLowerInvariant(item);
                if (result.ContainsKey(lowerCased))
                    result[lowerCased] = result[lowerCased] + 1;
                else
                    result.Add(lowerCased, 1);
            }
            return result;
        }

        private bool IsSecretMessageAccepted(Dictionary<char, int> occurencesInEmbelem, Dictionary<char, int> occurencesInMessage)
        {
            foreach (var item in occurencesInEmbelem)
            {
                if (occurencesInMessage.ContainsKey(item.Key))
                {
                    if (item.Value > occurencesInMessage[item.Key])
                        return false;
                }
                else
                    return false;
            }
            return true;
        }

        public bool IsMe(string name)
        {
            return string.Equals(name, Name, StringComparison.OrdinalIgnoreCase);
        }

        public Kingdom[] Allies()
        {
            return _allies;
        }
    }
}