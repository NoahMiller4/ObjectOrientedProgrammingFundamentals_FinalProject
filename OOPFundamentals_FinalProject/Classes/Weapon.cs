using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
Name (A predefined name for the instance – may be hard-coded).
Power (A number, added to the Hero’s attack damage for a Weapon, 
or subtracted from the Monster’s attack damage for Armour) 

*/

namespace OOPFundamentals_FinalProject.Classes
{
    public class Weapon : Gear
    {
        public Weapon(string name, int power) : base(name, power)
        {
        }
    }
}
