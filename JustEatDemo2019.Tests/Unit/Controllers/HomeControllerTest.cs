using System.Web.Mvc;
using JustEatDemo2019.Controllers;
using JustEatDemo2019.Services.Clients;
using JustEatDemo2019.Services.Services;
using Moq;
using NUnit.Framework;


namespace JustEatDemo2019.Tests.Unit.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var mockClient = new Mock<IHttpClientHandler>();
            var restaurantService = new RestaurantService(mockClient.Object);
            var controller = new HomeController(restaurantService);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
