
using System;

public abstract class Goal
{
    protected string _name;
    protected int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }
}
