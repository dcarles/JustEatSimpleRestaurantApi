using System;
using System.Collections.Generic;

namespace JustEatDemo2019.Services.Models
{
    public class Restaurant
    {
        public float Score { get; set; }
        public float DeliveryCost { get; set; }
        public float MinimumDeliveryValue { get; set; }
        public int? DeliveryTimeMinutes { get; set; }
        public int? DeliveryWorkingTimeMinutes { get; set; }
        public DateTime OpeningTime { get; set; }
        public float RatingAverage { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
        public string Url { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsNew { get; set; }
        public bool IsTemporarilyOffline { get; set; }
        public string ReasonWhyTemporarilyOffline { get; set; }
        public string UniqueName { get; set; }
        public bool IsCloseBy { get; set; }
        public bool IsOpenNowForDelivery { get; set; }
        public bool IsOpenNowForCollection { get; set; }
        public float RatingStars { get; set; }
        public List<Logo> Logo { get; set; }
        public List<Deal> Deals { get; set; }
        public int NumberOfRatings { get; set; }
        public int DefaultDisplayRank { get; set; }
    }   

    public class Logo
    {
        public string StandardResolutionURL { get; set; }
    }

   

}
