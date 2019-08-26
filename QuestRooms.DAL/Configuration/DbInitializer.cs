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
            "/bin/SQL/Cities.sql",
            "/bin/SQL/Countries.sql",
            "/bin/SQL/Streets.sql",
            "/bin/SQL/Addresses.sql",
            "/bin/SQL/Companies.sql",
            "/bin/SQL/Rooms.sql"
        };

        protected override void Seed(RoomsContext context)
        {
            //context.Database.ExecuteSqlCommand("Insert into databse ");
            //context.Addresses.Add()

            var path = System.AppDomain.CurrentDomain.BaseDirectory;

            string query = "";

            foreach (var f in SQLs)
            {
                query = ReadSQLFromFile(path+f);
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
