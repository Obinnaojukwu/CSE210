using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string _name;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
        _isComplete = false;
    }

    public abstract void RecordEvent();

    public virtual string GetDetailsString()
    {
        return $"[ ] {_name}";
    }

    public bool IsComplete()
    {
        return _isComplete;
    }

    public int GetPoints()
    {
        return _points;
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetDetailsString()
    {
        return _isComplete ? $"[X] {_name}" : base.GetDetailsString();
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
    
    }
}

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
        }
    }

    public override string GetDetailsString()
    {
        return _isComplete ? $"[X] {_name} (Completed {_currentCount}/{_targetCount})"
                           : $"[ ] {_name} (Completed {_currentCount}/{_targetCount})";
    }

    public int GetBonusPoints()
    {
        return _isComplete ? _bonusPoints : 0;
    }
}

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();
            _score += goal.GetPoints();

            if (goal is ChecklistGoal checklistGoal)
            {
                _score += checklistGoal.GetBonusPoints();
            }
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Your score is: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetDetailsString());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("Menu Option: ");
            Console.WriteLine("1. Create Simple Goals");
            Console.WriteLine("2. Create Eternal Goals");
            Console.WriteLine("3. Checklist Goals");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. List Goals");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Exit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string simpleGoalName = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int simpleGoalPoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new SimpleGoal(simpleGoalName, simpleGoalPoints));
                    break;
                case "2":
                    Console.Write("Enter goal name: ");
                    string eternalGoalName = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int eternalGoalPoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new EternalGoal(eternalGoalName, eternalGoalPoints));
                    break;
                case "3":
                    Console.Write("What is the name of the goal? : ");
                    string checklistGoalName = Console.ReadLine();
                    Console.Write("What is the amount of point associated with this goal? ");
                    int checklistGoalPoints = int.Parse(Console.ReadLine());
                    Console.Write("How many times does this goal needs to be accomplished for a bonus?  ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new ChecklistGoal(checklistGoalName, checklistGoalPoints, targetCount, bonusPoints));
                    break;
                case "4":
                    manager.ShowGoals();
                    Console.Write("Enter goal number: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoalEvent(goalIndex);
                    break;
                case "5":
                    manager.ShowGoals();
                    break;
                case "6":
                    manager.ShowScore();
                    break;
                case "7":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    manager.SaveGoals(saveFilename);
                    break;
                case "8":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    manager.LoadGoals(loadFilename);
                    break;
                case "9":
                    return;
            }
        }
    }
}