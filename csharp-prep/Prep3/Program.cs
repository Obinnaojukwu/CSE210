using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number ? ");
        int  magicNumber = int.Parse(Console.ReadLine());

        int guess = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess ? ");
            guess = int.Parse(Console.ReadLine());

            if (guess == magicNumber)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else 
            {
                Console.WriteLine("Lower");
            }
        } 
    }
}