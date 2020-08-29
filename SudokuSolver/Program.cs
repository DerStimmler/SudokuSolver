using System;
using System.Text.RegularExpressions;

namespace SudokuSolver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input;

            if (args.Length != 0)
            {
                input = args[0];
            }
            else
            {
                Console.WriteLine("Enter a Sudoku from left to right, top to bottom. For empty cells enter a '.'.");
                input = Console.ReadLine();
            }


            if (!Regex.IsMatch(input, "(.|[1-9]){81}"))
            {
                Console.WriteLine("Invalid input. You have to enter 81 signs in form of dots or numbers from 1-9.");
                Console.ReadKey();
                return;
            }

            var sudoku = new Sudoku(input);

            Console.WriteLine(SudokuPrinter.Print(sudoku));

            Solver.Solve(sudoku);

            if (!sudoku.IsSolved)
            {
                Console.WriteLine("Could not be solved!");
                Console.WriteLine(SudokuPrinter.Print(sudoku));
                Console.ReadKey();
                return;
            }

            Console.WriteLine(SudokuPrinter.Print(sudoku));
            Console.ReadKey();
            return;
        }
    }
}