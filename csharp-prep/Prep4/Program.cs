using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int RandomNum = -1;
        while (RandomNum != 0)
        {
            Console.Write("Enter number:  ");
            RandomNum = int.Parse(Console.ReadLine());

    
            
            if (RandomNum != 0)
            {
                numbers.Add(RandomNum);
            }
            
        }
        int addUp = 0;
        int averageNum = numbers[0];

        for (int i = 0; i < numbers.Count; i++)
        {
            // Console.WriteLine(numbers[i]);
            addUp += numbers[i];
            if (numbers[i] > averageNum)
            {
                averageNum = numbers[i];
            }
        }
        double average = (double)addUp / numbers.Count;

        Console.WriteLine($"The sum is: {addUp}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest Number is :{averageNum}");
    }
}