using System;
using System.Collections.Generic;

public abstract class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to the {name} Activity.");
        Console.WriteLine(description);
        Console.Write("How long, in seconds, would you like for your session?: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Pause(3);
        RunActivity();
        Finish();
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Finish()
    {
        Console.WriteLine($"You have completed another {duration} seconds of the {name} activity.");
        Pause(3);
    }

    protected abstract void RunActivity();
}

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you to breathe in and out slowly, clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        int interval = 5;

        while (duration > 0)
        {
            Console.WriteLine("Breathe in...");
            Pause(interval);
            Console.WriteLine("Now breathe out...");
            Pause(interval);
            duration -= interval * 2;
        }
    }
}

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspect of your life.")
    {
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        while (duration > 0)
        {
            string randomPrompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(randomPrompt);
            Pause(3);
            foreach (var question in questions)
            {
                Console.WriteLine(question);
                Pause(5);
                duration -= 5;
                if (duration <= 0)
                    break;
            }
        }
    }
}

public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things as you can in a certain area.")
    {
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(3);

        List<string> userResponses = new List<string>();
        while (duration > 0)
        {
            Console.Write("Enter an item: ");
            userResponses.Add(Console.ReadLine());
            duration -= 5;
        }
        Console.WriteLine($"You listed {userResponses.Count} items.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu Option:");
            Console.WriteLine("1. Start breathing Activity");
            Console.WriteLine("2. Start beflection Activity");
            Console.WriteLine("3. Start listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            activity.Start();
        }
    }
}