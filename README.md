# SudokuSolver

Small .NET Core Console Application to solve a Sudoku with the use of Brute-Forcing.

## How to use?

You can pass a sudoku as argument or enter it inside the console while the application is running.
Just type the values of the cells from left to right, top to bottom behind each other as one long string. If a cell is empty enter a zero (0).

Example:
`026000190000806000001040300740000081008000700160000053007030400000207000032000670`

![alt text](./example-sudoku.PNG "Example Sudoku")

You can also enter a number from 1-2 to define the Solver Type. Currently available are:

1. Backtracking (default)
2. BruteForce & Recursion

So a valid application call would be:
`SudokuSolver.exe 026000190000806000001040300740000081008000700160000053007030400000207000032000670 1`

Currently it only works with 9x9 Sudokus.

## How does it work?

The Program iterates over every empty cell and tries to insert the values from 1 to 9. The insertion only works if the rules of Sudoku are not broken.
When the Sudoku is solved or no new insertions were made in the last iteration the application stops.
