using JustEatDemo2019.Models;
using JustEatDemo2019.Services.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JustEatDemo2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public HomeController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Restaurants", new { outcode = model.Outcode });
        }


        [HttpGet]
        [Route("Restaurants/Area/{outcode}", Name = "Restaurants")]
        public async Task<ActionResult> Restaurants(string outcode)
        {
            try
            {
                var restaurants = await _restaurantService.GetRestaurantsByOutcode(outcode);

                var model = new RestaurantsResultViewModel
                {
                    Outcode = outcode,
                    Restaurants = restaurants.OrderBy(r => r.DefaultDisplayRank).Select(r => new RestaurantViewModel(r)).ToList()
                };
                return View(model);

            }
            catch (ApiException)
            {
                //TODO:Log Exception
               return RedirectToAction("Index", "Error");
            }

        }


        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;

        //    //Log the error!!
        //    _Logger.Error(filterContext.Exception);

        //    //Redirect or return a view, but not both.
        //    filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        //    // OR 
        //    filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/ErrorHandler/Index.cshtml"
        //    };
        //}

    }
}