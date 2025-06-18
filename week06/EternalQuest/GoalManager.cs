
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetName()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();

            if (_goals[index] is ChecklistGoal cg && cg.IsComplete())
            {
                _totalScore += cg.GetPoints() + 500;
            }
            else
            {
                _totalScore += _goals[index].GetPoints();
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public int GetScore()
    {
        return _totalScore;
    }

    public int GoalCount()
    {
        return _goals.Count;
    }

    public Goal GetGoal(int index)
    {
        return _goals[index];
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_totalScore);
            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _totalScore = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                string name = data[0];
                int points = int.Parse(data[1]);
                bool complete = bool.Parse(data[2]);
                var g = new SimpleGoal(name, points);
                if (complete) g.RecordEvent();
                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                string name = data[0];
                int points = int.Parse(data[1]);
                int count = int.Parse(data[2]);
                var g = new EternalGoal(name, points);
                for (int j = 0; j < count; j++) g.RecordEvent();
                _goals.Add(g);
            }
            else if (type == "ChecklistGoal")
            {
                string name = data[0];
                int points = int.Parse(data[1]);
                int target = int.Parse(data[2]);
                int current = int.Parse(data[3]);
                int bonus = int.Parse(data[4]);
                var g = new ChecklistGoal(name, points, target, bonus);
                for (int j = 0; j < current; j++) g.RecordEvent();
                _goals.Add(g);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}
