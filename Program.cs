using System;

namespace GuessingGame
{
  class Program
  {
    static void Main(string[] args)
    {
      int numberOfGuesses = 4;
      int secretNumber = 42;
      //* Initialize guess to be "null" to begin executing while
      //? The question mark indicates that the string can be nullable
      //? Without it a warning is present  
      string? guess = "null";
      //* Initialize num to 0 for TryParse method 
      int num;

      while(!Int32.TryParse(guess, out num) || numberOfGuesses > 0)
      {
        Console.Clear();
        if (secretNumber == num || numberOfGuesses == 0) break;
        Console.WriteLine("Guess a secret number, {0} guesses remaining", numberOfGuesses);
        
        if (num > 0)
        {
          Console.WriteLine("Previous Guess: {0}", guess);
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
  }
}