// Zhili Zhong
// Final Foundation: Inheritance and Polymorphism with Exercise Tracking
// Completed: 2025-06-18

using System;
using System.Collections.Generic;

abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / Minutes) * 60;
    public override double GetPace() => Minutes / _distance;
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance() => (_speed * Minutes) / 60;
    public override double GetPace() => 60 / _speed;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62; // miles
    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),
            new Cycling("03 Nov 2022", 45, 20.0),
            new Swimming("03 Nov 2022", 20, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
