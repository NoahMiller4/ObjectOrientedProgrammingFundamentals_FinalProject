using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
Display the Main Menu
Select Main Menu options with user input (using a switch statement).
Translates user inputs into method calls for the other classes that it manages. 
Collects all of the aforementioned classes, either in HashSets or as Properties.
Handle the display and switching of any other menus. The User must be able to reach the main menu at any time.
Should be instantiated once at the start of the program, and invoke a method called 
    Start which begins the game sequence. This should be the only code included in Program.cs. 

*/


namespace OOPFundamentals_FinalProject.Classes
{
    public static class Game
    {
        //private static HashSet<Monster> Monsters;
        private static HashSet<string> weaponNames = new HashSet<string>();
        private static HashSet<string> armorNames = new HashSet<string>();

        public static int GamesPlayed { get; private set; }
        public static int FightsWon { get; private set; }
        public static int FightsLost { get; private set; }

        static Game()
        {

            // adding weapon names to list
            weaponNames.Add("Sword");
            weaponNames.Add("Battle Axe");
            weaponNames.Add("Morning star");
            weaponNames.Add("Staff");
            weaponNames.Add("Halberd");
            weaponNames.Add("Bow");

            // adding armor names to list
            armorNames.Add("Bronze Armor");
            armorNames.Add("Iron Armor");
            armorNames.Add("Steel Armor");
            armorNames.Add("Silver Armor");
            armorNames.Add("Gold Armor");
            armorNames.Add("Obsidian Armor");

            // Initialize values at 0 for stats
            GamesPlayed = 0;
            FightsWon = 0;
            FightsLost = 0;
        }

        public static void MainMenu()
        {
            // set a boolean to set state of exit game or not
            bool exitGame = false;
            while (!exitGame)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("\r\n___________                   " +
                    "   .___                     \r\n\\_   _____/__  " +
                    "__ ___________  __| _/____   ____   _____  \r\n " +
                    "|    __)_\\  \\/ // __ \\_  __ \\/ __ |/  _ \\ /" +
                    "  _ \\ /     \\ \r\n |        \\\\   /\\  ___/| " +
                    " | \\/ /_/ (  <_> |  <_> )  Y Y  \\\r\n/_______ " +
                    " / \\_/  \\___  >__|  \\____ |\\____/ \\____/|__|" +
                    "_|  /\r\n        \\/           \\/           \\/ " +
                    "                  \\/ \r\n");

                Console.WriteLine("⚔️Welcome to Everdoom⚔️");
                Console.WriteLine();

                Console.WriteLine("Please enter your hero name. (No special characters allowed)");
                string heroName = Console.ReadLine();
                Hero newHero = new Hero(heroName);
                Console.WriteLine($"Your selected hero name is {newHero.HeroName}.");
                Console.WriteLine();

                Console.WriteLine($"Choose an option {newHero.HeroName}. Input one of the following numbers:");
                Console.WriteLine("1. Display Statistics");
                Console.WriteLine("2. Display Inventory");
                Console.WriteLine("3. FIGHT!!");
                Console.WriteLine("4: Exit Game");
                Console.WriteLine();
                string options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        // DisplayStatistics();
                        break;
                    case "2":
                        // DisplayInventory();
                        break;
                    case "3":
                        // StartFight();
                        break;
                    case "4":
                        exitGame = true;
                        break;
                    // must add default case to handle errors
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}
