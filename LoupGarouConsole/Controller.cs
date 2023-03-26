using LoupGarouConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarouConsole
{
    public static class Controller
    {
        public static void Start()
        {
            //0: villagopis
            //1: loups
            //2: Salvador
            //3: Sa7era
            Game game;
            List<Player> players = new List<Player>();
            var gameRunning = true;
            while (gameRunning)
            {
                //Initializer
                game = new Game();
                Console.WriteLine("Game ID: " + game.GameId);
                Console.WriteLine("Adding Players: ");
                game.AddPlayer(new Player("Khabir"));
                game.AddPlayer(new Player("Njoura"));
                game.AddPlayer(new Player("Mehdi"));
                game.AddPlayer(new Player("Bourara"));
                game.AddPlayer(new Player("Sirine"));
                Console.WriteLine();
                Console.WriteLine("Boarding complete ");

                Console.WriteLine("The game will have 2 villagois, 2 loups, and 1 salvador ");
                game.CreateRoles();
                game.AssignRolesToPlayers();

                Console.WriteLine("The game will start now, everyone should sleep");
                Console.WriteLine("Press any key to start the game");

                Console.Read();
                Console.Clear();


                //Night starts

                game.SalvaorTurn();
                Console.Clear();
                game.loupsTurn();

                //Day starts ,  updates 

                game.dayUpdates();

                gameRunning = false;
            }

        }

    }
}
