//Shane Esplin, CS 1405 Final

using System.Diagnostics;
using System;

class RandomEncounterGenerator
{
    static void Main()
    {
        //variable declaration
        int players = 0;
        double averageECL = 0.0;
        string environment = "Any";
        string difficulty = "Challenging";
        int userInput = 0;
        string[] difficulties = { "Cake-Walk", "Very-Easy", "Easy", "Medium", "Challenging", "Hard", "Very-Hard", "Overwhelming", "Impossible" };

        //Read text file of monsters, and place into Dictionary list
        Dictionary<string, List<string>> monsterList = new Dictionary<string, List<string>>();
        string[] monsterStringList = File.ReadAllLines("DnD_Monster_List.txt");

        string monsterName;

        foreach (string allMonsterInfo in monsterStringList)
        {
            string[] monsterSplit = allMonsterInfo.Split("::");

            monsterName = monsterSplit[0];
            string[] monsterInfo = monsterSplit[1].Split(" ");

            monsterList[monsterName] = new List<string>();
            monsterList[monsterName].Add(monsterInfo[0]);
            monsterList[monsterName].Add(monsterInfo[1]);

            Array.Clear(monsterSplit, 0, monsterSplit.Length);
            Array.Clear(monsterInfo, 0, monsterInfo.Length);
        }

        //Get list of possible environments
        List<string> possibleEnvironments = new List<string>();
        foreach (var monster in monsterList)
        {
            string thisEnvironment = monster.Value[1];
            if (!possibleEnvironments.Contains(thisEnvironment))
                possibleEnvironments.Add(monster.Value[1]);
        }
        possibleEnvironments.Sort();



        Console.Clear();
        //User Greeting
        Console.WriteLine("Hello. This program helps a DM to make a random encounter for their group.");
        Console.WriteLine("If you enter in the number of players in the group, the average ecl of the group, and the environment the group is in,");
        Console.WriteLine("this program will give you an encounter based on the difficulty you desire for the encounter.");
        Console.WriteLine("This program works best when all players are at least near the same ECL, and only gives the names of the monsters in the encounter.");
        Console.WriteLine("Note: This program does not incude enhanced or changed monsters in its list, such as skeletons, liches, or ghosts.");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Press any key to begin.");
        Console.ReadKey();

        do
        {
            Console.Clear();
            Console.WriteLine("Players: " + players);
            Console.WriteLine("Average Player ECL: " + averageECL);
            Console.WriteLine("Environmnet: " + environment);
            Console.WriteLine("Difficulty: " + difficulty);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1) Enter the number of players (0 by default).");
            Console.WriteLine("2) Enter the average ECL of the players (0 by default).");
            Console.WriteLine("3) Choose an environment ('Any' by default).");
            Console.WriteLine("4) Set the difficulty ('Challenging' by default).");
            Console.WriteLine("5) Create an encounter (must have a valid value in player number and average ECL).");
            Console.WriteLine("0) Exit the program.");

            userInput = int.Parse(Console.ReadLine());


            switch (userInput)
            {
                case 1:
                    Console.Clear();
                    PlayerNumberEntry(ref players);
                    break;

                case 2:
                    Console.Clear();
                    AverageECLEntry(ref averageECL);
                    break;

                case 3:
                    Console.Clear();
                    EnvironmentEntry(ref environment, possibleEnvironments);
                    break;

                case 4:
                    Console.Clear();
                    SetDifficulty(ref difficulty, difficulties);
                    break;

                case 5:
                    Console.Clear();
                    if (players <= 0 || averageECL <= 0)
                    {
                        Console.WriteLine("Please make sure you have entered a valid amount into the needed data fields");
                        Console.WriteLine("The number of players and the average player ECL must be greater than 0.");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        CreatEncounter(players, averageECL, environment, difficulty, monsterList);
                    }
                    break;

                case 0:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That is not a valid input.");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
            }

        } while (userInput != 0);

        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Thank you for using this program.");
    }






    //Method to enter total number of players
    static void PlayerNumberEntry(ref int players)
    {
        Console.Write("Please enter the total number of players in the group:");
        players = int.Parse(Console.ReadLine());
    }


    //Method to enter average ECL of players
    static void AverageECLEntry(ref double averageECL)
    {
        Console.Write("Please enter the average ECL of the players in the group:");
        averageECL = double.Parse(Console.ReadLine());
    }


    //Method to enter the desired environment of the encounter
    static void EnvironmentEntry(ref string environment, List<string> allEnvironments)
    {
        do
        {
            Console.WriteLine("Please enter the environment you would like from the list below.");
            Console.WriteLine("Make sure to include any dashes or capital letters");
            foreach (string setting in allEnvironments)
            {
                Console.WriteLine(setting);
            }
            Console.WriteLine("");
            environment = Console.ReadLine();
            //Check that the entry is valid
            Console.Clear();
            if (!allEnvironments.Contains(environment))
                Console.WriteLine("That is not a valid entry.");
            Console.WriteLine("");
        } while (!allEnvironments.Contains(environment));
    }


    //Method to enter in the desired difficulty level of the encounter
    static void SetDifficulty(ref string difficulty, string[] allDifficulties)
    {
        do
        {
            Console.WriteLine("Please enter the difficulty you would like from the list below.");
            Console.WriteLine("Make sure to include any dashes or capital letters");
            foreach (string setting in allDifficulties)
            {
                Console.WriteLine(setting);
            }
            difficulty = Console.ReadLine();
            //Check that the entry is valid
            Console.Clear();
            if (!allDifficulties.Contains(difficulty))
                Console.WriteLine("That is not a valid entry.");
            Console.WriteLine("");
        } while (!allDifficulties.Contains(difficulty));
    }



    //Method to choose and display the monsters in the encounter, based on the data entered by the user
    static void CreatEncounter(int players, double ECL, string environment, string difficulty, Dictionary<string, List<string>> monsters)
    {
        //Disclaimer about possible ridiculous groups of monsters.
        Console.WriteLine("Disclaimer: Depending on the environment and difficulty,");
        Console.WriteLine("this program may not make a typical group of monsters.");
        Console.WriteLine("Any strange group of monsters is up to you as the DM to explain.");
        Console.WriteLine("");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();

        //Test the GetPossibleMonsterList method
        Debug.Assert(GetPossibleMonsterList(monsters, "Limbo").Count == 35);
        Debug.Assert(GetPossibleMonsterList(monsters, "Underground").Count == 68);
        Debug.Assert(GetPossibleMonsterList(monsters, "Air-Plane").Count == 50);
        Debug.Assert(GetPossibleMonsterList(monsters, "Any").Count == 538);


        //Get list of available monsters based on chosen environment
        List<string> possibleMonsters = new List<string>();
        
        possibleMonsters = GetPossibleMonsterList(monsters, environment);
        int monsterLimit = 0;

        //Test the CalculateEncounterDifficulty method.
        Debug.Assert(CalculateEncounterDifficulty(4, 1, "Challenging", ref monsterLimit) == 1);
        Debug.Assert(CalculateEncounterDifficulty(4, 4, "Medium", ref monsterLimit) == 3);
        Debug.Assert(CalculateEncounterDifficulty(8, 20, "Impossible", ref monsterLimit) == 49);

        //Get the encouter difficulty
        double encounterDifficulty = CalculateEncounterDifficulty(players, ECL, difficulty, ref monsterLimit);

        //Remove the monsters from the possible list that are too high of a difficulty level.
        for (int i = 0; i < possibleMonsters.Count; i++)
        {
            if (double.Parse(monsters[possibleMonsters[i]][0]) > encounterDifficulty)
            {
                possibleMonsters.Remove(possibleMonsters[i]);
                i--;
            }
        }

        //Remove the monsters from the possible list that are too low of a difficulty level.
        for (int i = 0; i < possibleMonsters.Count; i++)
        {
            if (double.Parse(monsters[possibleMonsters[i]][0]) < ECL - 10)
            {
                possibleMonsters.Remove(possibleMonsters[i]);
                i--;
            }
        }


        //Randomly choose monsters for the encounter from the available list, while adjusting the list of available monsters.
        double currentDifficulty = 0.0;
        var random = new Random();
        int index = 0;
        string currentMonster;
        List<string> chosenMonsters = new List<string>();
        int currentMonsters = 0;
        while (currentMonsters < monsterLimit && currentDifficulty < encounterDifficulty - 0.1)
        {

            //Check monsters and remove those that have a difficulty that is too high.
            for (int i = 0; i < possibleMonsters.Count; i++)
            {
                if (double.Parse(monsters[possibleMonsters[i]][0]) + currentDifficulty > encounterDifficulty)
                {
                    possibleMonsters.Remove(possibleMonsters[i]);
                }
            }
            if(possibleMonsters.Count == 0)
            {
                break;
            }
            //Select the next monster to be put on the list.
            index = random.Next(possibleMonsters.Count);
            currentMonster = possibleMonsters[index];
            if (monsterLimit == 1)
            {
                if (double.Parse(monsters[currentMonster][0]) == encounterDifficulty)
                {
                    chosenMonsters.Add(currentMonster);
                    currentDifficulty = currentDifficulty + double.Parse(monsters[currentMonster][0]);
                    currentMonsters++;
                }
                else
                { }
            }
            else
            {
                if ((double.Parse(monsters[currentMonster][0]) < encounterDifficulty) && ((currentDifficulty + double.Parse(monsters[currentMonster][0])) <= encounterDifficulty))
                {
                    chosenMonsters.Add(currentMonster);
                    currentDifficulty = currentDifficulty + double.Parse(monsters[currentMonster][0]);
                    currentMonsters++;
                }
                else if (currentDifficulty + double.Parse(monsters[currentMonster][0]) < encounterDifficulty - 1)
                {
                    chosenMonsters.Add(currentMonster);
                    currentMonsters++;
                }
                else
                { }
            }
            if (possibleMonsters.Count == 0)
                break;
        }

        //Display the chosen monsters to the user.
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Here is the list of chosen monsters for the encounter.");
        Console.WriteLine("");
        foreach (string monster in chosenMonsters)
        {
            Console.WriteLine(monster);
        }
        Console.WriteLine("");

        Console.WriteLine("Press any key to go back to the menu.");
        Console.ReadKey();
    }


    //Calculate numerical difficulty of encounter based on difficulty level chosen, total players, and average ECL.
    static double CalculateEncounterDifficulty(int totalPlayers, double ECL, string difficulty, ref int monsterLimit)
    {
        double encounterDifficulty = 0.0;
        double playerModifyer = (totalPlayers / 4);
        if (playerModifyer < 0.5)
        {
            playerModifyer = 0.5;
        }
        switch (difficulty)
        {
            case "Cake-Walk":
                encounterDifficulty = (ECL - 4) + (playerModifyer - 1);
                monsterLimit = 1;
                if (encounterDifficulty < 0)
                {
                    encounterDifficulty = 0.5;
                }
                break;

            case "Very-Easy":
                encounterDifficulty = ECL - 3 + (playerModifyer - 1);
                monsterLimit = 4;
                if (encounterDifficulty < 0)
                {
                    encounterDifficulty = 0.8;
                }
                break;

            case "Easy":
                encounterDifficulty = ECL - 2 + (playerModifyer - 1);
                monsterLimit = 5;
                if (encounterDifficulty < 0)
                {
                    encounterDifficulty = 0.95;
                }
                break;

            case "Medium":
                encounterDifficulty = ECL - 1 + (playerModifyer - 1);
                monsterLimit = 200;
                if (encounterDifficulty < 0)
                {
                    encounterDifficulty = 1;
                }
                break;

            case "Challenging":
                encounterDifficulty = ECL + (playerModifyer - 1);
                monsterLimit = 200;
                break;

            case "Hard":
                encounterDifficulty = (ECL * 1.25) + 1 + (playerModifyer - 1);
                monsterLimit = 5;
                break;

            case "Very-Hard":
                encounterDifficulty = (ECL * 1.5) + 3 + (playerModifyer - 1);
                monsterLimit = 10;
                break;

            case "Overwhelming":
                encounterDifficulty = (ECL * 1.75) + 5 + (playerModifyer - 1);
                monsterLimit = 8;
                break;

            case "Impossible":
                encounterDifficulty = (ECL * 2) + 8 + (playerModifyer - 1);
                monsterLimit = 5;
                break;
        }
        return encounterDifficulty;
    }

    static List<string> GetPossibleMonsterList (Dictionary<string, List<string>> allMonsters, string chosenEnvironment)
    {
        List<string> monsterList = new List<string>();
        foreach (var monster in allMonsters.Keys.ToList())
        {
            if (allMonsters[monster][1] == chosenEnvironment || allMonsters[monster][1] == "Any" || chosenEnvironment == "Any")
                monsterList.Add(monster);
        }
        return monsterList;
    }
}