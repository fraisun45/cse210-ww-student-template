using System;

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

public class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public Address Address { get; set; }

    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time.ToShortTimeString()}\nAddress: {Address}";
    }

    public virtual string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time.ToShortTimeString()}\nAddress: {Address}";
    }

    public virtual string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    public string SpeakerName { get; set; }
    public int Capacity { get; set; }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker Name: {SpeakerName}\nCapacity: {Capacity}";
    }
}

public class Reception : Event
{
    public string RSVP { get; set; }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Reception\nRSVP: {RSVP}";
    }
}

public class OutdoorGathering : Event
{
    public string Weather { get; set; }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather: {Weather}";
    }
}

public class Program
{
    public static void Main()
    {
        var lecture = new Lecture
        {
            Title = "The Future of AI",
            Description = "Join us for a discussion on the future of AI.",
            Date = new DateTime(2022, 12, 31),
            Time = new DateTime(2022, 12, 31, 18, 0, 0),
            Address = new Address
            {
                Street = "123 Main St",
                City = "Sacramento",
                State = "CA",
                Country = "USA"
            },
            SpeakerName = "John Smith",
            Capacity = 100
        };

        var reception = new Reception
        {
            Title = "New Year's Eve Party",
            Description = "Ring in the new year with us!",
            Date = new DateTime(2022, 12, 31),
            Time = new DateTime(2022, 12, 31, 20, 0, 0),
            Address = new Address
            {
                Street = "456 Elm St",
                City = "Bronx",
                State = "NY",
                Country = "USA"
            },
            RSVP = "newyear@party.com"
        };

        var outdoorGathering = new OutdoorGathering
        {
            Title = "Summer Picnic",
            Description = "Join us for a summer picnic in the park.",
            Date = new DateTime(2023, 7, 4),
            Time = new DateTime(2023, 7, 4, 12, 0, 0),
            Address = new Address
            {
                Street = "789 Oak St",
                City = "Dallas",
                State = "TX",
                Country = "USA"
            },
            Weather = "Sunny"
        };

        Console.WriteLine("");

        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine("");

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine("");

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
