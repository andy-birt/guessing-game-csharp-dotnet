using System;

namespace GuessingGame
{
  class Program
  {
    static void Main(string[] args)
    {
      //* Initialize guess to be "null" to begin executing while
      //? The question mark indicates that the string can be nullable
      //? Without it a warning is present  
      string? guess = "null";
      //* Initialize num to 0 for TryParse method 
      int num;

      while(!Int32.TryParse(guess, out num))
      {
        Console.WriteLine("Guess a secret number");
        guess = Console.ReadLine();
      }
      
      Console.WriteLine($"You guessed {guess}");
    }
  }
}