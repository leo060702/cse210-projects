using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding your breath. Focus on your breathing and calm your mind.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountDown(4); // Adjust as needed
            Console.WriteLine("\nBreathe out...");
            ShowCountDown(6); // Adjust as needed
        }
        DisplayEndingMessage();
    }
}
