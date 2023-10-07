using Combat_sim;
using System.Runtime.CompilerServices;

string selectedAttackUnit = "";
string selectedDefenceUnit = "";
string selectedBonus = "";
string inputCombatTurns = "";
int numberOfCombat = 0;

int resultAttack = 0;
int resultDefence = 0;
float winPercentage = 0;
float wins = 0;
float lose = 0;

bool bonusFlag = false;

string[] bonusArray = new string[8];

BaseVariables attacker = new BaseVariables();
BaseVariables defender = new BaseVariables();
Random rnd = new Random();

//Sätter värdena till arrayen
for(int i = 0; i < bonusArray.Length; i++)
{
    bonusArray[i] = i.ToString();
} 

//Användaren väljer enhet som attackerar
while (selectedAttackUnit != "1" && selectedAttackUnit != "2")
{
    Console.WriteLine("Select Attack unit: ");
    Console.WriteLine("1: Melee\n2: Ranged\n");

    selectedAttackUnit = Console.ReadLine();

    if (selectedAttackUnit == "1")
    {
        attacker = new Melee();
    }
    else if (selectedAttackUnit == "2")
    {
        attacker = new Ranged();
    }
    else
    {
        Console.WriteLine("Please choose a valid answer");
    }
 }


//Användaren väljer vilken bonus attackenheten ska ha
while(!bonusFlag)
{
    Console.WriteLine("Select bonustype for attacker");
    attacker.printBonus(attacker.units[selectedAttackUnit]);

    selectedBonus = Console.ReadLine();
    
    for(int i = 0; i < bonusArray.Length; i++)
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

//Användaren väljer enhet som försvarar
while(selectedDefenceUnit != "1" && selectedDefenceUnit != "2" && selectedDefenceUnit != "3")
{
    Console.WriteLine("Select defence unit:");
    Console.WriteLine("1: Melee\n2: Ranged\n3: Siege");

    selectedDefenceUnit = Console.ReadLine();

    if(selectedDefenceUnit == "1")
    {
        defender = new Melee();
    }
    else if(selectedDefenceUnit == "2") 
    {
        defender = new Ranged();
    }
    else if(selectedDefenceUnit == "3")
    {
        defender = new Siege();
    }
    else
    {
        Console.WriteLine("Please choose a valid answer");
    }
}

//Väljer bonustyp för försvararen
if(selectedDefenceUnit != "3")
{
    while (!bonusFlag)
    {
        Console.WriteLine("Select bonustype for defender");
        attacker.printBonus(attacker.units[selectedAttackUnit]);

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

while(!Int32.TryParse(inputCombatTurns, out numberOfCombat))
{
    Console.WriteLine("Enter number of attacks: ");
    inputCombatTurns = Console.ReadLine();
}

for(int i = 0; i < numberOfCombat; i++)
{
    resultAttack = attacker.Attack + rnd.Next(1, 9);
    resultDefence = defender.Armor + rnd.Next(1, 9);

    if(resultAttack - resultDefence <= 0)
    {
        lose++;
    }
    else
    {
        wins++;
    }
}

winPercentage = wins / numberOfCombat * 100;

Console.WriteLine($"{attacker.Name} defeated {defender.Name} {wins} times.");
Console.WriteLine($"Number of turns: {numberOfCombat}\nNumber of wins: {wins}\nNumber of loses: {lose}\nWin %: {(float)winPercentage}%");

Console.WriteLine("Press any button to exit...");
Console.ReadLine();


