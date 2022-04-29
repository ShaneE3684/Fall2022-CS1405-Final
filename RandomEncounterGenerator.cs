//Shane Esplin, CS 1405 Final

using System.Diagnostics;
using System;

class RandomEncounterGenerator
{
    static void Main()
    {
        int players = 0;
        double averageECL = 0.0;
        string environment = "All";
        string difficulty = "Normal";
        int userInput = 0;

        //Read text file of monsters, and place into Dictionary list
        Dictionary<string, List<string>> monsterList = new Dictionary<string, List<string>>();
        string[] monsterStringList = File.ReadAllLines("DnD_Monster_List.txt");

        string monsterName;
              
        foreach(string allMonsterInfo in monsterStringList)
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



        Console.Clear();
        //User Greeting
        Console.WriteLine("Hello. This program helps a DM to make a random encounter for their group.");
        Console.WriteLine("If you enter in the number of players in the group, the average ecl of the group, and the environment the group is in,");
        Console.WriteLine("this program will give you an encounter based on the difficulty you desire for the encounter.");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Press and key to begin.");

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
            Console.WriteLine("3) Choose an environment ('All' by default).");
            Console.WriteLine("4) Set the difficulty ('Normal' by default).");
            Console.WriteLine("5) Create an encounter (must have a valid value in player number and average ECL).");
            Console.WriteLine("0) Exit the program.");

            userInput = int.Parse(Console.ReadLine());

            switch(userInput)
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
                    Console.WriteLine("Test Case 3");

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                
                case 4:
                    Console.Clear();
                    Console.WriteLine("Test Case 4");

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                
                case 5:
                    Console.Clear();
                    Console.WriteLine("Test Case 5");

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;

                case 0:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That is not a valid input.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
            }

        }while(userInput != 0);

        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Thank you for using this program.");
    }

    static void PlayerNumberEntry(ref int players)
    {
        Console.Write("Please enter the total number of players in the group:");
        players = int.Parse(Console.ReadLine());
    }

    static void AverageECLEntry(ref double averageECL)
    {
        Console.Write("Please enter the average ECL of the players in the group:");
        averageECL = double.Parse(Console.ReadLine());
    }

    static void EnvironmentEntry(ref string environment)
    {

    }

    static void SetDifficulty(ref string difficulty)
    {

    }

     static void CreatEncounter()
    {

    }

}