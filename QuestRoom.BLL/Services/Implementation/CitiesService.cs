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
        public CitiesService(IGenericRepository<City> _cityRepos)
        {
            cityRepos = _cityRepos;
        }

        public ICollection<CityDTO> GetCities()
        {
            var cities = cityRepos.GetAll();

            List<CityDTO> res = new List<CityDTO>();

            foreach (var c in cities)
            {
                res.Add(new CityDTO { Id = c.Id, Name = c.Name });
            }
            return res;


        }
    }
}
