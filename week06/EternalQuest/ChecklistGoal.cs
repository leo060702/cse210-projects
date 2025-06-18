
using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) 
        : base(name, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            Console.WriteLine($"You have earned {_points} points!");

            if (_currentCount == _targetCount)
            {
                Console.WriteLine($"Congratulations! You completed the checklist goal and earned a bonus of {_bonusPoints} points!");
            }
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStatus()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_points},{_targetCount},{_currentCount},{_bonusPoints}";
    }
}
