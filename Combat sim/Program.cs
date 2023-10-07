using Combat_sim;
using System.Runtime.CompilerServices;

string typeOfStat = "";
string conflicts = "";
string selectedAttackUnit = "";
string selectedDefenceUnit = "";
string selectedBonus = "";
string inputCombatTurns = "";

int conflictChoice = 0;
int numberOfCombat = 0;
int resultAttack = 0;
int resultDefence = 0;

float winPercentage = 0;
float wins = 0;
float lose = 0;

bool bonusFlag = false;

string[] bonusArray = new string[8];

BaseVariables[] units = new BaseVariables[2];

Random rnd = new Random();

//Sätter värdena till arrayen
for(int i = 0; i < bonusArray.Length; i++)
{
    bonusArray[i] = i.ToString();
} 

while(typeOfStat != "1" && typeOfStat != "2")
{
    Console.WriteLine("1.AutoStats\n2.Manual");

    typeOfStat = Console.ReadLine();

    if(typeOfStat != "1" && typeOfStat != "2")
    {
        Console.WriteLine("Please choose a valid answer");
    }
}

//Kör autorun
if (typeOfStat == "1")
{
    Autorun autoRun = new Autorun();

    while (!Int32.TryParse(conflicts, out conflictChoice))
    {
        Console.WriteLine("Number of combats per conflict: ");

        conflicts = Console.ReadLine();

        if (!Int32.TryParse(conflicts, out conflictChoice))
        {
            Console.WriteLine("Please choose a valid answer");
        }
    }

    autoRun.Run(conflictChoice);
}
else
{
    //Användaren väljer enhet som attackerar
    while (selectedAttackUnit != "1" && selectedAttackUnit != "2")
    {
        Console.WriteLine("Select Attack unit: ");
        Console.WriteLine("1: Melee\n2: Ranged\n");

        selectedAttackUnit = Console.ReadLine();

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
        else
        {
            Console.WriteLine("Please choose a valid answer");
        }
    }


    //Användaren väljer vilken bonus attackenheten ska ha
    while (!bonusFlag)
    {
        Console.WriteLine("Select bonustype for attacker");
        Console.WriteLine((units[0]).PrintBonus());

        selectedBonus = Console.ReadLine();

        for (int i = 0; i < bonusArray.Length; i++)
        {
            if (bonusArray[i] == selectedBonus)
            {
                bonusFlag = true;
            }
        }

        if (!bonusFlag)
        {
            Console.WriteLine("Please choose a valid answer");
        }
    }

    bonusFlag = false;
    units[0].SetBonus(Int32.Parse(selectedBonus));

    //Användaren väljer enhet som försvarar
    while (selectedDefenceUnit != "1" && selectedDefenceUnit != "2" && selectedDefenceUnit != "3")
    {
        Console.WriteLine("Select defence unit:");
        Console.WriteLine("1: Melee\n2: Ranged\n3: Siege");

        selectedDefenceUnit = Console.ReadLine();

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
        else
        {
            Console.WriteLine("Please choose a valid answer");
        }
    }

    //Väljer bonustyp för försvararen
    if (selectedDefenceUnit != "3")
    {
        while (!bonusFlag)
        {
            Console.WriteLine("Select bonustype for defender");
            Console.WriteLine(units[1].PrintBonus());

            selectedBonus = Console.ReadLine();

            for (int i = 0; i < bonusArray.Length; i++)
            {
                if (bonusArray[i] == selectedBonus)
                {
                    bonusFlag = true;
                }
            }

            if (!bonusFlag)
            {
                Console.WriteLine("Please select a valid answer");
            }
        }
    }

    units[1].SetBonus(Int32.Parse(selectedBonus));

    while (!Int32.TryParse(inputCombatTurns, out numberOfCombat))
    {
        Console.WriteLine("Enter number of attacks: ");
        inputCombatTurns = Console.ReadLine();
    }

    //Kör igenom combaten x antal gånger

    for (int i = 0; i < numberOfCombat; i++)
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

    Console.WriteLine($"{units[0].Name} defeated {units[1].Name} {wins} times.");
    Console.WriteLine($"Number of turns: {numberOfCombat}\nNumber of wins: {wins}\nNumber of loses: {lose}\nWin %: {(float)winPercentage}%");

    Console.WriteLine("Press any button to exit...");
    Console.ReadLine();
}


