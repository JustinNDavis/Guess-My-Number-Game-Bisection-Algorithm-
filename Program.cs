//Author: Justin Davis
//Date: 3/4/2020
//Purpose - the purpose of this program is to either guess a computers integer or have the computer guess yours!

using System;
using System.Collections.Generic;

namespace GuessMyNumber
{
    class Messages
    {
        public static void TooHigh()
        {
            Console.WriteLine("Too high");
        }
        public static void TooLow()
        {
            Console.WriteLine("Too low");
        }
        public static void Correct()
        {
            Console.WriteLine("Correct");
        }
    }
    class Program
    {
        public static ConsoleKeyInfo key;
        static void Main(string[] args)
        {
            //calls the appropriate method
            Console.WriteLine("1: You guess a number | 2: The computer guesses a number");
            key = Console.ReadKey();
            Console.Clear();
            if (key.Key == ConsoleKey.D1)
            {
                YouGuess();
            }
            if (key.Key == ConsoleKey.D2)
            {
                CompGuess();
            }
        }

        public static void YouGuess()
        {
            Random rand = new Random();
            int num = rand.Next(1, 1000);
            int guess = 0;

            while (guess != num)
            {
                try
                {
                    Console.WriteLine("I have picked a number between 1 and 1000");
                    Console.WriteLine("What is your guess (integer numbers only)?");
                    guess = int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid Response");
                }
                if (guess > num)
                {
                    Messages.TooHigh();
                }
                else if(guess < num)
                {
                    Messages.TooLow();
                }
                else
                {
                    Messages.Correct();
                    Console.ReadLine();
                }  
            }
            Environment.Exit(0);
        }

        public static void CompGuess()
        {
            int max = 100;
            int guess = max / 2;
            string answer = "n";
            int min = 1;
            int temp = 0;
            //ConsoleKeyInfo key;
            
            while(answer != "Y")
            {
                Console.WriteLine("Pick a number between 1 and 100 and I will try to guess it!");
                Console.WriteLine($"Is your number {guess}?");
                Console.WriteLine("H : Higher | L : Lower | C : Correct");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.H )
                {
                    temp = guess;
                    guess = guess + ((max - guess) / 2);
                    min = temp;
                    if(guess == 9)
                    { 
                        guess = max;
                    }
                }
                if(key.Key == ConsoleKey.L)
                {
                    temp = guess;
                    guess = guess - ((guess - min) / 2);
                    max = temp;
                    if (guess == 2)
                    {
                        guess = 1;
                    }
                }
                if (key.Key == ConsoleKey.C)
                {
                    answer = "Y";
                }
                Console.Clear();
            }
            Environment.Exit(0);
        }
    }
}
