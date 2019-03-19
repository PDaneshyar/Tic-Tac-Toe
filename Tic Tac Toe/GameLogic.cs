using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class GameLogic
    {
        static List<int> range = new List <int>();
        static Random rand = new Random();
        
        // logic for AI moves
        public int MakeMove(char[] board, char compMarker, char pMarker)
        {
            range.Clear();

            // checks if board is empty then makes a random move if it is
            if (!board.Contains('X') && !board.Contains('O'))
            {
                return rand.Next(1, 9);
            }
            // check to see if AI can win then go there
            else if((board[2] == compMarker && board[3] == compMarker) ||
                (board[5] == compMarker && board[9] == compMarker) || 
                (board[4] == compMarker && board[7] == compMarker))
            {
                if (board[1] != pMarker)
                {
                    return 1;
                }
            }   
            else if ((board[1] == compMarker && board[3] == compMarker) || 
                (board[5] == compMarker && board[8] == compMarker))
            {
                if (board[2] != pMarker)
                {
                    return 2;
                }
            }
            else if ((board[1] == compMarker && board[2] == compMarker) || 
                (board[6] == compMarker && board[9] == compMarker) || 
                (board[5] == compMarker && board[7] == compMarker)) 
            {
                if (board[3] != pMarker)
                {
                    return 3;
                }
            }
            else if ((board[5] == compMarker && board[6] == compMarker) || 
                (board[1] == compMarker && board[7] == compMarker))
            { 
                if (board[4] != pMarker)
                {
                    return 4;
                }
            }
            else if ((board[1] == compMarker && board[9] == compMarker) || 
                (board[2] == compMarker && board[8] == compMarker) ||
                (board[3] == compMarker && board[7] == compMarker) || 
                (board[4] == compMarker && board[6] == compMarker)) 
            {                                                    
                if (board[5] != pMarker)
                {
                    return 5;
                }
            }
            else if ((board[4] == compMarker && board[5] == compMarker) || 
                (board[3] == compMarker && board[9] == compMarker))
            {
                if (board[6] != pMarker)
                {
                    return 6;
                }
            }
            else if ((board[1] == compMarker && board[4] == compMarker) || 
                (board[3] == compMarker && board[5] == compMarker) || 
                (board[8] == compMarker && board[9] == compMarker)) 
            {
                if (board[7] != pMarker)
                {
                    return 7;
                }
            }
            else if ((board[7] == compMarker && board[9] == compMarker) ||
                (board[2] == compMarker && board[5] == compMarker))
            {
                if (board[8] != pMarker)
                {
                    return 8;
                }
            }
            else if ((board[3] == compMarker && board[6] == compMarker) || 
                (board[7] == compMarker && board[8] == compMarker) || 
                (board[1] == compMarker && board[5] == compMarker))
            {
                if (board[9] != pMarker) 
                {
                    return 9;
                }        
            }
            
            // check to see if player can win then block
            if ((board[2] == pMarker && board[3] == pMarker) || 
                (board[5] == pMarker && board[9] == pMarker) || 
                (board[4] == pMarker && board[7] == pMarker))
            {
                if (board[1] != compMarker)
                {
                    return 1;
                }
            }
            else if ((board[1] == pMarker && board[3] == pMarker) || 
                (board[5] == pMarker && board[8] == pMarker))
            {
                if (board[2] != compMarker)
                {
                    return 2;
                }
            }
            else if ((board[1] == pMarker && board[2] == pMarker) || 
                (board[6] == pMarker && board[9] == pMarker) || 
                (board[5] == pMarker && board[7] == pMarker))
            {
                if (board[3] != compMarker)
                {
                    return 3;
                }
            }
            else if ((board[5] == pMarker && board[6] == pMarker) || 
                (board[1] == pMarker && board[7] == pMarker))
            {
                if (board[4] != compMarker)
                {
                    return 4;
                }
            }
            else if ((board[1] == pMarker && board[9] == pMarker) || 
                (board[2] == pMarker && board[8] == pMarker) || 
                (board[3] == pMarker && board[7] == pMarker) || 
                (board[4] == pMarker && board[6] == pMarker))
            {
                if (board[5] != compMarker)
                {
                    return 5;
                }
            }
            else if ((board[4] == pMarker && board[5] == pMarker) || 
                (board[3] == pMarker && board[9] == pMarker))
            {
                if (board[6] != compMarker)
                {
                    return 6;
                }
            }
            else if ((board[1] == pMarker && board[4] == pMarker) || 
                (board[3] == pMarker && board[5] == pMarker) || 
                (board[8] == pMarker && board[9] == pMarker))
            {
                if (board[7] != compMarker)
                {
                    return 7;
                }
            }
            else if ((board[7] == pMarker && board[9] == pMarker) || 
                (board[2] == pMarker && board[5] == pMarker))
            {
                if (board[8] != compMarker)
                {
                    return 8;
                }
            }
            else if ((board[3] == pMarker && board[6] == pMarker) || 
                (board[7] == pMarker && board[8] == pMarker) || 
                (board[1] == pMarker && board[5] == pMarker))
            {
                if (board[9] != compMarker)
                {
                    return 9;
                }
            }

            // if no possible blocking/winning moves AI creates a list of available spaces
            // randomly chooses a space from the list for its' next move
            for (int i = 1; i <= 9; i++)
            {
                if (board[i] != pMarker && board[i] != compMarker)
                {
                    range.Add(i);
                }
               
            }

            return range[rand.Next(0, range.Count)]; ;
        }

        // function to check for the result of the match
        public int CheckWin(char[] board)
        {
            //Horzontal Winning Condtion
            //Winning Condition For First Row   
            if (board[1] == board[2]
                && board[2] == board[3])
            {
                return 1;
            }
            //Winning Condition For Second Row   
            else if (board[4] == board[5]
                && board[5] == board[6])
            {
                return 1;
            }
            //Winning Condition For Third Row   
            else if (board[7] == board[8]
                && board[8] == board[9])
            {
                return 1;
            }

            //vertical Winning Condtion
            //Winning Condition For First Column       
            else if (board[1] == board[4]
                && board[4] == board[7])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (board[2] == board[5]
                && board[5] == board[8])
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if (board[3] == board[6]
                && board[6] == board[9])
            {
                return 1;
            }

            // Diagonal Winning Condition
            else if (board[1] == board[5]
                && board[5] == board[9])
            {
                return 1;
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }

            // Checking for a draw
            // If all the cells or values are filled without a winner it is a draw 
            else if (board[1] != '1' && board[2] != '2' &&
                board[3] != '3' && board[4] != '4' &&
                board[5] != '5' && board[6] != '6' &&
                board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
