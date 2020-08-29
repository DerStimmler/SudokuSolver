using System.Linq;

namespace SudokuSolver
{
    internal class Solver
    {
        public static void Solve(Sudoku sudoku)
        {
            bool changed;

            do
            {
                changed = false;

                foreach (var cell in sudoku.Cells.Where(x => x.Value == -1))
                foreach (var value in Enumerable.Range(1, 9))
                {
                    var inserted = sudoku.InsertValue(value, cell.CellIndex);
                    if (inserted) changed = true;
                }
            } while (!sudoku.IsSolved && changed);
        }
    }
}