using System.Collections.Generic;

namespace PropertyResearchAddin.Service.BO
{
    public class PropertyDetails
    {
        public string DisplayableAddress { get; set; }
        public string DetailsUrl { get; set; }
        public decimal Price { get; set; }
        public List<PriceChange> PriceChanges { get; set; }
        public PriceChangeSummary PriceChangeSummary { get; set; }
    }
}
