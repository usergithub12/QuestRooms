using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.BLL.DTOModels
{
  public  class AddressDTO
    {
        public int Id { get; set; }
        public  CityDTO City { get; set; }
        public  StreetDTO Street { get; set; }
        public  CountryDTO Country { get; set; }
        public string HouseNumber { get; set; }
    }
}
