using System.Linq;

namespace SudokuSolver;

internal class BruteForceRecursionSolver : ISolve
{
  public void Solve(Sudoku sudoku)
  {
    bool changed;

    do
    {
      changed = false;

      foreach (var cell in sudoku.Cells.Where(x => x.Value == 0))
        foreach (var value in Enumerable.Range(1, 9))
        {
          if (!OnlyPossibility(sudoku, cell, value)) continue;
          var inserted = sudoku.InsertValue(value, cell.CellIndex);
          if (inserted) changed = true;
        }
    } while (!sudoku.IsSolved && changed);

    //TODO: Continue with https://stackoverflow.com/questions/29545388/sudoku-backtracking-using-c-sharp
  }

  private static bool OnlyPossibility(Sudoku sudoku, Cell cell, int value)
  {
    var otherPossibleCells = sudoku.Cells
      .Where(c => c.Value == 0)
      .Where(x => x.BlockIndex == cell.BlockIndex || x.RowIndex == cell.RowIndex || x.ColIndex == cell.ColIndex)
      .Where(x => x.CellIndex != cell.CellIndex);

    var ruleChecker = new RuleChecker(sudoku);

    return otherPossibleCells.All(otherPossibleCell => !ruleChecker.CheckInsertion(otherPossibleCell, value));
  }
}
