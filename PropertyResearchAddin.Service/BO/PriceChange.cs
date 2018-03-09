using System;

namespace PropertyResearchAddin.Service.BO
{
    public class PriceChange
    {
        public string Direction { get; set; }
        public string Percent { get; set; }
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
    }
}
