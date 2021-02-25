using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDungeon
{
    public class Encounters
    {
        static Random rand = new Random();
        //Encounters Generic

        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door and grab a rusty metal sword, while charging toward your captor");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat(false, "Human Rouge", 1, 4);
        }        

        public static void BasicFightEncounter()
        {
            Console.WriteLine("You turn the corner and there you see a hulking beast...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        //Encounter Tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0, 1))
            {
                case 0:
                {
                    BasicFightEncounter();
                    break;
                }
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = rand.Next(1, 5);
                h = rand.Next(1, 8);
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("===================");
                Console.WriteLine("|(A)ttack (D)efend|");
                Console.WriteLine("| (R)un    (H)eal |");
                Console.WriteLine("===================");
                Console.WriteLine("Potions: "+ Program.currentPlayer.potion + "  Health : "+ Program.currentPlayer.health);
                string input = Console.ReadLine();
                
                if (input.ToLower() == "a" ||input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("With haste you surge forth, your sword dancing in flying in your hands! The "+ n +" strikes you as you pass.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(1, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" ||input.ToLower() == "Defend")
                {
                    //Defend
                    Console.WriteLine("As the  "+ n +" prepares to strike, you ready your sword ina defensive stance.");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(1, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" ||input.ToLower() == "Run")
                {
                    //Run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint aways from the "+ n +", its strike catches you in the back, sending you sprawling ");
                        int damage = p - Program.currentPlayer.armorValue;
                        if(damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " + damage + " health and are unable escape.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the " + n + " and you successfully escape!");
                        Console.ReadKey();
                        //go to store
                    }
                }                
                else if (input.ToLower() == "h" ||input.ToLower() == "Heal")
                {
                    //Heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("As you desperatly grasp for a potion in your bag, all that fee are empty glass flasks...");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("The " + n + "strikes with a mighty blow and you lose " + damage + " health!");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag and pull out a glowing, purple flask. You take a long drink.");
                        int potionV = 5;
                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("As you were occupied, the " + n + "advanced and struck.");
                        int damage = (p/2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                            Console.WriteLine("You lose " + damage + "health.");
                        }
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
                
                
            }
            int c = rand.Next(10, 50);
            Console.WriteLine("As you stand victorious over the " + ", its body dissovles into " + c + " gold coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }

        // Method that generates name of enemy
        public static string GetName()
        {
            switch(rand.Next(0, 4))
            {
                case 0:
                {
                    return "Skeleton";
                }
                case 1:
                {
                    return "Zombie";
                }
                case 2:
                {
                    return "Human Cultist";
                }
                case 3:
                {
                    return "Grave Robber";
                }
            }
            return "Human Rouge";
        }
    }
}