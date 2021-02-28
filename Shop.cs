using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDungeon
{
    public class Shop
    {
        public static void LoadShop(Player p)
        {
            Runshop(p);
        }

        public static void Runshop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armorP = 100 * p.armorValue;
                weaponP = 100 * (p.weaponValue + 1);
                difP = 300 +100 * p.mods;
                Console.Clear();
                Console.WriteLine("        Shop        ");
                Console.WriteLine("=======================");
                Console.WriteLine("(W)eapon :         $" + weaponP);
                Console.WriteLine("(A)rmor :          $" + armorP);
                Console.WriteLine("(P)otion :        $" + potionP);
                Console.WriteLine("(D)ifficulty Mod : $" + difP);
                Console.WriteLine("=======================");
                //Wait for input
                string input = Console.ReadLine().ToLower();
                if (input == "w" || input == "weapon")
                {
                    
                }
                else if (input == "a" || input == "armor")
                {
                    
                }
                else if (input == "p" || input == "potion")
                {

                }
                else if (input == "d" || input == "difficulty mod")
                {

                }
            }            
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
            {
                
            }
            else
            {
                Console.WriteLine("Ya don't have enough gold!");
                Console.ReadKey();   
            }
        }
    }
}