using System.Collections.Generic;

namespace JustEatDemo2019.Services.Models
{
    public class RestaurantResponse
    {
        public List<Restaurant> Restaurants { get; set; }
        public List<string> Errors { get; set; }
        public bool HasErrors { get; set; }
    }
}
