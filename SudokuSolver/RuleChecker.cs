using System.Linq;

namespace SudokuSolver;

internal class RuleChecker
{
  public RuleChecker(Sudoku sudoku)
  {
    Sudoku = sudoku;
  }

  private Sudoku Sudoku { get; set; }

  public bool CheckInsertion(int cellIndex, int value)
  {
    var cell = Sudoku.Cells.SingleOrDefault(x => x.CellIndex == cellIndex);

    return CheckInsertion(cell, value);
  }

  public bool CheckInsertion(Cell cell, int value) => AllowedToInsert(cell, value);

  private bool AllowedToInsert(Cell cell, int value) =>
    AllowedInRow(value, cell) && AllowedInBlock(value, cell) && AllowedInCol(value, cell);

  private bool AllowedInRow(int value, Cell cell)
  {
    return Sudoku.Cells
      .Where(x => x.RowIndex == cell.RowIndex)
      .Where(x => x.Value == value)
      .All(x => x.CellIndex == cell.CellIndex);
  }

  private bool AllowedInCol(int value, Cell cell)
  {
    return Sudoku.Cells
      .Where(x => x.ColIndex == cell.ColIndex)
      .Where(x => x.Value == value)
      .All(x => x.CellIndex == cell.CellIndex);
  }

  private bool AllowedInBlock(int value, Cell cell)
  {
    return Sudoku.Cells
      .Where(x => x.BlockIndex == cell.BlockIndex)
      .Where(x => x.Value == value)
      .All(x => x.CellIndex == cell.CellIndex);
  }
}
