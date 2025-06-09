using System;
using System.Threading;

public abstract class Activity
{
    // Shared properties
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Display the starting message and get the duration
    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"{_description}");
        Console.Write("Please enter the duration (in seconds): ");
        while (!int.TryParse(Console.ReadLine(), out _duration))
        {
            Console.Write("Please enter a valid number of seconds: ");
        }
        Console.WriteLine("Get ready...");
        ShowSpinner(3);  // Pause for a few seconds
    }

    // Display the ending message
    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Display a spinner animation
    public void ShowSpinner(int seconds)
    {
        int delay = 250; // milliseconds between updates
        int spinnerSteps = (seconds * 1000) / delay;
        string[] spinner = { "|", "/", "-", "\\" };

        for (int i = 0; i < spinnerSteps; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(delay);
            Console.Write("\b \b"); // Erase previous character
        }
    }

    // Display a countdown timer
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Each activity must implement its own Run method
    public abstract void Run();
}
