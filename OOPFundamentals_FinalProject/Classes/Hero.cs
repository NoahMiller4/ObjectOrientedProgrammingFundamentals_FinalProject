using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOPFundamentals_FinalProject.Classes
{
    public class Hero
    {
        private string _heroName;
        public int BaseStrength { get; private set; }
        public int BaseArmour { get; private set; }
        public int OriginalHealth { get; private set; }
        public int CurrentHealth { get; set; }

        public Weapon EquippedWeapon { get; set; }

        public Armor EquippedArmor { get; set; }
        public string HeroName
        {
            get { return _heroName; }
            private set
            {
                try
                {

                    if (value.Length >= 1 && value.Length <= 20 &&
                        Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
                    {
                        _heroName = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "Please enter a valid username. " +
                            "No special characters are allowed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void ShowWeapons()
        {
            Console.WriteLine("WEAPONS:");
            foreach (Weapon weapon in Game.allWeapons)
            {
                Console.WriteLine($"{weapon.Index}: {weapon.Name}, Damage: {weapon.Power}");
            }
            Console.WriteLine();
        }

        public void ShowArmors()
        {
            Console.WriteLine("ARMORS");
            foreach (Armor armor in Game.allArmors)
            {
                Console.WriteLine($"{armor.Index}: {armor.Name}, Defense:{armor.Power}");
            }
            Console.WriteLine();
        }
        public void EquipWeapon()
        {
            // instead of bloated switch case, access allWeapons with if block using
            // weaponIndex - 1 as allWeapons index will be one number behind the user input

            Console.WriteLine("Please select a number from the list of weapons:");
            ShowWeapons();
            string weaponInput = Console.ReadLine();
            int weaponIndex;
            try
            {
                // parse input to int
                weaponIndex = int.Parse(weaponInput);

                if (weaponIndex >= 1 && weaponIndex <= Game.allWeapons.Count)
                {
                    Weapon selectedWeapon = Game.allWeapons.ElementAt(weaponIndex - 1);
                    EquippedWeapon = selectedWeapon;
                    Console.WriteLine($"You have equipped {selectedWeapon.Name}.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid weapon selection. Please try again.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        public void EquipArmor()
        {
            Console.WriteLine("Please select a number from the list of armors:");
            ShowArmors();
            string armorInput = Console.ReadLine();
            int armorIndex;
            try
            {
                // parse input to int
                armorIndex = int.Parse(armorInput);

                if (armorIndex >= 1 && armorIndex <= Game.allWeapons.Count)
                {
                    Armor selectedArmor = Game.allArmors.ElementAt(armorIndex - 1);
                    EquippedArmor = selectedArmor;
                    Console.WriteLine($"You have equipped {selectedArmor.Name}.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid weapon selection. Please try again.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        public void GetStats()
        {
            Console.WriteLine("Your current stats are:");
            Console.WriteLine();
            Console.WriteLine($"Name: {HeroName}");
            Console.WriteLine($"Games played: {Game.GamesPlayed}");
            Console.WriteLine($"Fights won: {Game.FightsWon}");
            Console.WriteLine($"Fights lost: {Game.FightsLost}");
            Console.WriteLine($"Current Health: {CurrentHealth}");
            Console.WriteLine();
        }

        public void GetInventory()
        {
            Console.WriteLine("Please Choose a weapon");
            Console.WriteLine($"Hello {HeroName}, Your current inventory is:");
            Console.WriteLine($"Weapon: {EquippedWeapon.Name}, {EquippedWeapon.Power}");
            Console.WriteLine($"Armor: {EquippedArmor.Name}, {EquippedArmor.Power}");
            Console.WriteLine();
            Console.WriteLine("Would you like to change weapons or Armor? (enter y/n)");
            string change = Console.ReadLine();
            if(change == "y")
            {
                EquipWeapon();
                EquipArmor();
            } else if (change == "n")
            {
                Console.WriteLine();
                Game.MainMenu();
            } else
            {
                Console.WriteLine($"You must select a yes or no option. " +
                    $"Returning to Menu");
            }
            Console.WriteLine();
        }

        public Hero(string _heroName ) 
        {
            HeroName = _heroName;
            BaseStrength = 20;
            BaseArmour = 20;
            OriginalHealth = 300;
            CurrentHealth = 300;
            EquippedWeapon = new Weapon(0, "Hands", 1);
            EquippedArmor = new Armor(0, "Loin Cloth", 1);
        }
    }
}