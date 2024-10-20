using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

class SudokuGame
{
    static int[,] board = new int[9, 9];
    static int[,] solution = new int[9, 9];

    static void Main(string[] args)
    {
        InitializeBoard();
        while (true)
        {
            Console.Clear();
            DisplayBoard();

            if (IsSolved())
            {
                Console.WriteLine("Congratulations! You've solved the Sudoku puzzle!");
                break;
            }

            Console.Write("Enter row (1-9): ");
            int row = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter column (1-9): ");
            int col = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter value (1-9): ");
            int value = int.Parse(Console.ReadLine());

            if (IsValidMove(row, col, value))
            {
                board[row, col] = value;
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
                Console.ReadKey();
            }
        }
    }

    // Initializes a predefined Sudoku board with a solution (for simplicity)
    static void InitializeBoard()
    {
        // A partially filled Sudoku board (0 represents empty spaces)
        board = new int[,]
        {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };

        // The solution to the predefined board
        solution = new int[,]
        {
            {5, 3, 4, 6, 7, 8, 9, 1, 2},
            {6, 7, 2, 1, 9, 5, 3, 4, 8},
            {1, 9, 8, 3, 4, 2, 5, 6, 7},
            {8, 5, 9, 7, 6, 1, 4, 2, 3},
            {4, 2, 6, 8, 5, 3, 7, 9, 1},
            {7, 1, 3, 9, 2, 4, 8, 5, 6},
            {9, 6, 1, 5, 3, 7, 2, 8, 4},
            {2, 8, 7, 4, 1, 9, 6, 3, 5},
            {3, 4, 5, 2, 8, 6, 1, 7, 9}
        };
    }

    // Displays the current state of the Sudoku board
    static void DisplayBoard()
    {
        Console.WriteLine("Sudoku Puzzle:");
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] == 0)
                    Console.Write(". ");
                else
                    Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Validates if the move is valid (checks if the row, column, and subgrid are valid)
    static bool IsValidMove(int row, int col, int value)
    {
        if (board[row, col] != 0) // Don't allow overwriting non-zero values
        {
            return false;
        }

        // Check row
        for (int i = 0; i < 9; i++)
        {
            if (board[row, i] == value)
            {
                return false;
            }
        }

        // Check column
        for (int i = 0; i < 9; i++)
        {
            if (board[i, col] == value)
            {
                return false;
            }
        }

        // Check 3x3 subgrid
        int startRow = (row / 3) * 3;
        int startCol = (col / 3) * 3;

        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (board[i, j] == value)
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Checks if the Sudoku board is fully solved
    static bool IsSolved()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] != solution[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}


