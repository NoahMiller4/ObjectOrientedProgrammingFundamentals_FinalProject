using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals_FinalProject.Classes
{
    public class Gear
    {
        public int Index { get; }
        public string Name { get; }
        public int Power { get; }

        public Gear(int index, string name, int power)
        {
            Index = index;
            Name = name;
            Power = power;
        }
    }
}
