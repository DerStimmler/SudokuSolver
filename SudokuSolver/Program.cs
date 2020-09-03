using System;
using System.Text.RegularExpressions;

namespace SudokuSolver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input = null;
            var solverType = -1;

#if DEBUG
            input = "026000190000806000001040300740000081008000700160000053007030400000207000032000670";
            solverType = 1;
#endif

            if (args.Length == 1)
            {
                input = args[0];
                solverType = 1;
            }
            else if (args.Length == 2)
            {
                input = args[0];
                solverType = Convert.ToInt32(args[1]);
            }

            if (input == null || solverType == -1)
            {
                Console.WriteLine("Enter a Sudoku from left to right, top to bottom. For empty cells enter a 0.");
                input = Console.ReadLine();
                Console.WriteLine("Enter a Solver Type [1-2]");
                solverType = Convert.ToInt32(Console.ReadLine());
            }


            if (!Regex.IsMatch(input, "(0|[1-9]){81}"))
            {
                Console.WriteLine("Invalid input. You have to enter 81 signs in form of dots or numbers from 1-9.");
                Console.ReadKey();
                return;
            }

            var sudoku = new Sudoku(input);

            Console.WriteLine(SudokuPrinter.Print(sudoku));

            var solver = SolverFactory.CreateSolver(solverType);

            solver.Solve(sudoku);

            if (!sudoku.IsSolved)
            {
                Console.WriteLine("Could not be solved!");
                Console.WriteLine(SudokuPrinter.Print(sudoku));
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(SudokuPrinter.Print(sudoku));
            Console.WriteLine();
            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }
    }
}