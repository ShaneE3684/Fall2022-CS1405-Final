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
                    Console.WriteLine("Test Case 1");

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                
                case 2:
                    Console.Clear();
                    Console.WriteLine("Test Case 2");

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
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
            }

        }while(userInput != 0);

        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Thank you for using this program.");
    }

    static void CreatEncounter()
    {

    }

    static void PlayerNumberEntry()
    {

    }

    static void AverageECLEntry()
    {

    }

    static void EnvironmentEntry()
    {

    }
}