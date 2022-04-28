//Shane Esplin, CS 1405 Final

using System.Diagnostics;
using System;

class program
{
    static void Main()
    {
        Console.WriteLine("Hello. This program helps a DM to make a random encounter for their group.");
        Console.WriteLine("If you enter in the number of players in the group, the average ecl of the group, and the environment the group is in,");
        Console.WriteLine("this program will give you an encounter based on the difficulty you desire for the encounter.");
        Console.WriteLine("");
        Console.WriteLine("");

        ConsoleKey userInput;
        char charInput;

        do
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("A) Enter the number of players");
            Console.WriteLine("B) Enter the average ECL of the players");
            Console.WriteLine("C) Choose an environment.");
            Console.WriteLine("D) Create an encounter.");

            userInput = Console.ReadKey(true).Key;
            charInput = (char)userInput;

            switch(charInput)
            {
                case A:
                {
                    break;
                }
                case B:
                {
                    break;
                }

            }

        }while(userInput != ConsoleKey.Escape);
    }

    static void CreatEncounter()
    {

    }


}