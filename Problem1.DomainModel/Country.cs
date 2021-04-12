using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Problem1.Model
{
    public class Country
    {
        public string Name { get; private set; }
        public string Embelem { get; private set; }
        public string KingName { get; private set; }
        public IEnumerable<string> Allies { get; private set; }
        public bool IsRulerOfSoutheros { get; private set; }
        public void ForgeAlliance(string secretMessage, Country possibleAlly)
        {
            if (!this.Allies.Contains(possibleAlly.Name))
            {
                var occurencesInEmbelem = GetOccurences(possibleAlly.Embelem);
                var occurencesInMessage = GetOccurences(secretMessage);
                if (!this.Allies.Contains(possibleAlly.Name))
                {
                    if (IsSecretMessage(occurencesInEmbelem, occurencesInMessage))
                    {
                        this.Allies = this.Allies.Concat(new string[] { possibleAlly.Name });
                    }
                }
            }
            if (this.Allies.Count() > 2)
            {
                this.IsRulerOfSoutheros = true;
            }
        }

        private Dictionary<char, int> GetOccurences(string dataString)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var item in dataString)
            {
                var lowerCased = char.ToLowerInvariant(item);
                if (dic.ContainsKey(lowerCased))
                {
                    dic[lowerCased] = dic[lowerCased] + 1;
                }
                else
                    dic.Add(lowerCased, 1);
            }
            return dic;
        }
        private bool IsSecretMessage(Dictionary<char, int> occurencesInEmbelem, Dictionary<char, int> occurencesInMessage)
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

        public Country(string country)
        {
            FillProperties(country);
            IsRulerOfSoutheros = false;
            Allies = new string[0] { };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public void FillProperties(string country)
        {
            List<Country> countries = new List<Country>();
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
                                if (name.Equals(country, StringComparison.OrdinalIgnoreCase))
                                {
                                    this.Embelem = embelem;
                                    this.Name = name;
                                    this.KingName = king;
                                }
                                break;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new ArgumentOutOfRangeException(nameof(country), "Not a valid Country in Southeros");
            }
        }
    }
}
