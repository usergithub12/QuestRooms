﻿using AutoMapper;
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

        public ICollection<RoomDTO> GetRoomsByCity(int id)
        {
            var rooms = roomRepos.GetAll().ToList();
            var room_list = rooms.Where(r => r.Address.City.Id == id).ToList();
            return mapper.Map<List<Room>, ICollection<RoomDTO>>(room_list);
        }

        public ICollection<RoomDTO> GetRoomsByDifficulty(int lvl)
        {
            var rooms = roomRepos.GetAll().ToList();
            var room_list = rooms.Where(r => r.LvlDifficulty == lvl).ToList();
            return mapper.Map<List<Room>, ICollection<RoomDTO>>(room_list);
        }

        public ICollection<RoomDTO> GetRoomsByFear(int lvl)
        {
            var rooms = roomRepos.GetAll().ToList();
            var room_list = rooms.Where(r => r.LvlFear == lvl).ToList();
            return mapper.Map<List<Room>, ICollection<RoomDTO>>(room_list);
        }

      public  List<int> GetCountRoomsByCity()
        {
            List<int> counts = new List<int>();
            var rooms = roomRepos.GetAll().ToList();

            foreach (var item in rooms)
            {
                var room = rooms.GroupBy(r => r.Address.City.Id).Count();
                counts.Add(room);
            }
          
            return counts;
        }
    }
}
