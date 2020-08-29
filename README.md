# SudokuSolver

Small .NET Core Console Application to solve a Sudoku with the use of Brute-Forcing.

## How to use?

You can pass a sudoku as argument or enter it inside the console while the application is running.
Just type the values of the cells from left to right, top to bottom behind each other as one long string. If a cell is empty enter a dot (.).

Example:
`.26...19....8.6.....1.4.3..74.....81..8...7..16.....53..7.3.4.....2.7....32...67.`

Currently it only works with 9x9 Sudokus.

![alt text](./example-sudoku.PNG "Example Sudoku")

## How does it work?

The Program iterates over every empty cell and tries to insert the values from 1 to 9. The insertion only works if the rules of Sudoku are not broken.
When the Sudoku is solved or no new insertions were made in the last iteration the application stops.
