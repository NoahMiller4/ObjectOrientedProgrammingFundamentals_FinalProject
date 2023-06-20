using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals_FinalProject.Classes
{
    public class Gear
    {
        public string Name { get; }
        public int Power { get; }

        public Gear(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
