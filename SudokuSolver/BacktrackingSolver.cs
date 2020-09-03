using System;
using System.Linq;

namespace SudokuSolver
{
    internal class BacktrackingSolver : ISolve
    {
        public void Solve(Sudoku sudoku)
        {
            var cellsToSolve = sudoku.Cells.Where(x => x.Value == 0).ToList().ConvertAll(cell => new Cell
            {
                BlockIndex = cell.BlockIndex, CellIndex = cell.CellIndex, ColIndex = cell.ColIndex,
                RowIndex = cell.RowIndex, Value = cell.Value
            });

            var currentCell = 0;
            var newTry = true;

            while (!sudoku.IsSolved)
            {
                if (currentCell == -1) return;

                var cell = cellsToSolve[currentCell];

                if (newTry)
                {
                    cell.Value = 0;
                    newTry = false;
                }

                if (cell.Value == 9)
                {
                    currentCell--;
                    sudoku.ClearCell(cell.CellIndex);
                    cell.Value = 0;
                    continue;
                }

                cell.Value++;

                Console.WriteLine($"Trying {cell.Value} at {cell.CellIndex}");
                var success = sudoku.InsertValue(cell.Value, cell.CellIndex);

                if (success)
                {
                    currentCell++;
                    newTry = true;
                }
                else if (cell.Value == 9)
                {
                    sudoku.ClearCell(cell.CellIndex);
                    cell.Value = 0;
                    currentCell--;
                }
            }
        }
    }
}