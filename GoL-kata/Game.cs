using System;
using System.Threading;

// COMPLETE. Holds game related functionality. 

namespace GoL_kata
{
    public class Game
    {
        private Board _board;
        private int _iteration = 0;
        
        private string boardType;

        public void Run()
        {
            Print();
            Console.Write("\nPress ANY KEY to end game...");
            
            bool run = true;
            string endMessage = "default message";
            
            while (run)
            { 
                Iterate();
                Print();

                Console.Write("\nPress ANY KEY to end game...");

                if (Console.KeyAvailable)
                {
                    run = false;
                    endMessage = "\n==> Game stopped by user";
                }

                if (_board.NoLiveCells())
                {
                    run = false;
                    endMessage = "\n==> Game ended as no live cells are left";
                }
            }

            Console.WriteLine(endMessage);
        }

        public void Iterate()
        {
            Board newBoard;

            switch (boardType)
            {
                case "Wrap":
                    newBoard = new WrapBoard(_board.BoardWidth, _board.BoardHeight);
                    break;
                case "Fixed":
                    newBoard = new EdgeBoard(_board.BoardWidth, _board.BoardHeight);
                    break;
                default:
                    newBoard = new WrapBoard(_board.BoardWidth, _board.BoardHeight);
                    break;
            }

            for (var cellRow = 0; cellRow < _board.BoardHeight; cellRow++)
            {
                for (var cellColumn = 0; cellColumn < _board.BoardWidth; cellColumn++)
                {
                    int[] cellIndex = { cellRow, cellColumn };
                    
                    var aliveNeighbours = _board.CountLiveNeighbours(cellIndex);
                    var alive = _board.CellArray[cellRow, cellColumn].alive;
                    var active = _board.CellArray[cellRow, cellColumn].active;

                    newBoard.CellArray[cellRow, cellColumn].UpdateCellStatus(aliveNeighbours, alive, active);
                }
            }

            _iteration++;
            _board = newBoard;
        }

        private void Print()
        {
            // Delay to better visualise the board
            Thread.Sleep(1000);
            ConsoleIO.PrintGameBoard(_board, _iteration);
        }

        public Game(InputData inputData)
        {
            boardType = inputData.boardType;
            
            if (boardType == "Wrap")
            {
                _board = new WrapBoard(inputData);
            } 
            else if (boardType == "Fixed")
            {
                _board = new EdgeBoard(inputData);
            }
            else
            {
                _board = new WrapBoard(inputData);
                Console.WriteLine("Error in input board type. Wrap board used as default.");
            }
        }
    }
}