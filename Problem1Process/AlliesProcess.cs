using Problem1.Model;
using Problem1.Process.Contracts;
using System.Collections.Generic;

namespace Problem1Process
{
    public class AlliesProcess : IAlliesProcess
    {
        public AllianceResponse EvaluateAlliance(IEnumerable<AllianceRequest> requests, string rulingCountryName)
        {
            var candidateToRule = new Country(rulingCountryName);
            foreach (var messageDTO in requests)
            {
                var possibleAlly = new Country(messageDTO.Country);
                candidateToRule.ForgeAlliance(messageDTO.SecretMessage, possibleAlly);
            }
            if (candidateToRule.IsRulerOfSoutheros)
            {
                return new AllianceResponse(candidateToRule.KingName, candidateToRule.Allies);
            }
            else
            {
                return new AllianceResponse("None", new string[0] { });
            }
        }
    }
}
