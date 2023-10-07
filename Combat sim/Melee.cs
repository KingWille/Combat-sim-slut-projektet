using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_sim
{
    internal class Melee : BaseVariables
    {   
        public Melee() 
        {
            Attack = 7;
            Armor = 7;
            Name = "Melee";

            units.Add("1", "Melee");
            units.Add("2", "Ranged");
        }

    }
}
