using System;
using System.Collections.Generic;

namespace GuessingGame
{
  class Program
  {
    static void Main(string[] args)
    {
      int difficulty = GetDifficulty();
      int numberOfGuesses = SetDifficulty(difficulty);
      int secretNumber = new Random().Next(1, 100);
      //* Initialize guess to be "null" to begin executing while
      //? The question mark indicates that the string can be nullable
      //? Without it a warning is present  
      string? guess = "null";
      //* Initialize num to 0 for TryParse method 
      int num;

      while (!Int32.TryParse(guess, out num) || numberOfGuesses > 0)
      {
        Console.Clear();
        if (secretNumber == num || numberOfGuesses == 0) break;
        Console.WriteLine("Guess a secret number, {0} guesses remaining", numberOfGuesses);
        
        if (num > 0)
        {
          Console.WriteLine("Previous Guess: {0}", guess);
          if (num > secretNumber)
          {
            Console.WriteLine("Your guess was too high.");
          }
          else
          {
            Console.WriteLine("Your guess was too low.");
          }
        }

        guess = Console.ReadLine();
        numberOfGuesses--;
      }
      
      if (secretNumber == num)
      {
        Console.WriteLine($"NOICE! it totally is {guess}!");
      }
      else
      {
        Console.WriteLine($"WROOONNNG! it is {secretNumber}!");
      }
    }

    static int GetDifficulty()
    {
      Dictionary<int, string> difficultySettings = new Dictionary<int, string>()
      {
        { 1, "Easy" },
        { 2, "Medium" },
        { 3, "Hard" }
      };
      
      Console.Clear();
      Console.WriteLine("Easy");
      Console.WriteLine("Medium");
      Console.WriteLine("Hard");
      
      
      Console.SetCursorPosition(0, 0);
      Console.CursorVisible = false;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.BackgroundColor = ConsoleColor.White;
      Console.WriteLine(difficultySettings[1]);
      Console.ResetColor();

      var originalpos = Console.CursorTop;
      var k = Console.ReadKey();
      var i = 0;
      while (k.Key != ConsoleKey.Enter)
      {
        Console.Clear();
        Console.WriteLine("Easy");
        Console.WriteLine("Medium");
        Console.WriteLine("Hard");
        
        if (k.Key == ConsoleKey.UpArrow && i >= 0)
        {
          if (i > 0) 
          {
            Console.SetCursorPosition(0, i - 1);
          }
          else
          {
            Console.SetCursorPosition(0, 0);
          }
          Console.ForegroundColor = ConsoleColor.Black;
          Console.BackgroundColor = ConsoleColor.White;
          Console.WriteLine(difficultySettings[Console.CursorTop + 1]);
          Console.ResetColor();
          if (i > 0) i--;
        }
        
        else if (k.Key == ConsoleKey.DownArrow && i <= 2)
        {
          if (i < 2) 
          {
            Console.SetCursorPosition(0, i + 1);
          }
          else
          {
            Console.SetCursorPosition(0, i);
          }
          Console.ForegroundColor = ConsoleColor.Black;
          Console.BackgroundColor = ConsoleColor.White;
          Console.WriteLine(difficultySettings[Console.CursorTop + 1]);
          Console.ResetColor();
          if (i < 2) i++;
        }
        Console.SetCursorPosition(0, i);
        k = Console.ReadKey();
      }
      Console.CursorVisible = true;
      return Console.CursorTop + 1;

    }

    static int SetDifficulty(int difficulty)
    {
      
      int guesses = 0;

      switch(difficulty)
      {
        case 1:
          guesses = 8;
          break;
        case 2:
          guesses = 6;
          break;
        case 3: 
          guesses = 4;
          break;
      }

      return guesses;
    }

  }
}