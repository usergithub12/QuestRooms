using AutoMapper;
using DataAccessLayer.Repositories;
using QuestRoom.BLL.DTOModels;
using QuestRoom.BLL.Services.Abstraction;
using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.BLL.Services.Implementation
{
   public class RoomsService:IRoomsService
    {

        private readonly IGenericRepository<Room> roomRepos;

        private readonly IMapper mapper;

        public RoomsService(IGenericRepository<Room> _roomRepos, IMapper _mapper)
        {
            roomRepos = _roomRepos;
            mapper = _mapper;
        }

        public ICollection<RoomDTO> GetRooms()
        {
            var rooms = roomRepos.GetAll().ToList();

            return mapper.Map<List<Room>, ICollection<RoomDTO>>(rooms);


        }
    }
}
