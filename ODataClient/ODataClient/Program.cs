using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:54038";
            var container = new ODataClientas.Default.Container(new Uri(serviceUri));

            Console.WriteLine("Games list:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0} : {1}", game.Title, game.CreatorCompany);
            }

            Console.WriteLine("Adding a game:");
            container.AddToGames(new ODataClientas.ClassLib.Game() { Id = 3, AgeRate = 3, Year = 3, CreatorCompany = "company3", Title = "Game3" });
            var serviceResponse = container.SaveChanges();

            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
            Console.WriteLine();

            Console.WriteLine("Games list:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0} : {1}", game.Title, game.CreatorCompany);
            }

            Console.WriteLine("Available CardShirts: ");
            var res = container.GetAvailableCardShirts();
            foreach (var shirt in res.GetAllPages())
            {
                Console.WriteLine("{0} : {1}", shirt.Id, shirt.Name);
            }

            Console.WriteLine("Stores list:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0} : {1}", store.Name, store.Address);
            }

            Console.WriteLine("Removing store with id = 1");
            container.Stores.Where(x => x.Id == 1).ToList().ForEach(x => container.DeleteObject(x));
            serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }

            Console.WriteLine("Stores list:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0} : {1}", store.Name, store.Address);
            }
        }
    }
}
