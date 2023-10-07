using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_sim
{
    internal class BaseVariables
    {
        public Dictionary<string, string> units = new Dictionary<string, string>();
        public int Armor;
        public int Attack;
        public string Name;

        public string printBonus(string Tag)
        {
            if(Tag == "Melee")
            {
                return "";
            }
            else
            {
                return "";
            }

            
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
