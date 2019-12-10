using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent
        :ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            RestaurantDetails restaurantDetails = new RestaurantDetails();
            restaurantDetails.AuthorFirstName = "Dheeman";
            restaurantDetails.AuthorLastName = "Chakravorty";
            restaurantDetails.RestaurantCount = restaurantData.GetCountOfRestaurants();
            var count = restaurantData.GetCountOfRestaurants();
            return View(restaurantDetails);
        }
    }
}
