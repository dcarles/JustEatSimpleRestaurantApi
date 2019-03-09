using JustEatDemo2019.Models;
using JustEatDemo2019.Services.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace JustEatDemo2019.Tests.Unit.Models
{
    /// <summary>
    /// Summary description for RestaurantViewModelTests
    /// </summary>
    [TestFixture]
    public class RestaurantViewModelTests
    {
        [Test]
        public void Restaurant_Should_Map_To_RestaurantViewModel()
        {
            // Arrange
            var restaurant = new Restaurant
            {
                Logo = new List<Logo>
                {
                    new Logo
                    {
                        StandardResolutionURL = "/Images/je-logo.png"
                    }
                },
                Name = "Test Restaurant",
                RatingStars =  4.72f,
                CuisineTypes = new List<CuisineType>
                {
                   new CuisineType{Name = "Chinese"},
                   new CuisineType {Name = "Thai"}
                }
            };

            var cuisineStrings = restaurant.CuisineTypes.Select(c => c.Name).ToArray();
            var delimitedCuisine = string.Join(", ", cuisineStrings);

            // Act
            var restaurantViewModel = new RestaurantViewModel(restaurant);

            // Assert
            Assert.AreEqual(restaurantViewModel.CuisineTypes, delimitedCuisine);
            Assert.AreEqual(restaurantViewModel.Name, restaurant.Name);
            Assert.AreEqual(restaurantViewModel.Rating, restaurant.RatingStars);
        }
    }
}
