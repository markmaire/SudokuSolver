using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class SudokuFileReader
    {
        public int[,] ReadFile(string fileName)
        {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                var sudokuBoardLines = File.ReadAllLines(fileName);
                int row = 0;
                foreach(var sudokuBoardLine in sudokuBoardLines)
                {
                    /*|1|2|3| |4| | |7|8|9|
                     * ToArray would return _,1,2,3,_,4,_,6,7,8,9,_ a total of 11 elements while using Split
                     * .Skip(1) will disregard the first "" which was a | and Take(9) will 'take' the next 9 disregarding last |/"" 
                     */
                    string[] sudokuBoardLineElements = sudokuBoardLine.Split('|').Skip(1).Take(9).ToArray();

                    int col = 0;
                    foreach (var sudokuBoardLineElement in sudokuBoardLineElements)
                    {
                        sudokuBoard[row, col] = sudokuBoardLineElement.Equals(" ") ? 0 : Convert.ToInt16(sudokuBoardLineElement);
                        col++;
                    }
                    row++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while reading the file: " + ex.Message);

            }
            return sudokuBoard;
        }
    }
}
