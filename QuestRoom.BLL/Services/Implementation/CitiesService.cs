﻿using AutoMapper;
using DataAccessLayer.Repositories;
using QuestRoom.BLL.DTOModels;
using QuestRoom.BLL.Services.Abstraction;
using QuestRooms.DAL;
using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.BLL.Services.Implementation
{
    public class CitiesService : ICitiesService
    {
        private readonly IGenericRepository<City> cityRepos;

        private readonly IMapper mapper;

        public CitiesService(IGenericRepository<City> _cityRepos,IMapper _mapper)
        {
            cityRepos = _cityRepos;
            mapper = _mapper;
        }

        public ICollection<CityDTO> GetCities()
        {
            var cities = cityRepos.GetAll().ToList();
                        
            return mapper.Map<List<City>,ICollection<CityDTO>>(cities);


        }
    }
}
