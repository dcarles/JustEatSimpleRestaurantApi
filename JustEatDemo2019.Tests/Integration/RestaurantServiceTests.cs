using JustEatDemo2019.Services.Clients;
using JustEatDemo2019.Services.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace JustEatDemo2019.Tests.Integration
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        [Test]
        public async Task GetRestaurantsByOutcode_Should_Returns_Data_For_The_Outcode_SE19()
        {
            // Given a valid outcode
            var outcode = "SE19";

            // When we call the service
            var client = new HttpClientHandler();
            var restaurantService = new RestaurantService(client);
            var results = await restaurantService.GetRestaurantsByOutcode(outcode);

            // Then the restaurant list is not null and not empty
            Assert.IsNotNull(results);
            Assert.Greater(results.Count, 0);
        }
    }
}
