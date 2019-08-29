﻿
using QuestRoom.BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.BLL.Services.Abstraction
{
  public  interface IRoomsService
    {
        ICollection<RoomDTO> GetRooms();


        ICollection<RoomDTO> GetRoomsByCity(int id);
    }
}
