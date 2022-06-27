namespace SudokuSolver;

internal class Cell
{
  public Cell() { }

  public Cell(int cellIndex, int value)
  {
    CellIndex = cellIndex;
    RowIndex = CalculateRowIndex(cellIndex);
    ColIndex = CalculateColIndex(cellIndex);
    BlockIndex = CalculateBlockIndex(cellIndex);
    Value = value;
  }

  public int RowIndex { get; init; }
  public int ColIndex { get; init; }
  public int CellIndex { get; init; }
  public int BlockIndex { get; init; }
  public int Value { get; set; }

  private static int CalculateRowIndex(int cellIndex) => cellIndex / 9;

  private static int CalculateColIndex(int cellIndex) => cellIndex % 9;

  private static int CalculateBlockIndex(int cellIndex)
  {
    var row = CalculateRowIndex(cellIndex);
    var col = CalculateColIndex(cellIndex);

    var blockRow = row / 3;
    var blockCol = col / 3;

    return blockRow * 3 + blockCol;
  }
}
