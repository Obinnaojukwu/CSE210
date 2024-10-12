using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> vids = new List<Video>();

        Video vid1 = new Video("C# Programming Basics", "TechWithTim", 600);
        vid1.AddComment(new Comment("Alice", "Great explanation!"));
        vid1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        vid1.AddComment(new Comment("Charlie", "I had trouble with loops, but this helped."));
        vids.Add(vid1);

        Video vid2 = new Video("Funny Cat Compilation", "Cats4Life", 300);
        vid2.AddComment(new Comment("Dave", "Hilarious video!"));
        vid2.AddComment(new Comment("Eve", "Cats are the best!"));
        vids.Add(vid2);

        Video vid3 = new Video("How to Cook Pasta", "ChefJohn", 900);
        vid3.AddComment(new Comment("Fay", "I followed this and it turned out perfect!"));
        vid3.AddComment(new Comment("George", "Could you do one on pizza next?"));
        vid3.AddComment(new Comment("Hannah", "The video length was perfect for this recipe."));
        vids.Add(vid3);

        foreach (var vid in vids)
        {
            Console.WriteLine($"Title: {vid.Title}");
            Console.WriteLine($"Author: {vid.Author}");
            Console.WriteLine($"Length: {vid.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {vid.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (var comment in vid.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
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

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}