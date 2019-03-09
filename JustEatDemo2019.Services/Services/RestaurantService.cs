using JustEatDemo2019.Services.Clients;
using JustEatDemo2019.Services.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustEatDemo2019.Services.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IHttpClientHandler _restClient;
        private readonly string _baseUrl;

        public RestaurantService(IHttpClientHandler restClient)
        {
            _baseUrl = "https://public.je-apis.com/";
            _restClient = restClient;
        }

        public async Task<List<Restaurant>> GetRestaurantsByOutcode(string outcode)
        {
            var headers = GetCommonHeaders();   
            _restClient.SetHeaders(headers);
            var response = await _restClient.SendAsync(_baseUrl + $"restaurants?q={outcode}");

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode == false)
            {
                throw new ApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }

            var restaurantResponse = JsonConvert.DeserializeObject<RestaurantResponse>(await response.Content.ReadAsStringAsync());

            return restaurantResponse.Restaurants;
        }

        private Dictionary<string, string> GetCommonHeaders()
        {
            return new Dictionary<string, string>
            {
                {"Accept-Tenant", "uk"},
                {"Accept-Language", "en-GB"},
                {"Authorization", "Basic VGVjaFRlc3Q6bkQ2NGxXVnZreDVw"},
                {"Host", "public.je-apis.com"},
            };
        }

    }
}
