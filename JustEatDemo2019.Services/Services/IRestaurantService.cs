using JustEatDemo2019.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEatDemo2019.Services.Services
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetRestaurantsByOutcode(string outcode);
    }
}
