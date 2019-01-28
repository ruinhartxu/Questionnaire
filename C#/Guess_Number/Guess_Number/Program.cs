using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[3];
            int totalChance = 3;
           
            //Generate 3 random 1-10 numbers
            for(var i = 0; i <= 2; i++)
            {
                numbers[i] = random.Next(1, 10);
            }

            Console.WriteLine("\nWelcome to the Game, Please guess three numbers in 1-10\n");
           
            //Three Chances to guess
            for (var i = 1; i <= totalChance; i++)
            {
                //Get Input Three Numbers
                int[] inputs = new int[3];
                var rightCount = 0;
                int validInput = 0;

                while (validInput < 3)
                {

                    string inputValue = Console.ReadLine();
                    int number;
                    if(Int32.TryParse(inputValue, out number))
                    {
                        inputs[validInput] = number;
                        validInput++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid number!");
                    }

                }

                foreach(var item in inputs)
                {
                  
                    if (numbers.Contains(item))
                        rightCount++;
                }
                if (rightCount == 3)
                {
                    Console.WriteLine("Contratulations! You win the game!");
                    break;
                }
                else
                {
                    if (i != 3)
                        Console.WriteLine(string.Format("Your answer: {0} is incorrect! You have {1} more chance(s) left",String.Join(",",inputs), totalChance - i));
                    else
                        Console.WriteLine(string.Format("Game Over! The correct numbers are {0}.",String.Join(",",numbers)));
                }
            }
            Console.ReadKey();
        }
    }
}
