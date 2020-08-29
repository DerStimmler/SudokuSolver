using System;
using System.Text;

namespace SudokuSolver
{
    internal class SudokuPrinter
    {
        public static string Print(Sudoku sudoku)
        {
            var sb = new StringBuilder();
            sb.AppendLine("⌜-----------------------------⌝");

            for (var i = 0; i < sudoku.Cells.Count; i++)
            {
                if (i % 9 == 0 && i / 9 != 0)
                {
                    sb.Append("|" + Environment.NewLine);
                    if (i % (9 * 3) == 0) sb.Append("|-----------------------------|" + Environment.NewLine);
                }

                if (i % 3 == 0) sb.Append("|");

                var value = sudoku.Cells[i].Value;
                sb.Append(" " + (value == -1 ? " " : value.ToString()) + " ");
            }

            sb.AppendLine("|" + Environment.NewLine + "⌞-----------------------------⌟");

            return sb.ToString();
        }
    }
}