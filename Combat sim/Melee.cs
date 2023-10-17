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
        }

        public override string PrintBonus()
        {
            return "1.Smithing: +1 DMG, -1 armor\n" +
               "2.Shield: +1 armor, -1 DMG\n" +
               "3.Dualwield: +1 DMG, -50% MS\n" +
               "4.Battle Axe: +1 range. - 50% MS,\n" +
               "5.Heavy armor +1 armor, - 50& MS\n" +
               "6.Halberd: +1 range, - 1 DMG\n" +
               "7.Horserider: +100% MS, - 1 armor\n" +
               "8.Smallarms: +1 DMG, -1 armor";
        }
        public override void SetBonus(int selection)
        {
            switch (selection)
            {
                case 1:
                    Attack += 1;
                    Armor -= 1;
                    Name += ": Smithing";
                    break;
                case 2:
                    Attack -= 1;
                    Armor += 1;
                    Name += ": Shield";
                    break;
                case 3:
                    Attack += 1;
                    Name += ": Dualwield";
                    break;
                case 4:
                    Name += ": Battle Axe";
                    break;
                case 5:
                    Armor += 1;
                    Name += ": Heavy Armor";
                    break;
                case 6:
                    Attack -= 1;
                    Name += ": Halberd";
                    break;
                case 7:
                    Armor -= 1;
                    Name += ": Horserider";
                    break;
                case 8:
                    Attack += 1;
                    Armor -= 1;
                    Name += ": Smallarms";
                    break;
            }

        }
    }
}
