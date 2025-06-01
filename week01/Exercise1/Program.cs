// ---------------------------------------------
// Author: Zhili Zhong
// Date: 2025-05-14
// Project: CSE 210 - C# Programming Exercise 1
// ---------------------------------------------

using System;

class Program
{
    static void Main()
    {
        // Ask for the user's first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask for the user's last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Output the formatted string: "Your name is last-name, first-name last-name."
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
