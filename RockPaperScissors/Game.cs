using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    internal class Game
    {
        private enum GameChoice
        {
            None = -1,
            Rock = 1,
            Paper = 2,
            Scissors = 3,
        }

        private enum RoundResult
        {
            Win,
            Lose,
            Draw,
            Other,
            Foo
        }

        internal Game()
        {
            _playerScore = 0;
            _computerScore = 0;
            _currentPlayerChoice = GameChoice.None;
            _currentComputerChoice = GameChoice.None;
            _graphics = new()
            {
                { GameChoice.Rock, _rockGraphic },
                { GameChoice.Paper, _paperGraphic },
                { GameChoice.Scissors, _scissorsGraphic },
            };

        }

        private string _playerName;
        private int _playerScore;
        private int _computerScore;
        private GameChoice _currentPlayerChoice;
        private GameChoice _currentComputerChoice;
        private readonly string _rockGraphic = @"
    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
";
        private readonly string _paperGraphic = @"
     _______
---'    ____)____
           ______)
          _______)
         _______)
---.__________)
";
        private readonly string _scissorsGraphic = @"
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)
";
        private Dictionary<GameChoice, string> _graphics;

        public string Menu
        {
            get
            {
                return @$"
-------------------------------
|  {_playerName}: {_playerScore}  |  Computer: {_computerScore}  |
-------------------------------

What would you like to throw?
1) Rock
2) Paper
3) Scissors
";
            }

        }
        

        public void StartRound()
        {
            CheckForName();
            ShowMenu();
            GetPlayerInput();
        }

        private void CheckForName()
        {
            if (_playerName == "")
            {
                
                
                //AskForName();
            }
        }

        private void GetPlayerInput()
        {
            string input = Console.ReadKey().KeyChar.ToString();
            int parseResult = int.Parse(input);
            //bool tryParseResult = int.TryParse(input, out int inputAsInt);
            if (!String.IsNullOrWhiteSpace(input) && int.TryParse(input, out int inputAsInt))
            {
                _currentPlayerChoice = (GameChoice)inputAsInt; //cast from int to GameChoice
                _currentComputerChoice = (GameChoice)(new Random().Next(1, 4)); //cast from int to GameChoice
                ShowGraphicsForChoices();
                DetermineOutcomeOfRound();
            }
            else //invalid input
            {
                StartRound();
            }
        }

        private void ShowGraphicsForChoices()
        {
            var graphicResult = @$"
{_graphics[_currentPlayerChoice]}


VS


{_graphics[_currentComputerChoice]}
";
            Console.WriteLine(graphicResult);
        }

        private void DetermineOutcomeOfRound()
        {

            

            switch (_currentPlayerChoice)
            {
                case GameChoice.Rock:
                    switch (_currentComputerChoice)
                    {
                        case GameChoice.Rock:
                            EndRound(RoundResult.Draw);
                            break;
                        case GameChoice.Paper:
                            EndRound(RoundResult.Lose);
                            break;
                        case GameChoice.Scissors:
                            EndRound(RoundResult.Win);
                            break;
                    }
                    break;

                case GameChoice.Paper:
                    switch (_currentComputerChoice)
                    {
                        case GameChoice.Rock:
                            EndRound(RoundResult.Win);
                            break;
                        case GameChoice.Paper:
                            EndRound(RoundResult.Draw);
                            break;
                        case GameChoice.Scissors:
                            EndRound(RoundResult.Lose);
                            break;
                    }
                    break;

                case GameChoice.Scissors:
                    switch (_currentComputerChoice)
                    {
                        case GameChoice.Rock:
                            EndRound(RoundResult.Lose);
                            break;
                        case GameChoice.Paper:
                            EndRound(RoundResult.Win);
                            break;
                        case GameChoice.Scissors:
                            EndRound(RoundResult.Draw);
                            break;
                    }
                    break;

                default:
                    StartRound();
                    break;


            }
        }

        private void EndRound(RoundResult result)
        {
            switch (result)
            {
                case RoundResult.Win:
                    _playerScore++;
                    break;
                case RoundResult.Lose:
                    _computerScore++;
                    break;
                default:
                    break;
            }

            if (_playerScore > 2 || _computerScore > 2)
            {
                DisplayFinalMessage();
            }
            else
            {
                Console.WriteLine($"You {result}!");
                Console.Write("Press any key to play next round...");
                Console.ReadLine();
                StartRound();
            }
        }

        private void DisplayFinalMessage()
        {
            bool isVictory = _playerScore > _computerScore;
            string message = isVictory ? "YOU WIN!!!" : "YOU LOSE!!!";
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(Menu);
        }


    }
}

