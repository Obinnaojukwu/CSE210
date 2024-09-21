using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = squareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favourite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int squareNumber(int number)
    {
        return number * number;
    }
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, The square of your number is {squaredNumber}");
    }
}
