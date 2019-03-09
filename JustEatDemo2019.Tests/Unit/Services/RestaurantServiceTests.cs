
using FluentAssertions;
using JustEatDemo2019.Services.Clients;
using JustEatDemo2019.Services.Models;
using JustEatDemo2019.Services.Services;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JustEatDemo2019.Tests.Unit.Services
{
    /// <summary>
    /// Summary description for RestaurantServiceTests
    /// </summary>
    [TestFixture]
    public class RestaurantServiceTests
    {
        [Test]
        public async Task GetRestaurantsByOutcode_Should_Returns_Restaurants_When_API_Call_Succeeds()
        {

            // Given a valid outcode
            var outcode = "SE19";

            // When we call the service
            var mockClient = new Mock<IHttpClientHandler>();

            var dummyRestaurants = GetDummyResponse();
            var response = new HttpResponseMessage
            {
                Content = new StringContent(dummyRestaurants),
                StatusCode = HttpStatusCode.OK
            };
            mockClient.Setup(r => r.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(response));

            var restaurantService = new RestaurantService(mockClient.Object);
            var actual = await restaurantService.GetRestaurantsByOutcode(outcode);
                       
            // Then the restaurant list is not null and not empty
            Assert.IsNotNull(actual);
            Assert.Greater(actual.Count, 0);

            // And the restaurant list is as expected
            var expected = GetDummyListOfRestaurants(dummyRestaurants);
            actual.Should().BeEquivalentTo(expected);
        }


        [Test]
        public async Task GetRestaurantsByOutcode_Should_Returns_Empty_List_of_Restaurants_If_Postcode_Invalid_Or_No_Restaurants_In_The_Area()
        {

            // Given a valid outcode
            var outcode = "INVALID";

            // When we call the service
            var mockClient = new Mock<IHttpClientHandler>();

            var dummyRestaurants = GetEmptyResponse();

            var response = new HttpResponseMessage
            {
                Content = new StringContent(dummyRestaurants),
                StatusCode = HttpStatusCode.OK
            };

            mockClient.Setup(r => r.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(response));

            var restaurantService = new RestaurantService(mockClient.Object);
            var actual = await restaurantService.GetRestaurantsByOutcode(outcode);

            // Then the restaurant list is not null and is empty
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, 0);

            // And the restaurant list is as expected
            var expected = GetDummyListOfRestaurants(dummyRestaurants);
            actual.Should().BeEquivalentTo(expected);
        }


        [Test]
        public async Task GetRestaurantsByOutcode_Should_Throw_Api_Exception_If_Api_Response_Code_Is_Not_Succesful()
        {

            // Given a valid outcode
            var outcode = "INVALID";

            // When we call the service
            var mockClient = new Mock<IHttpClientHandler>();

            var dummyRestaurants = GetEmptyResponse();

            var response = new HttpResponseMessage
            {
                Content = new StringContent(dummyRestaurants),
                StatusCode = HttpStatusCode.InternalServerError
            };

            mockClient.Setup(r => r.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(response));

            var restaurantService = new RestaurantService(mockClient.Object);
          
            Assert.ThrowsAsync<ApiException>(async () => await restaurantService.GetRestaurantsByOutcode(outcode));
                       
        }


        private String GetDummyResponse()
        {
            using (StreamReader r = new StreamReader("JustEatDemo2019.Tests\\Restaurants.json"))
            {
                return r.ReadToEnd();
            }
        }

        private String GetEmptyResponse()
        {
            using (StreamReader r = new StreamReader("JustEatDemo2019.Tests\\EmptyResponse.json"))
            {
                return r.ReadToEnd();
            }
        }


        private List<Restaurant> GetDummyListOfRestaurants(string content)
        {
            var response = JsonConvert.DeserializeObject<RestaurantResponse>(content);
            return response.Restaurants;
        }

    }
}
