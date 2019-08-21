using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Configuration
{
    public class DbInitializer:DropCreateDatabaseAlways<RoomsContext>
    {

        List<string> SQLs = new List<string>
        {
            "SQL/Cities.sql",
            "SQL/Countries.sql",
            "SQL/Streets.sql",
            "SQL/Addresses.sql",
            "SQL/Companies.sql",
            "SQL/Rooms.sql"
        };

        protected override void Seed(RoomsContext context)
        {
            //context.Database.ExecuteSqlCommand("Insert into databse ");
            //context.Addresses.Add()


            string query = "";

            foreach (var f in SQLs)
            {
                query = ReadSQLFromFile(f);
                context.Database.ExecuteSqlCommand(query);
            }
        }

        private string ReadSQLFromFile(string path)
        {
            string temp;
            using (StreamReader reader = new StreamReader(path))
            {
                temp = reader.ReadToEnd();
            }
            return temp;
        }
       
    }
}
