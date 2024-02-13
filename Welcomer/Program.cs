// Basic interaction
using System;

public class WelcomeProgram
{
    public static void Main(string[] args)
    {
        WelcomeInteraction();
    }

    public static void WelcomeInteraction()
    {
        Console.WriteLine("Hello, what's your name ?");
        string name = Console.ReadLine()!;

        Console.WriteLine($"Hello {name}! Where are you born ?");
        int birthYear;
        while (!int.TryParse(Console.ReadLine()!, out birthYear) || birthYear < 0 || birthYear > DateTime.Now.Year) 
        {
            Console.WriteLine("Nice try but enter a valid birth year.");
        }

        int age = DateTime.Now.Year - birthYear;

        Console.WriteLine($"So you are around {age}. May I ask another question ? (yes/no)");
        string response = Console.ReadLine()!.ToLower();

        while (response != "yes" && response != "no")
        {
            Console.WriteLine("Enter 'yes' or 'no'.");
            response = Console.ReadLine()!.ToLower();
        }

        if (response == "yes") 
        {
            Console.WriteLine("That was a test and you pass it ! Take a two dollars deposit in gift.");
            int deposit = 2;
            Console.WriteLine($"Current deposit : {deposit}$");
        }

        if (response == "no") 
        {
            Console.WriteLine("Bye then.");
        }
    }
}
