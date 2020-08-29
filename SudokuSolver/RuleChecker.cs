using System.Linq;

namespace SudokuSolver
{
    internal class RuleChecker
    {
        private Sudoku Sudoku { get; set; }

        public RuleChecker(Sudoku sudoku)
        {
            Sudoku = sudoku;
        }

        public bool CheckInsertion(int cellIndex, int value)
        {
            var cell = Sudoku.Cells.Where(x => x.CellIndex == cellIndex).SingleOrDefault();

            if (!(AllowedToInsert(cell, value) && OnlyPossibility(cell, value))) return false;

            return true;
        }

        private bool OnlyPossibility(Cell cell, int value)
        {
            var otherPossibleCells = Sudoku.Cells.Where(x => x.Value == -1).Where(x =>
                x.BlockIndex == cell.BlockIndex).Where(x => x.CellIndex != cell.CellIndex);

            foreach (var otherPossibleCell in otherPossibleCells)
                if (AllowedToInsert(otherPossibleCell, value))
                    return false;

            return true;
        }

        private bool AllowedToInsert(Cell cell, int value)
        {
            if (!(AllowedInRow(value, cell) && AllowedInBlock(value, cell) && AllowedInCol(value, cell))) return false;

            return true;
        }

        private bool AllowedInRow(int value, Cell cell)
        {
            var y = !Sudoku.Cells.Where(x => x.RowIndex == cell.RowIndex).Where(x => x.Value == value).Any();
            return y;
        }

        private bool AllowedInCol(int value, Cell cell)
        {
            return !Sudoku.Cells.Where(x => x.ColIndex == cell.ColIndex).Where(x => x.Value == value).Any();
        }

        private bool AllowedInBlock(int value, Cell cell)
        {
            return !Sudoku.Cells.Where(x => x.BlockIndex == cell.BlockIndex).Where(x => x.Value == value).Any();
        }
    }
}