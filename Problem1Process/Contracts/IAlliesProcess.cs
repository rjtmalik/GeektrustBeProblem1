using Problem1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Process.Contracts
{
    public interface IAlliesProcess
    {
        AllianceResponse EvaluateAlliance(IEnumerable<AllianceRequest> messages, string rulingCountryName);
    }
}
