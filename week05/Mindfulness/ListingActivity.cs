using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are the people you appreciate?",
        "What are your personal strengths?",
        "Who are the people you've helped this week?",
        "When have you felt the presence of the Holy Spirit this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Activity", "This activity will help you focus on the positive by prompting you to list as many items as you can based on a specific prompt.")
    {
    }

    // Randomly select a prompt from the list
    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public override void Run()
    {
        DisplayStartingMessage();

        // Display a random prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nYour prompt is:\n--- {prompt} ---");

        // Provide a countdown to give the user time to think
        Console.WriteLine("\nGet ready to start listing items...");
        ShowCountDown(5);

        Console.WriteLine("\nStart listing items (press Enter after each item; when time is up, stop):");
        List<string> userItems = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                userItems.Add(input);
            }
        }
        Console.WriteLine($"\nYou listed {userItems.Count} items!");
        DisplayEndingMessage();
    }
}
