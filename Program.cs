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

        if (numberOfGuesses > 1)
        {
          Console.WriteLine("Guess a secret number, {0} guesses remaining", numberOfGuesses);
        }
        else
        {
          Console.WriteLine("Guess a secret number, {0} guess remaining", numberOfGuesses);
        }
        
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
        if (difficulty != 4) numberOfGuesses--;
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
        { 3, "Hard" },
        { 4, "Cheater" }
      };

      DisplayMenu();

      Console.SetCursorPosition(0, 1);
      Console.CursorVisible = false;
      HighlightCurrentLine(difficultySettings, 1);

      var k = Console.ReadKey();
      var i = 1;
      while (k.Key != ConsoleKey.Enter)
      {
        
        DisplayMenu();
        
        if (k.Key == ConsoleKey.UpArrow && i >= 1)
        {
          if (i > 1) 
          {
            Console.SetCursorPosition(0, i - 1);
          }
          else
          {
            Console.SetCursorPosition(0, i);
          }
          HighlightCurrentLine(difficultySettings, Console.CursorTop);
          if (i > 1) i--;
        }
        
        else if (k.Key == ConsoleKey.DownArrow && i <= 4)
        {
          if (i < 4) 
          {
            Console.SetCursorPosition(0, i + 1);
          }
          else
          {
            Console.SetCursorPosition(0, i);
          }
          HighlightCurrentLine(difficultySettings, Console.CursorTop);
          if (i < 4) i++;
        }
        
        k = Console.ReadKey();
      }
      Console.CursorVisible = true;
      return i;

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
        case 4:
          guesses = 1;
          break;
      }

      return guesses;
    }

    static void DisplayMenu()
    {
      Console.Clear();
      Console.WriteLine("Choose Your Difficulty:");
      Console.WriteLine("Easy");
      Console.WriteLine("Medium");
      Console.WriteLine("Hard");
    }

    static void HighlightCurrentLine(Dictionary<int, string> settings, int key)
    {
      Console.ForegroundColor = ConsoleColor.Black;
      Console.BackgroundColor = ConsoleColor.White;
      Console.WriteLine(settings[key]);
      Console.ResetColor();
    }

  }
}