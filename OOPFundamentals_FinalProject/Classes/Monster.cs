using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
Name 
Strength (Determines how much Health is lost on each Attack)
Defence (Subtracted from the Hero’s attack to calculate how much Health is lost)
OriginalHealth (The initial, and maximum, amount of health the Monster has)
CurrentHealth (The current amount of Health the monster has. Cannot exceed OriginalHealth or become negative).
 
*/



namespace OOPFundamentals_FinalProject.Classes
{
    public class Monster
    {
        private int _strength;
        private int _defence;
        private int _originalHealth;
        private int _currentHealth;



        public int Strength { get { return _strength; } }
        public int CurrentHealth { get { return _currentHealth; } }

    }
}
