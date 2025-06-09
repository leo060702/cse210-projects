using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you accomplished something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was over?",
        "What made this experience different from other times?",
        "What is your favorite part of this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
        : base("Reflecting Activity", "This activity will help you reflect on times when you showed strength and resilience, so you can recognize the power you have.")
    {
    }

    // Randomly select a prompt from the list
    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    // Randomly select a question from the list
    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public override void Run()
    {
        DisplayStartingMessage();

        // Display a random prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nConsider the following prompt\n--- {prompt} ---");
        Console.WriteLine("\nWhen you have an experience in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow reflect on the following questions:");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"> {question}");
            ShowSpinner(5); // Allow time to reflect on each question
        }
        DisplayEndingMessage();
    }
}
