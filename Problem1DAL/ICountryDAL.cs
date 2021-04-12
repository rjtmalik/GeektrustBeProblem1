using Problem1.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1DAL
{
    public interface ICountryDAL
    {
        /// <summary>
        /// Verifies the validity of the country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        bool IsValidCountry(string country);
    }
}
