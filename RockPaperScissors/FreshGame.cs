using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    internal class FreshGame
    {
        private enum RPSOption
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3,
            Spock = 4,
        }

        //class to represent the game
        //contain rules and important values

        //method to compare player's choice to computer's choice
        //(rock)1 - (paper)2 = -1 computer wins
        //graphics, wins/losses/score, method to generate computer's choice, method to capture user's choice
        //method to ask if user wants to play again, method to display instructions, method to update score

        //display the game on the screen
        public string Menu
        {
            get
            {
                return @"
---------------------------
| Player: 0 | Computer: 0 |
---------------------------
What would you like to throw?
1) Rock
2) Paper
3) Scissors
";
            }
        }

        private RPSOption _playerChoice;
        private RPSOption _computerChoice;

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine(Menu);

        }

        public void StartRound(bool showInstructions = false) //optional parameter
        {
            DisplayMenu();
            //TODO - handle a way to show the instructions if user types something invalid
            if (showInstructions)
            {
                Console.WriteLine("Please enter a number from 1-3");
            }
            CaptureUserInput();
        }

        public void CaptureUserInput()
        {
            var userInput = Console.ReadLine();
            if (ValidUserInput(userInput))
            {
                DetermineWinnerOfRound();

            }
            else
            {
                StartRound(true);
            }
        }

        private void DetermineWinnerOfRound()
        {
            //Get computer's choice
            var computerChoiceAsInt = new Random().Next(1, 3);
            _computerChoice = (RPSOption)computerChoiceAsInt;
            //decimal choiceAsDecimal = Convert.ToDecimal(choice);

            //compare it with player's choice
            if (_computerChoice == RPSOption.Rock)
            {
                if (_playerChoice == RPSOption.Paper)
                {
                    //do something
                }
            }


            //string, int, int


            //show the end result
            //increment the score
            //show the new score with next round
        }

        private bool ValidUserInput(string? userInput)
        {
            //validate input
            // business/game rules would go in validation section
            var result = int.TryParse(userInput, out int inputAsInteger);
            
            if (result)
            {
                _playerChoice = (RPSOption)inputAsInteger;
            }

            return (result && (inputAsInteger > 0 && inputAsInteger < 4));
        }
        //collect user input
        //determine computer's choice
        //compare the choices
        //display the result






    }
}
