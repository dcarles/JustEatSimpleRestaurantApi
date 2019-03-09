using JustEatDemo2019.Services.Models;
using System;
using System.Linq;

namespace JustEatDemo2019.Models
{
    public class RestaurantViewModel
    {

        public RestaurantViewModel(Restaurant restaurant)
        {
            Logo = restaurant.Logo != null && restaurant.Logo.Any() ? restaurant.Logo.First().StandardResolutionURL : "/Images/je-logo.png";
            Name = restaurant.Name;
            Rating = restaurant.RatingStars;
            NumberOfRatings = restaurant.NumberOfRatings;
            CuisineTypes = restaurant.CuisineTypes != null && restaurant.CuisineTypes.Any() ? string.Join(", ", restaurant.CuisineTypes.Select(c => c.Name).ToArray()) : "";
            Address = restaurant.Address + ", " + restaurant.City + ", " + restaurant.Postcode;
            IsOpenNow = restaurant.IsOpenNow;
        }



        public double DisplayRating
        {
            get
            {
                return Math.Round(Rating*2, MidpointRounding.AwayFromZero)/2;
            }
        }

        public string Logo { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public string CuisineTypes { get; set; }
        public string Address { get; set; }
        public bool IsOpenNow { get; set; }

    }
}