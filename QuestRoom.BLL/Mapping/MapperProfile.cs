using AutoMapper;
using QuestRoom.BLL.DTOModels;
using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.BLL.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Street, StreetDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<Image, ImageDTO>();
            CreateMap<Room, RoomDTO>();
        }

        
        
    }
}
