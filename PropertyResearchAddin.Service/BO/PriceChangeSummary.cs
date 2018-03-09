using System;

namespace PropertyResearchAddin.Service.BO
{
    public class PriceChangeSummary
    {
        public string Direction { get; set; }
        public string Percent { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
