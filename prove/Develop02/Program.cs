using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Entry> journalEntries = new List<Entry>();

    static void Main(string[] args)
    {
        LoadJournalFromFile(); // Load existing entries from a file (if any)

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    Console.WriteLine("Exiting the journal application. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void WriteNewEntry()
    {
        Console.WriteLine("\nSelecting a random prompt for your entry...");
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");

        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        DateTime currentTime = DateTime.Now;

        Entry newEntry = new Entry(randomPrompt, response, currentTime);
        journalEntries.Add(newEntry);

        Console.WriteLine("Entry added successfully!");
    }

    static string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
            // Add more prompts as desired
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Count);
        return prompts[randomIndex];
    }

    static void DisplayJournal()
    {
        Console.WriteLine("\nJournal Entries:");
        foreach (var entry in journalEntries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    static void SaveJournalToFile()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in journalEntries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine($"Journal saved to {filename}.");
    }

    static void LoadJournalFromFile()
    {
        Console.Write("Enter a filename to load the journal: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            journalEntries.Clear(); // Clear existing entries
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                if (parts.Length == 3)
                {
                    DateTime date = DateTime.Parse(parts[0]);
                    string prompt = parts[1];
                    string response = parts[2];
                    journalEntries.Add(new Entry(prompt, response, date));
                }
            }

            Console.WriteLine($"Journal loaded from {filename}.");
        }
        else
        {
            Console.WriteLine($"File {filename} does not exist.");
        }
    }
}

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}