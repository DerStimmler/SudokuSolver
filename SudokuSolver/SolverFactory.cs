namespace SudokuSolver;

internal static class SolverFactory
{
  public static ISolve CreateSolver(int solverType)
  {
    return solverType switch
    {
      1 => new BacktrackingSolver(),
      2 => new BruteForceRecursionSolver(),
      _ => new BacktrackingSolver()
    };
  }
}
