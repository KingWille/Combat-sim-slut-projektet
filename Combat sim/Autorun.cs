using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Combat_sim
{
    internal class Autorun : Program
    {
        BaseVariables[] units = new BaseVariables[2];

        Random rnd = new Random();

        StreamWriter writer;

        private int numberOfRangeClasses = 8;
        private int numberOfMeleeClasses = 8;

        string selectedAttackUnit = "";
        string selectedDefenceUnit = "";
        string selectedBonus = "";

        int counter = 0;
        int resultAttack = 0;
        int resultDefence = 0;

        float winPercentage = 0;
        float wins = 0;
        float lose = 0;

        private int totalRuns;
        public void Run(int numberOfCombat)
        {

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Stats.txt"))
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Stats.txt", String.Empty);
            }

            for (int v = 1; v < 3; v++)
            {
                for(int u = 1;  u < 3; u++) 
                {
                    for(int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            selectedAttackUnit = v.ToString();

                            //Väljer attack unit
                            if (selectedAttackUnit == "1")
                            {
                                Melee attacker = new Melee();
                                units[0] = attacker;
                            }
                            else if (selectedAttackUnit == "2")
                            {
                                Ranged attacker = new Ranged();
                                units[0] = attacker;
                            }

                            //Väljer bonus
                            units[0].SetBonus(i);

                            if (counter < 32)
                            {
                                selectedDefenceUnit = "1";
                            }
                            else
                            {
                                selectedDefenceUnit = "2";
                            }

                            selectedDefenceUnit = u.ToString();

                            //Väljer Defence unit
                            if (selectedDefenceUnit == "1")
                            {
                                Melee defender = new Melee();
                                units[1] = defender;
                            }
                            else if (selectedDefenceUnit == "2")
                            {
                                Ranged defender = new Ranged();
                                units[1] = defender;
                            }
                            else if (selectedDefenceUnit == "3")
                            {
                                Siege defender = new Siege();
                                units[1] = defender;
                            }

                            //Väljer bonus om det inte är siege
                            if (selectedDefenceUnit != "3")
                            {
                                units[1].SetBonus(j);
                            }

                            //Kör igenom combaten
                            for (int q = 0; q < numberOfCombat; q++)
                            {
                                resultAttack = units[0].Attack + rnd.Next(1, 9);
                                resultDefence = units[1].Armor + rnd.Next(1, 9);

                                if (resultAttack - resultDefence <= 0)
                                {
                                    lose++;
                                }
                                else
                                {
                                    wins++;
                                }
                            }

                            winPercentage = wins / numberOfCombat * 100;

                            wins = 0;
                            lose = 0;


                            using (writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Stats.txt", true)) // true for appending the file and false to overwrite the file
                            { 
                                writer.WriteLine($"{units[0].Name} vs {units[1].Name}. Turns: {numberOfCombat}. Winrate: {winPercentage}%");
                                if(j == 8)
                                {
                                    writer.WriteLine("-----------------------------------------------------------------------------------");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
