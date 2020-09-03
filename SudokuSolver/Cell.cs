namespace SudokuSolver
{
    internal class Cell
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public int CellIndex { get; set; }
        public int BlockIndex { get; set; }
        public int Value { get; set; }

        public Cell()
        {
        }

        public Cell(int cellIndex, int value)
        {
            CellIndex = cellIndex;
            RowIndex = CalculateRowIndex(cellIndex);
            ColIndex = CalculateColIndex(cellIndex);
            BlockIndex = CalculateBlockIndex(cellIndex);
            Value = value;
        }

        private int CalculateRowIndex(int cellIndex)
        {
            return cellIndex / 9;
        }

        private int CalculateColIndex(int cellIndex)
        {
            return cellIndex % 9;
        }

        private int CalculateBlockIndex(int cellIndex)
        {
            var row = CalculateRowIndex(cellIndex);
            var col = CalculateColIndex(cellIndex);

            var blockRow = row / 3;
            var blockCol = col / 3;

            return blockRow * 3 + blockCol;
        }
    }
}