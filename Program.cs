using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Media;

namespace TheDungeon
{
    class Program
    {
        public static Player currentPlayer = new Player();

        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
            {
                Encounters.FirstEncounter();
            }                        
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine("The Dungeon!");
            Console.WriteLine("Name:");
            p.name = Console.ReadLine();
            Console.WriteLine("Class: Mage  Archer  Warrior");
            bool flag = false;
            while (flag == false)
            {
                flag = true;
                string input = Console.ReadLine().ToLower();
                if (input == "mage")
                {
                    p.currentClass = Player.PlayerClass.Mage;
                }
                else if (input == "archer")
                {
                    p.currentClass = Player.PlayerClass.Archer;
                }
                else if (input == "warrior")
                {
                    p.currentClass = Player.PlayerClass.Warrior;
                }
                else
                {
                    System.Console.WriteLine("Please choose a existing class!");
                    flag = false;
                }
            }
            p.id = i;
            Console.Clear();
            Console.WriteLine("You awake in a cold, stone, dark room. You feel dazed and are having trouble remembering");
            Console.WriteLine("anything abiout your past.");
            if (p.name == "")
            {
                Console.WriteLine("You can't even remember your own name...");
            }
            else 
            {
                Console.WriteLine("You know your name is " + p.name);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You grope around in the darkness until you find a door handle. You feel some resistence as");
            Console.WriteLine("you turn the handle, but the rusty lock breaks with little effort. You see your captor");
            Console.WriteLine("standing with his back to you outside the door.");
            return p;            
        }
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }
        public static void Save()
        {
            BinaryFormatter binform = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binform.Serialize(file, currentPlayer);
            file.Close();
        }
        
        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();            
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binform = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binform.Deserialize(file);
                file.Close();
                players.Add(player);
            }
            
            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Print("Choose your Player:", 60);
            
                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }

                Print("Please input player name or id (id:# or playername). Additonally, 'create' will start a new save");            
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1],out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that id!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                            Console.ReadKey();   
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;                        
                    }
                    else
                    {
                         foreach (Player player in players)
                         {
                             if (player.name == data[0])
                             {
                                 return player;
                             }
                         }               
                    }
                }
                catch (IndexOutOfRangeException)
                {                    
                    Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                    Console.ReadKey();   
                }                                                    
            }            
        }
        public static void Print(string text, int speed = 40)
        {
            //SoundPlayer soundPlayer = new SoundPlayer("sounds/type.wav");
            //soundPlayer.Playlooping();
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            //soundPlayer.Stop();
            Console.WriteLine();
        }
    }
}
