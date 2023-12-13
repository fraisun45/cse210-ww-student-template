using System;
using System.Collections.Generic;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

public class Activity
{
    public DateTime Date { get; set; }
    public int Length { get; set; }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return "";
    }
}

public class Running : Activity
{
    public double Distance { get; set; }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (Length / 60.0) * 0.621371;
    }

    public override double GetPace()
    {
        return (Length / 60.0) / (Distance / 1.60934);
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Running ({Length} min)- Distance {Distance:F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Cycling : Activity
{
    public double Speed { get; set; }

    public override double GetDistance()
    {
        return Speed * (Length / 60.0) * 0.621371;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60.0 / Speed;
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Cycling ({Length} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Swimming : Activity
{
    public int Laps { get; set; }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Length / 60.0) * 60;
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Swimming ({Length} min): Distance {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running
            {
                Date = new DateTime(2023, 12, 31),
                Length = 30,
                Distance = 3.0
            },
            new Cycling
            {
                Date = new DateTime(2023, 12, 31),
                Length = 30,
                Speed = 12.0
            },
            new Swimming
            {
                Date = new DateTime(2023, 12, 31),
                Length = 30,
                Laps = 20
            }
        };

        Console.WriteLine("");

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
