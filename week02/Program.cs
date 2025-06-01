// ---------------------------------------------
// Author: Zhili Zhong
// Date: 2025-05-14
// Project: CSE 210 - C# Programming Exercise 2
// ---------------------------------------------

using System;

class Program
{
    static void Main()
    {
        // Ask the user to enter their grade percentage
        Console.Write("Please enter your grade percentage (0-100): ");
        string input = Console.ReadLine();

        // Convert input string to integer
        int grade = int.Parse(input);

        // Define a variable to store the letter grade
        string letter;

        // Determine the letter grade using if-else-if structure
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Output the letter grade
        Console.WriteLine($"Your letter grade is: {letter}");

        // Determine pass/fail and give a message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard for next time.");
        }
    }
}
