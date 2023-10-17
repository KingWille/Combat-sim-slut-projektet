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
        }
        public override string PrintBonus()
        {
            return "1.Crossbow: +1 DMG, -50% MS\n" +
                "2.Longbow: +1 range, -1 armor\n" +
                "3.Spear: +1 DMG, -1 range\n" +
                "4.Throwing knives: +100% MS, -1 DMG, -1 armor\n" +
                "5.Recurvebow +1 DMG, -1 armor\n" +
                "6.Horserider: +1 range, - 1 DMG\n" +
                "7.Shielded: +1 armor, - 1 DMG\n" +
                "8.Reflexbow: +1 armor, +1 range, -50% MS";
        }
        public override void SetBonus(int selection)
        {
            switch (selection)
            {
                case 1:
                    Attack += 1;
                    Name += ": Crossbow";
                    break;
                case 2:
                    Armor -= 1;
                    Name += ": Longbow";
                    break;
                case 3:
                    Attack += 1;
                    Name += ": Spear";
                    break;
                case 4:
                    Attack -= 1;
                    Armor -= 1;
                    Name += ": Throwing knives";
                    break;
                case 5:
                    Attack += 1;
                    Armor -= 1;
                    Name += ": Recurvebow";
                    break;
                case 6:
                    Attack -= 1;
                    Name += ": Horserider";
                    break;
                case 7:
                    Attack -= 1;
                    Armor += 1;
                    Name += ": Shielded";
                    break;
                case 8:
                    Armor += 1;
                    Name += ": Reflexbow";
                    break;
            }
        }
    }
}
