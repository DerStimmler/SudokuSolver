using System;
using System.Text.RegularExpressions;

namespace SudokuSolver;

internal class Program
{
  private static void Main(string[] args)
  {
    var input = string.Empty;
    var solverType = -1;

    switch (args.Length)
    {
      case 1:
        input = args[0];
        solverType = -1;
        break;
      case 2:
        input = args[0];
        solverType = Convert.ToInt32(args[1]);
        break;
    }

    if (string.IsNullOrWhiteSpace(input))
    {
      Console.WriteLine("Enter a Sudoku from left to right, top to bottom. For empty cells enter a 0.");
      input = Console.ReadLine();
    }

    if (!Regex.IsMatch(input ?? string.Empty, "(0|[1-9]){81}"))
    {
      Console.WriteLine("Invalid input. You have to enter 81 signs in form of dots or numbers from 1-9.");
      Console.ReadKey();
      return;
    }

    if (solverType == -1)
    {
      Console.WriteLine("Enter a Solver Type [1-2]");
      solverType = Convert.ToInt32(Console.ReadLine());
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
