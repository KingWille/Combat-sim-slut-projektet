using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_sim
{
    internal abstract class BaseVariables
    {
        public int Armor;
        public int Attack;
        public string Name;

        public abstract string PrintBonus();

        public abstract void SetBonus(int selection);
    }
}
