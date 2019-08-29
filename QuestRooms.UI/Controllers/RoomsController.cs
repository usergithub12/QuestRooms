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

        // GET: Rooms

        public RoomsController(IRoomsService _roomsService)
        {
            roomsService = _roomsService;
        }
        public ActionResult Index()
        {
            var rooms = roomsService.GetRooms();
            return View(rooms);
        }

        public ActionResult Buy(int id)
        {
            var rooms = roomsService.GetRooms();
            
            return View(rooms.FirstOrDefault(r => r.Id == id));
        }        

    }

}