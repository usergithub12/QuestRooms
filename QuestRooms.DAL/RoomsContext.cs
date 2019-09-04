namespace QuestRooms.DAL
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using QuestRooms.DAL.Configuration;
    using QuestRooms.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RoomsContext : IdentityDbContext<AppUser>
    {
        public RoomsContext()
            : base("name=RoomsContext")
        {
           // Database.SetInitializer(new DbInitializer());
        }
      public  DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Country>Countries { get; set; }
        public static RoomsContext Create()
        {
            return new RoomsContext();
        }
    }

   

   
}