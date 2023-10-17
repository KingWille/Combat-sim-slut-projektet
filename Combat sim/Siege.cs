using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_sim
{
    internal class Siege: BaseVariables
    {
        public Siege() 
        {
            Armor = 8;
            Name = "Siege";
        }

        public override string PrintBonus()
        {
            return "";
        }
        public override void SetBonus(int selection)
        {
        }
    }
}
