using QuestRoom.BLL.Services.Abstraction;
using QuestRooms.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsService roomsService;

        private readonly ICitiesService citiesService;
        // GET: Rooms

        public RoomsController(IRoomsService _roomsService,ICitiesService _citiesService)
        {
            roomsService = _roomsService;
            citiesService = _citiesService;
        }
        public ActionResult Index()
        {
            var rooms = roomsService.GetRooms();

            var cities = citiesService.GetCities();
            ViewBag.Cities = cities;
            return View(rooms);
        }

        public ActionResult Buy(int id)
        {
            var rooms = roomsService.GetRooms();
            
            return View(rooms.FirstOrDefault(r => r.Id == id));
        }        

       public ActionResult RoomsByCity(int id)
        {
            var rooms = roomsService.GetRoomsByCity(id);
            return PartialView("RoomsByCity",rooms);
        }


    }

}