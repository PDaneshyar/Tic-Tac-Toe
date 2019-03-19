using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            int player;
            int choice;
            int flag = 0;
            char playerMarker;
            char AIMarker;
            string replay;
            bool play = true;
            int playerScore = 0;
            int compScore = 0;
            Random rnd = new Random();

            Console.WriteLine("Lets play Tic-Tac-Toe!");
            GameLogic AI = new GameLogic();
            Board gameBoard = new Board();
         
            // game will run as long as player wants to play
            while (play == true)
            {
                GameLoop();
            }

            // decides whether player or computer goes first
            void coinToss()
            {
                int firstTurn = rnd.Next(0, 2);
                if (firstTurn == 1)
                {
                    Console.WriteLine("You are first! You're X and you're green!");
                    playerMarker = 'X';
                    AIMarker = 'O';
                    player = 0;
                }
                else
                {
                    Console.WriteLine("You are second! You're O and you're green!");
                    playerMarker = 'O';
                    AIMarker = 'X';
                    player = 1;
                }
            }


            // main game loop will execute until there is a winner or it is a draw
            void GameLoop()
            {
                coinToss();
                do
                {
                    gameBoard.generateBoard();
                    if ((player % 2) == 0)
                    {
                        bool placement = false;
                        while (placement == false)
                        {
                            Console.ForegroundColor = System.ConsoleColor.Green;
                            // try catch used to ensure input is always a valid tile on the board
                            // user will be asked to input again if input is invalid
                            try
                            {
                                Console.WriteLine("Enter the number of the square you want to place your marker: ");
                                choice = int.Parse(Console.ReadLine());
                                gameBoard.board[choice] = playerMarker;
                                player++;
                                placement = true;
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("That is not a free tile on the board. Please enter a number between 1 and 9 that doesn't have a marker");
                            }
                        }
                    }
                    else
                    {
                        choice = AI.MakeMove(gameBoard.board, AIMarker, playerMarker);
                        Console.ForegroundColor = System.ConsoleColor.Red;
                        Console.WriteLine("The computer placed its marker on tile {0}", choice);
                        gameBoard.board[choice] = AIMarker;
                        player++;
                    }

                    flag = AI.CheckWin(gameBoard.board);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                } while (flag != 1 && flag != -1);

                // calls the result function
                Result();
            }

            // display the result of the game
            // offer player a chance to play again
            void Result()
            {
                bool again = false;
                if (flag == 1)
                {

                    if (player % 2 != 0)
                    {
                        playerScore++;
                        Console.WriteLine("You have won! congratulations");
                        Console.WriteLine("Do you want to play again? Y/N");
                        replay = Console.ReadLine().ToUpper();
                        while (again == false)
                        {
                            if (replay == "Y" || replay == "YES")
                            {
                                gameBoard = new Board();
                                GameLoop();
                                again = true;
                            }
                            else if (replay == "N" || replay == "NO")
                            {
                                again = true;
                                play = false;
                                Console.Clear();
                                Console.WriteLine("Computer Score: {0},  Player Score: {1}", compScore, playerScore);
                            }
                            else
                            {
                                Console.WriteLine("Sorry, did you say yes or no? ");
                                replay = Console.ReadLine().ToUpper();
                            }
                        }
                    }
                    else
                    {
                        compScore++;
                        Console.WriteLine("The computer has won, tough luck!");
                        Console.WriteLine("Do you want to play again? Y/N");
                        replay = Console.ReadLine().ToUpper();
                        while (again == false)
                        {
                            if (replay == "Y" || replay == "YES")
                            {
                                gameBoard = new Board();
                                GameLoop();
                                again = true;
                            }
                            else if (replay == "N" || replay == "NO")
                            {
                                again = true;
                                play = false;
                                Console.Clear();
                                Console.WriteLine("Computer Score: {0},  Player Score: {1}", compScore, playerScore);
                            }
                            else
                            {
                                Console.WriteLine("Sorry, did you say yes or no? ");
                                replay = Console.ReadLine().ToUpper();
                            }
                        }
                    }
                }
                else if (flag == -1)
                {
                    Console.WriteLine("The game is a draw!");
                    Console.WriteLine("Do you want to play again? Y/N");
                    replay = Console.ReadLine().ToUpper();
                    while (again == false)
                    {
                        if (replay == "Y" || replay == "YES")
                        {
                            gameBoard = new Board();
                            GameLoop();
                            again = true;
                        }
                        else if (replay == "N" || replay == "NO")
                        {
                            again = true;
                            play = false;
                            Console.Clear();
                            Console.WriteLine("Computer Score: {0},  Player Score: {1}", compScore, playerScore);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, did you say yes or no? ");
                            replay = Console.ReadLine().ToUpper();
                        }
                    }
                }

            }

        }
    }
}
