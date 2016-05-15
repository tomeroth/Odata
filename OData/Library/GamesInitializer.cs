using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class GamesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            var games = new List<Game>
            {
               new Game() {Title="Crisis", AgeRate=16,CreateCompany="Crytek",Year=2007},
               new Game() {Title="Arcanum", AgeRate=12,CreateCompany="Sierra",Year=2001},
               new Game() {Title="Gothic II", AgeRate=12,CreateCompany="Pyranha Bytes",Year=2002},
               new Game() {Title="Witcher 3:Wild Hunt", AgeRate=18,CreateCompany="CDProject Red",Year=2015},
               new Game() {Title="Arkham City", AgeRate=18,CreateCompany="Rocksteady Studios",Year=2011},
               new Game() {Title="Warcraft 3", AgeRate=12,CreateCompany="Blizzard",Year=2002},
            };
            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store() {Name="Empik",Address="Kalwaryjska"},
                new Store() {Name = "Media Markt",Address="Pawia 3"},
                new Store() {Name = "Saturn",Address="Bonarka"},
                new Store() {Name = "X-Kom",Address="Galeria Kazimierz"},
                new Store() {Name = "Bino",Address="Twardowskiego"},
            };
            stores.ForEach(s => context.Stores.Add(s));
            context.SaveChanges();
        }
    }
}
