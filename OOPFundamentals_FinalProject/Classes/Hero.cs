using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


/*

Name
BaseStrength (added to the EquippedWeapon Power to calculate attack damage)
BaseDefence (added to the EquippedArmour Power to calculate damage when attacked)
OriginalHealth (The amount of Health the Hero begins with)
CurrentHealth (The existing amount of Health the hero has. It cannot exceed OriginalHealth or become negative)
EquippedWeapon (An instance of Weapon used to calculate attack damage)
EquippedArmor (An instance of Armour used to calculate damage to the Hero)

And the following functions:

GetStats  (Returns or Displays the Hero’s Name, BaseStrength, BaseDefence, OriginalHealth, and CurrentHealth).
GetInventory (Returns what items the Hero is Equipped with)
EquipWeapon (Change the EquippedWeapon)
EquipArmour (Change the EquippedArmour)

*/

namespace OOPFundamentals_FinalProject.Classes
{
    public class Hero
    {
        private string _heroName;
        private int _baseStrength;
        private int _baseArmour;
        private int _originalHealth;
        private int _currentHealth;

        public int BaseStrength { get; }
        public int BaseArmour { get; }
        public int BaseHealth { get; }
        public int OriginalHealth { get; }
        public int CurrentHealth { get; set; }

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

        

        public Hero(string _heroName/*, int _baseStrength, int _baseArmour, 
            int _originalHealth, int _currentHealth*/ ) 
        {
            HeroName = _heroName;
        }
    }
}
