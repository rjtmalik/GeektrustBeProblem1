using Problem1.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Problem1DAL
{
    public class CountryDAL : ICountryDAL
    {
        /// <summary>
        /// Verifies the validity of the country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public bool IsValidCountry(string country)
        {
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
                                var c = reader.ReadString();
                                if (string.Equals(c, country, StringComparison.OrdinalIgnoreCase))
                                {
                                    return true;
                                }
                                break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
