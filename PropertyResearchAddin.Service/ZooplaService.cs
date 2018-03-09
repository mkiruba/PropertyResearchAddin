using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PropertyResearchAddin.Service.BO;

namespace PropertyResearchAddin.Service
{
    public class ZooplaService : IZooplaService
    {
        private const string apiKey = "psuy4qtt4u6nfy5r6mtrxdb9";
        public List<PropertyDetails> GetPrice(string postcode, string town)
        {     
            var propertyDetails = new List<PropertyDetails>();
            using (var client = new JsonServiceClient("http://api.zoopla.co.uk/api/v1/").WithCache())
            {
                client.GetAsync<string>($"property_listings.js?postcode={postcode}&api_key={apiKey}").ContinueWith(
                    task =>
                    {
                        var jsonObject = JObject.Parse(task.Result);
                        var salesData = jsonObject["listing"]
                            .Where(x => x["listing_status"].ToString() == "sale");
                        foreach (var s in salesData)
                        {
                            propertyDetails.Add(new PropertyDetails
                            {
                                DetailsUrl = s["details_url"].ToString(),
                                DisplayableAddress = s["displayable_address"].ToString(),
                                Price = Decimal.Parse(s["price"].ToString()),
                                PriceChangeSummary = new PriceChangeSummary
                                {
                                    Direction = s["price_change_summary"]["direction"].ToString(),
                                    Percent = s["price_change_summary"]["percent"].ToString(),
                                    LastUpdatedDate = DateTime.Parse(s["price_change_summary"]["last_updated_date"].ToString())
                                },
                                PriceChanges = s["price_change"].Select(x => new PriceChange
                                {
                                    Direction = x["direction"].ToString(),
                                    Percent = x["percent"].ToString(),
                                    Date = DateTime.Parse(x["date"].ToString()),
                                    Price = Decimal.Parse(x["price"].ToString()),
                                }).ToList(),
                            });
                        }
                        
                    }).Wait();
                
                return propertyDetails;
            }
        }
    }
}
