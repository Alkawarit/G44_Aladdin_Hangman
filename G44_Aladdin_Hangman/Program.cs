using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G44_Aladdin_Hangman
{
    internal class Program
    {



        //private static void hangManPrint(int wrongGuess)
        //{
        //    if (wrongGuess == 0)
        //    {
        //        Console.WriteLine("----------");
        //        Console.WriteLine("|        |");
        //        Console.WriteLine("|        |");
        //        Console.WriteLine("|        |");
        //        Console.WriteLine("|        |");
        //        Console.WriteLine("|        |");
        //        Console.WriteLine("----------");
        //    }
        //    if (wrongGuess == 1)
        //    {
        //        Console.WriteLine("-----------");
        //        Console.WriteLine("|  \\   / |");
        //        Console.WriteLine("|   \\ /  |");
        //        Console.WriteLine("|    X   |");
        //        Console.WriteLine("|   / \\  |");
        //        Console.WriteLine("|  /   \\ |");
        //        Console.WriteLine("-----------");

        //    }
        //    if (wrongGuess == 2)
        //    {

        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine("      ");
        //        Console.WriteLine("      ");
        //        Console.WriteLine("      ");
        //        Console.WriteLine("      ");
        //    }
        //    if (wrongGuess == 3)
        //    {
        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("      ");
        //    }
        //    if (wrongGuess == 4)
        //    {
        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("    ===");
        //    }
        //    if (wrongGuess == 5)
        //    {
        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine(" o   |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("    ===");
        //    }
        //    if (wrongGuess == 6)
        //    {
        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine(" o   |");
        //        Console.WriteLine(" |   |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("    ===");
        //    }
        //    if (wrongGuess == 7)
        //    {
        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine(" o   |");
        //        Console.WriteLine("/|   |");
        //        Console.WriteLine("     |");
        //        Console.WriteLine("    ===");
        //    }
        //    if (wrongGuess == 8)
        //    {

        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine(" o    |");
        //        Console.WriteLine("/|\\   |");
        //        Console.WriteLine("      |");
        //        Console.WriteLine("     ===");
        //    }
        //    if (wrongGuess == 9)
        //    {
        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine(" o    |");
        //        Console.WriteLine("/|\\   |");
        //        Console.WriteLine("/     |");
        //        Console.WriteLine("     ===");
        //    }
        //    if (wrongGuess == 10)
        //    {
        //        Console.WriteLine("\n+----+");
        //        Console.WriteLine(" o    |");
        //        Console.WriteLine("/|\\   |");
        //        Console.WriteLine("/ \\   |");
        //        Console.WriteLine("     ===");
        //    }
        //}
        
        static void Main(string[] args)
        {


            // entre of game 
            Console.Clear();
            Console.WriteLine("******************Welcome to HangMan game... ************************");
            Console.WriteLine("Let's start ....!");
            Console.WriteLine();
            Console.WriteLine("Guess the word which I think about ...!");


            string[] listWords =  { "damscuse", "lion", "jellyfish",
                                   "sweden", "swimming", "eagle", "spirulina",
                                   "lexicon", "ocean", "samsung", "jupiter",
                                   "aphrodite", "toyota", "avokado", "javascript"};
            bool playAgain = false;

            Random random = new Random();

            int randIndex = random.Next(listWords.Length);
            string listWord = listWords[randIndex];

            // build the hiden word 
            StringBuilder answerWord = new StringBuilder();



            for (int i = 0; i < listWord.Length; i++)
            {
                answerWord.Append('_');
            }
            bool isDone = false;
            int round = 0;
            do
            {

                Console.WriteLine(answerWord.ToString());
                Console.WriteLine("\nRound : {0}", round);
                Console.WriteLine("Guess a letter or a word ...!");
                string answer;

                CheckEvent(out answer, answerWord);
                if (answer.Length == 1 && listWord.Contains(answer))
                {
                    for (int index = 0; index < listWord.Length; index++)
                    {
                        if (listWord[index] == answer[0]) { answerWord[index] = answer[0]; }
                        if (!answerWord.ToString().Contains('_'))
                        {
                            isDone = true;
                        }
                    }
                }
                else if (answer.Length > 1 && listWord == answer)
                {
                    isDone = true;
                }
                round++;
                while (round > 10 && isDone) ;

                if (isDone)
                {
                    Console.WriteLine("Good job.. you did it ..");
                    Console.WriteLine("The right word is :{0} ", listWord);
                }
                else
                {
                    Console.WriteLine("the right word is : {0}", listWord);
                    Console.WriteLine("Good luck ..!");
                }
                Console.WriteLine("Do you want to play again ? :(y or n");
                char selected = Console.ReadKey(true).KeyChar;

                while (selected != 'y' && selected != 'n')
                {
                    Console.WriteLine("please try again .. do you want to play again ? (y or n) : ");
                    selected = Console.ReadKey(true).KeyChar;

                }
                switch (selected)
                {
                    case 'y':
                        playAgain = true;
                        break;
                    case 'n':
                        Console.WriteLine("Thank you for playing HangMan game .. hope to see you again ...!\n goodBye!");
                        playAgain = false;
                        break;
                    default:
                        Console.WriteLine("error .. please try again ..!");
                        break;
                }
            } while (playAgain);
        }

        static void CheckEvent(out string answer, StringBuilder answerBuilder)
        {
            answer = Console.ReadLine()?.ToLower() ?? string.Empty;

            while (answer == string.Empty)
            {
                Console.WriteLine("Sorry but you have to insert somting.....!");
                Console.WriteLine();
                Console.WriteLine("Write a letter or your gusse word...");
                answer = Console.ReadLine() ?? string.Empty;
            }

            while (answer.Length == 1 && answerBuilder.ToString().Contains(answer))
            {
                Console.WriteLine("Sorry but this letter has already gussed .. try another..!");
                Console.WriteLine();
                Console.WriteLine("Write a letter or your gusse word...");
                answer = Console.ReadLine() ?? string.Empty;
            }

        }
    }
}
            
