using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarouConsole.Model
{
    public class Game
    {
        private readonly Random _rand;
        public string GameId { get; }
        public List<Player> Players { get; }
        public List<int> Roles{ get; set; }

        public Game()
        {
            GameId = Guid.NewGuid().ToString().Substring(0,4).ToUpper();
            Players= new List<Player>();
            Roles= new List<int>();
            _rand = new Random(); 
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            Console.WriteLine(player.Name + " joined the game");   
        }

        public void CreateRoles()
        {
            List<int> tmpRoles = new List<int>();
            //0: villagopis
            //1: loups
            //2: Salvador
            tmpRoles.Add(0);
            tmpRoles.Add(0);
            tmpRoles.Add(1);
            tmpRoles.Add(1);
            tmpRoles.Add(2);
            Roles = GenerateRandomOrderBy(tmpRoles);
        }
        public List<int> GenerateRandomOrderBy(List<int> listToShuffle)
        {
            var shuffledList = listToShuffle.OrderBy(_ => _rand.Next()).ToList();
            return shuffledList;
        }
        public void AssignRolesToPlayers()
        {
            for (int i = 0; i < Players.Count; i++) 
            {
                Players[i].AssignRole(Roles[i]);
            
            }
        }
        public void SalvaorTurn()
        {
            Player salvador = Players.Find(P => P.Role == 2);
            for (int i = 0; i < Players.Count; i++)
            {
                Console.WriteLine(i+1 + "- "+ Players[i].Name);
            }

            Console.WriteLine($"{salvador.Name} wake up! You are the Salvador. Who would you like to protect?");
        }

        public void SalvaorProtection(int i)
        {
            Players[i].IsProtected = true;
            Console.WriteLine(Players[i].Name + " is now protected from the wolves!");
            Console.WriteLine("Salvador, arja3 or9od!");

        }
    }
}
