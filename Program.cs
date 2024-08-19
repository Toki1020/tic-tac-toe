using System;
using System.ComponentModel;

namespace myprogram
{
    class Program
    {
        static char[,] board = {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        static char currentPlayer = 'X';

        static void Main()
        {
            Console.Clear();
            do
            {
                DrawBoard();
                PlayerMove();
                SwitchPlayer();
            }while (!Win() && !Tie());
        }
        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe");
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write($" {board[i,j]} ");
                    if(j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if(i < 2) Console.WriteLine("-----------");
            }
            Console.WriteLine();
        }
        static void PlayerMove()
        {
            int move = 0;
            bool validmove = false;
            do
            {
                Console.Write($"Player {currentPlayer}, enter your move: ");
                string input = Console.ReadLine();
                if (input == "end")
                {
                    Console.WriteLine("Game ended.");
                    Environment.Exit(0);
                }
                if(int.TryParse(input, out move) && move >= 1 && move <= 9)
                {
                    validmove = Updateboard(move);
                    if(!validmove) Console.WriteLine("invalid move, cell already taken.");
                }   
                else
                {
                    Console.WriteLine("Invalid move, enter number between 1-9.");
                }
            }while (!validmove);
        }
        static bool Updateboard(int move)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;
            if(board[row,col] == 'X' || board[row,col] == 'O')
            {
                return false;
            }
            board[row,col] = currentPlayer;
            return true;
        }
        static void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
        static bool Win()
        {
            return WinRow() || WinCol() || WinDia();
        }
        static bool WinRow()
        {
            for(int i = 0; i < 3;i++)
            {
                if(board[i,0] == board[i,1] && board[i,1] == board[i,2])
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    DrawBoard();
                    Console.WriteLine($"Player {currentPlayer} won!");
                    return true;
                }
            }
            return false;
        }
        static bool WinCol()
        {
            for(int i = 0; i < 3;i++)
            {
                if(board[0,i] == board[1,i] && board[1,i] == board[2,i])
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    DrawBoard();
                    Console.WriteLine($"Player {currentPlayer} won!");
                    return true;
                }
            }
            return false;
        }
        static bool WinDia()
        {
            if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
                (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                DrawBoard();
                Console.WriteLine($"Player {currentPlayer} won!");
                return true;
            }
            return false;
        }
        static bool Tie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != 'X' && board[i, j] != 'O')
                    {
                        return false;
                    }
                }
            }
            DrawBoard();
            Console.WriteLine("Tie!");
            return true;
        }
    }
}