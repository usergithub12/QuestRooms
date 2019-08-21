using DataAccessLayer.Repositories;
using QuestRooms.DAL;
using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           GenericRepository<City> repository = new GenericRepository<City>(new RoomsContext());

            var countr = repository.GetAll();

            foreach(var c in countr)
            {
                Console.WriteLine(c.Name);
            }

        }
    }
}
