using System.Collections.Generic;
using PropertyResearchAddin.Service.BO;

namespace PropertyResearchAddin.Service
{
    public interface IZooplaService
    {
        List<PropertyDetails> GetPrice(string postcode, string town);
    }
}