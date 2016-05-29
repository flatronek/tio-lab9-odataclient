using ClassLib;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OData.DAL
{
    public class GamesInitializer : DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            var games = new List<Game>
            {
                new Game() { Id = 1, AgeRate = 1, Year = 1, CreatorCompany = "company1", Title = "Game1" },
                new Game() { Id = 2, AgeRate = 2, Year = 2, CreatorCompany = "company2", Title = "Game2" }
            };
            context.Games.AddRange(games);
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store() { Id = 1, Name = "Store1", Address = "Address1" },
                new Store() { Id = 2, Name = "Store2", Address = "Address2" }
            };
            context.Stores.AddRange(stores);
            context.SaveChanges();
        }
    }
}