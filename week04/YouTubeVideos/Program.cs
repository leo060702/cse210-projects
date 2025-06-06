// YouTube Video Abstraction Program - Week 04 Foundation Project
// Name: Zhili Zhong
// Date: 05/28/2025
// Purpose: Demonstrate abstraction by creating classes for YouTube videos and comments

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("What is Abstraction?", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Really helpful, thanks."));
        video1.AddComment(new Comment("Charlie", "Awesome content!"));
        videos.Add(video1);

        Video video2 = new Video("C# Basics", "Jane Smith", 450);
        video2.AddComment(new Comment("Dave", "Clear and concise."));
        video2.AddComment(new Comment("Eva", "Love the examples."));
        video2.AddComment(new Comment("Frank", "Very useful, thanks!"));
        videos.Add(video2);

        Video video3 = new Video("OOP Principles", "Mark Lee", 600);
        video3.AddComment(new Comment("Grace", "Super informative."));
        video3.AddComment(new Comment("Henry", "Helped me understand a lot."));
        video3.AddComment(new Comment("Ivy", "Keep it up!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            comment.Display();
        }
    }
}

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"- {Name}: {Text}");
    }
}
