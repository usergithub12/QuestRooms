using QuestRoom.BLL.Services.Abstraction;
using QuestRoom.BLL.Services.Implementation;
using QuestRooms.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        private readonly ICitiesService citiesService;
        public TestController(ICitiesService _citiesService)
        {
            citiesService = _citiesService;
        }
        public ActionResult Index()
        {
          var cities=  citiesService.GetCities().Select(cty => new CityViewModel { Id = cty.Id, Name = cty.Name }).ToList<CityViewModel>();
            return View(cities);
        }
    }
}