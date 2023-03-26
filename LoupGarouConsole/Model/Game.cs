namespace LoupGarouConsole.Model
{
    public class Game
    {
        private readonly Random _rand;
        public string GameId { get; }
        public List<Player> Players { get; }
        public List<int> Roles { get; set; }

        public Game()
        {
            GameId = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            Players = new List<Player>();
            Roles = new List<int>();
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
            Player? salvador = Players.Find(P => P.Role == 2);
            Console.WriteLine($"{salvador.Name} wake up! You are the Salvador. Who would you like to protect?");
            for (int i = 0; i < Players.Count; i++)
            {
                Console.WriteLine(i + 1 + "- " + Players[i].Name);
            }
            string? input = "";
            do
            {
                input = Console.ReadLine();

            } while (input.Length == 0);
            int number = int.Parse(input);
            Players[number - 1].IsProtected = true;
            Console.WriteLine(Players[number - 1].Name + " is now protected from the wolves!");
            Console.WriteLine("Salvador, arja3 or9od!");


        }

        public void loupsTurn()
        {
            Player? firstLoup = Players.Find(P => P.Role == 1);
            Player? secondLoup = Players.Find(x => x.Role == 1 && x != firstLoup);
            Console.WriteLine($"{firstLoup.Name} and {secondLoup.Name} Wake up ! Both of You are Wolves ! Time To Kill Someone , decide ! ");
            for (int i = 0; i < Players.Count; i++)
            {
                Console.WriteLine(i + 1 + "- " + Players[i].Name);
            }
            Console.WriteLine(0 + "- " + "Kill No One");
            string? input = "";
            do
            {
                input = Console.ReadLine();

            } while (input.Length == 0);
            int number = int.Parse(input);
            if (number != 0)
            {
                Players[number - 1].IsAlive = false;
                Console.WriteLine("You Chose To Kill :" + Players[number - 1].Name);
                Console.WriteLine("A bloody night for the wolves , arj3o or9do");
            }
            else
            {
                Console.WriteLine("Decided to play it safe wolves , probably a dumb move but your choice ! , arj3o or9do ");
            }


        }

        public void dayUpdates()
        {
            bool someoneDead = false;
            Console.WriteLine("Everyone's Waking up , sbeh lnour ");
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].IsAlive == false && Players[i].IsProtected == true)
                {
                    Console.WriteLine($"{Players[i].Name} was killed last night , but luckily salvador saved him so he is still in the game ! good job salvador ");
                    Players[i].IsAlive = true;
                    someoneDead = true;

                }
                else if (Players[i].IsAlive == false && Players[i].IsProtected == false)
                {
                    Console.WriteLine($"{Players[i].Name} was unfortunately killed last night");
                    Players.RemoveAt(i);
                    someoneDead = true;
                }
            }
            if (someoneDead == false)
            {
                Console.WriteLine("a very sunny day today , no one was killed last night , wolves are probably idling or planning an attack next night ! ");
            }
            Console.WriteLine("Speak Togther Decide on who you suspect being a wolf , Vote/Kill him !");

        }


    }
}
