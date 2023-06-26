using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals_FinalProject.Classes
{

    public static class Game
    {

        public static int GamesPlayed { get; set; }
        public static int FightsWon { get; set; }
        public static int FightsLost { get; set; }

        private static Hero newHero;

        private static HashSet<Monster> originalMonsters = new HashSet<Monster>
            {
                // new Monster(name, strength, defence, originalHealth, currentHealth)
                new Monster("A Lava Lizard", 50, 40, 300, 300),
                new Monster("A Gargoyle", 70, 30, 290, 290),
                new Monster("A Grotesque", 65, 35, 310, 310),
                new Monster("Big Boy Cerberus", 80, 40, 350, 350),
                new Monster("An Imp", 50, 40, 300, 300),
                new Monster("Hades", 60, 20, 380, 380),
                new Monster("A Daedra", 50, 30, 375, 375),
                new Monster("A Chimera", 50, 30, 300, 300),
                new Monster("A Harpy", 40, 40, 280, 280)
            };

        private static HashSet<Monster> activeMonsters = new HashSet<Monster>();


        public static HashSet<Weapon> allWeapons = new HashSet<Weapon>
        {
            new Weapon(1, "Bronze Sword", 40),
            new Weapon(2, "Battle Axe", 40),
            new Weapon(3, "Morning Star", 40),
            new Weapon(4, "Staff", 40),
            new Weapon(5, "Halberd", 40),
            new Weapon(6, "Bow", 40)
        };
        
        public static HashSet<Armor> allArmors = new HashSet<Armor>
        {
            new Armor(1, "Bronze Armor", 20),
            new Armor(2, "Iron Armor", 20),
            new Armor(3, "Steel Armor", 20),
            new Armor(4, "Silver Armor", 20),
            new Armor(5, "Gold Armor", 20),
            new Armor(6, "Obsidian Armor", 20)
        };

        // respawn, remove and generate random all pertaining to adding, removing
        // and randomizing monsters in the new hashset. 
        public static void RespawnMonsters()
        {
            // to reinstantiate monsters after losing, we must clear our new hashset of
            // active monsters and add the monsters back in to the hash set, along with all
            // of their values.

            // !! must set current health of monster to original health as it may
            // be at 0 after losing the fight.
            activeMonsters.Clear();
            foreach (Monster monster in originalMonsters)
            {
                activeMonsters.Add(new Monster(monster.Name, monster.Strength, 
                    monster.Defence, monster.OriginalHealth, monster.OriginalHealth));
            }
        }

        public static void RemoveMonster(Monster defeatedMonster)
        {
            // Remove the monster from list of active monsters after defeated
            activeMonsters.Remove(defeatedMonster);
        }

        public static Monster GenerateRandomMonster()
        {
            // generating random index to select monster from HashSet
            // .next and elementAt example from https://stackoverflow.com/questions/10654292/get-random-element-from-hashset
            Random random = new Random();
            int randomMonster = random.Next(activeMonsters.Count);
            Monster selectedMonster = activeMonsters.ElementAt(randomMonster);

            // create a new instance of selected monster with original health and defence
            Monster newRandomMonster = new Monster(selectedMonster.Name, selectedMonster.Strength,
                selectedMonster.Defence, selectedMonster.OriginalHealth, selectedMonster.OriginalHealth);

            // return the newly randomly created monster
            return newRandomMonster;
        }

        public static void Start()
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
            try
            {
                if (heroName != null || heroName.Length >=1)
                {
                    newHero = new Hero(heroName);
                    MainMenu();
                }
                else
                {
                    throw new Exception("Error");
                }
            } catch (Exception e)
            {
                e.ToString();
                
            }
            Console.WriteLine($"Your selected hero name is {newHero.HeroName}.");
            Console.WriteLine();
        }

        public static void MainMenu()
        {
            // set a boolean so while runGame is true, the game will continue.
            // removed runGame from switch case 4 as it was still displaying the main menu
            // used environment.exit instead.
            bool runGame = false;
            while (!runGame)
            {
                try
                {
                    Hero currentHero = newHero;

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
                            currentHero.GetStats();
                            break;
                        case "2":
                            currentHero.GetInventory();
                            break;
                        case "3":
                            Fight.FightText(currentHero, GenerateRandomMonster());
                            Fight.StartFight(currentHero, GenerateRandomMonster());
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        // run error if there is no case match
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                } catch (Exception e) 
                { Console.WriteLine(e.ToString()); }
            }
        }
        static Game()
        {
            // Initialize values at 0 for stats
            GamesPlayed = 0;
            FightsWon = 0;
            FightsLost = 0;


            // Populate the active monster set with the original monsters
            RespawnMonsters();
        }
    }
}
