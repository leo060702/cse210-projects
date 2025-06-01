// Journal Program - Week 02 Project
// Name: Zhili Zhong
// Date: 05/19/2025
// Purpose: Help users write and manage daily journal entries using abstraction

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = -1;
        while (choice != 5)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        journal.AddEntry(new Entry(prompt, response));
                        break;
                    case 2:
                        journal.DisplayEntries();
                        break;
                    case 3:
                        Console.Write("Enter filename to save: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;
                    case 4:
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;
                    case 5:
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToShortDateString();
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileString()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 3)
        {
            Entry entry = new Entry(parts[1], parts[2]);
            entry.Date = parts[0];
            return entry;
        }
        return null;
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded.");
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}

