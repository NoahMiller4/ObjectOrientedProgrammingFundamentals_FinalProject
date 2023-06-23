using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals_FinalProject.Classes
{
    public class Monster
    {
        private string _name;
        private int _strength;
        private int _defence;
        private int _originalHealth;
        private int _currentHealth;


        public string Name { get { return _name; } }
        public int Strength { get { return _strength; } }
        public int CurrentHealth { get; set; }
        
        public int OriginalHealth { get; set; }  
        public int Defence { get { return _defence; } }

        public void ResetHealth()
        {
            _currentHealth = _originalHealth;
        }
        public Monster(string name, int strength, int defence, int originalHealth, int currentHealth)
        {
            _name = name;
            _strength = strength;
            _defence = defence;
            OriginalHealth = originalHealth;
            CurrentHealth = currentHealth;
        }
    }
}
