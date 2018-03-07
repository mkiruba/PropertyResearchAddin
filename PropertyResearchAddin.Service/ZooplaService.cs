using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyResearchAddin.Service
{
    public class ZooplaService : IZooplaService
    {
        public decimal GetPrice()
        {            
            using (var client = new JsonServiceClient("").WithCache())
            {
                var result = client.GetAsync<dynamic>("http://api.zoopla.co.uk/api/v1/property_listings.xml?postcode=IG10+1TH&api_key=psuy4qtt4u6nfy5r6mtrxdb9");
                return 100.00M;
            }
        }
    }
}
