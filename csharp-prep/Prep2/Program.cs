using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Whats your grade ? ");
        string Grade = Console.ReadLine();

        int Grades = int.Parse(Grade);

        string letter = "";
        string signs = "";

        if (Grades >= 90)
        {
            letter = "A";
            Console.WriteLine("You got an A");
        }
        else if (Grades >= 80)
        {
            letter = "B";
           Console.WriteLine("You got a B");
        }
        else if (Grades >= 70)
        {
            letter = "C";
            Console.WriteLine("You got a C");
        }
        else if (Grades >= 60)
        {
            letter = "D";
            Console.WriteLine("You got a D");
        }
        else 
        {
            letter = "F";
            Console.WriteLine("You got an F");
        }

        if (Grades >= 70)
        {
            Console.WriteLine("Congratulations! You PASSED the course");
        }
        else 
        {
            Console.WriteLine("You FAILED this course. Try again next semester");
        }

        int courseSign = Grades % 10;
        if (Grades != 90 && Grades <= 70 )
        {
            if (courseSign >= 7)
            {
                signs = "+";
            }
            else if (courseSign < 3)
            {
                signs = "-";
            }
        }

        if (Grades >= 90)
        {
            signs = "";
        } 
        if (Grades <= 70)
        {
            signs = "";
        }

        Console.WriteLine($"Your grade is: {letter}{signs}");



    }
}