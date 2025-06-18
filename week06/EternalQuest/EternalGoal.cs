
using System;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, int points) : base(name, points)
    {
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        Console.WriteLine($"You have earned {_points} points! Completed {_timesCompleted} time(s).");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never truly "complete"
    }

    public override string GetStatus()
    {
        return $"[∞] Completed {_timesCompleted} time(s)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_points},{_timesCompleted}";
    }
}
