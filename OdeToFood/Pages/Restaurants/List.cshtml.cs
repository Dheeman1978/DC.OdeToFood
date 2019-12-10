using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restuarants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }


        /*
         * ASP.NET Core, follows  Dependency Inversion principle. Tell framework, about IRestaurantData framework should
         * provide InMemoryRestaurantData, for that this needs to be registered as a service in Startup.cs file which 
         * will tell ASP.NET Core container about all services.
         * 
         *  services.AddSingleton<IRestaurantData, InMemoryRestaurantData>(); in public void ConfigureServices(IServiceCollection services) method
         *  
         */
        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            ViewData["RestaurantMetaData"] = "Restaurant Meta Information";
            //string searchTerm = HttpContext.Request.Query["searchTerm"];        
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}