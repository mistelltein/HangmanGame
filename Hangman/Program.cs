using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "apple", "banana", "cherry", "grape", "orange",
                "strawberry", "blueberry", "watermelon", "pineapple", "mango",
                "kiwi", "pear", "peach", "apricot", "plum",
                "lemon", "lime", "pomegranate", "fig", "raspberry",
                "blackberry", "cranberry", "coconut", "guava", "dragonfruit",
                "passionfruit", "avocado", "melon", "lychee", "papaya"};
            Random rnd = new Random();
            string wordToGuess = words[rnd.Next(words.Length)];
            char[] guessedLetters = InitializeGuessedLetters(wordToGuess.Length);

            int attempts = 6;

            Console.WriteLine("Welcome to Hangman mini-game");
            Console.WriteLine("Try to guess the word: ");

            while (attempts > 0)
            {
                DisplayGuessedLetters(guessedLetters);
                Console.WriteLine($"Attempts left: {attempts}");
                char input = GetPlayerInput();

                bool found = UpdateGuessedLetters(wordToGuess, guessedLetters, input);

                if (!found)
                {
                    attempts--;
                }
                if (IsWordGuessed(guessedLetters, wordToGuess))
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
                    break;
                }
            }
            if(attempts == 0)
            {
                Console.WriteLine("Sorry, you're out of attempts! The word was: " + wordToGuess);
            }
        }
        static char[] InitializeGuessedLetters(int length)
        {
            char[] guessedLetters = new char[length];
            for(int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }
            return guessedLetters;
        }
        static void DisplayGuessedLetters(char[] guessedLetters)
        {
            Console.WriteLine(string.Join(" ", guessedLetters));
        }
        static char GetPlayerInput()
        {
            Console.WriteLine("Enter a letter: ");
            return Console.ReadLine()[0];
        }
        static bool UpdateGuessedLetters(string wordToGuess, char[] guessedLetters, char input)
        { 
            bool found = false;
            for(int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == input)
                {
                    guessedLetters[i] = input;
                    found = true;
                }
            }
            return found;
        }
        static bool IsWordGuessed(char[] guessedLetters, string wordToGuess)
        {
            return string.Join("", guessedLetters) == wordToGuess;
        }
    }
}
