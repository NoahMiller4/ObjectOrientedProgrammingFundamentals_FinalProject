using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals_FinalProject.Classes
{
    public class Weapon : Gear
    {
        public Weapon(int index, string name, int power) : base(index, name, power)
        {

        }
    }
}
