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
            return "1.Smithing: +2 DMG, -1 armor\n" +
               "2.Shield: +2 armor, -1 DMG\n" +
               "3.Dualwield: +2 DMG, -50% MS\n" +
               "4.Battle Axe: +1 range. - 50% MS,\n" +
               "5.Heavy armor +2 armor, - 50& MS\n" +
               "6.Halberd: +1 range, - 1 DMG\n" +
               "7.Horserider: +100% MS, - 2 armor\n" +
               "8.Smallarms: +2 DMG, -1 armor";
        }
        public override void SetBonus(int selection)
        {
            switch (selection)
            {
                case 1:
                    Attack += 2;
                    Armor -= 1;
                    Name += ": Smithing";
                    break;
                case 2:
                    Attack -= 1;
                    Armor += 2;
                    Name += ": Shield";
                    break;
                case 3:
                    Attack += 2;
                    Name += ": Dualwield";
                    break;
                case 4:
                    Name += ": Battle Axe";
                    break;
                case 5:
                    Armor += 2;
                    Name += ": Heavy Armor";
                    break;
                case 6:
                    Attack -= 1;
                    Name += ": Halberd";
                    break;
                case 7:
                    Armor -= 2;
                    Name += ": Horserider";
                    break;
                case 8:
                    Attack += 2;
                    Armor -= 1;
                    Name += ": Smallarms";
                    break;
            }

        }
    }
}
