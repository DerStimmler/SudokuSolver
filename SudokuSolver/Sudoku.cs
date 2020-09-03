using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    internal class Sudoku
    {
        public List<Cell> Cells { get; set; }
        public bool IsSolved => CheckIfSolved();

        public Sudoku(string input)
        {
            Cells = new List<Cell>();

            for (var i = 0; i < input.Length; i++)
            {
                var value = 0;

                if (input[i] != '0') value = Convert.ToInt32(input[i].ToString());

                Cells.Add(new Cell(i, value));
            }
        }

        public bool InsertValue(int value, int cellIndex)
        {
            if (!new RuleChecker(this).CheckInsertion(cellIndex, value)) return false;

            var listIndex = Cells.FindIndex(x => x.CellIndex == cellIndex);
            Cells[listIndex].Value = value;
            return true;
        }

        public void ClearCell(int cellIndex)
        {
            var listIndex = Cells.FindIndex(x => x.CellIndex == cellIndex);
            Cells[listIndex].Value = 0;
        }

        private bool CheckIfSolved()
        {
            if (!Cells.Any(x => x.Value == 0))
                return true;

            return false;
        }
    }
}