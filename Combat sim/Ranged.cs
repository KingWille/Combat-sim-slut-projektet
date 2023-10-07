using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Combat_sim
{
    internal class Ranged : BaseVariables
    {
        public Ranged()
        {
            Attack = 6;
            Armor = 5;
            Name = "Ranged";

            units.Add("1", "Melee");
            units.Add("2", "Ranged");
        }
        public string printBonus()
        {
            return "";
        }
        public void SetBonus(int selection)
        {
            switch (selection)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }
        }
    }
}
