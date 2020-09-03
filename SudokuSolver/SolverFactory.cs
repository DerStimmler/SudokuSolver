namespace SudokuSolver
{
    internal class SolverFactory
    {
        public static ISolve CreateSolver(int solverType)
        {
            switch (solverType)
            {
                case 1:
                    return new BacktrackingSolver();
                case 2:
                    return new BruteForceRecursionSolver();
                default: return new BacktrackingSolver();
            }
        }
    }
}