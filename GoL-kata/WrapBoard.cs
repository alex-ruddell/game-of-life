
// COMPLETE. Holds wrap board related functionality

namespace GoL_kata
{
    public class WrapBoard : Board
    {
        public override int CountLiveNeighbours(int[] cellIndex)
        {
            int currentRow = cellIndex[0];
            int currentColumn = cellIndex[1];
            
            Cell currentCell = CellArray[currentRow, currentColumn];
            int aliveCount = 0;

            for (int i = currentCell.row - 1; i <= currentCell.row + 1; i++)
            {
                for (int j = currentCell.column - 1; j <= currentCell.column + 1; j++)
                {
                    int[] testingCellIndex = {i, j};
                    
                    testingCellIndex = ValidateCellRange(testingCellIndex);
                    int valRow = testingCellIndex[0];
                    int valCol = testingCellIndex[1];

                    if (!Equals(currentCell, CellArray[valRow, valCol]) && CellArray[valRow, valCol].alive)
                    {
                        aliveCount++;
                    }
                }
            }

            return aliveCount;
        }
        
        public override void InitialiseCellArray()
        {
            CellArray = new Cell[BoardHeight, BoardWidth];
            
            for (int row = 0; row < BoardHeight; row++)
            {
                for (int column = 0; column < BoardWidth; column++)
                {
                    CellArray[row, column] = new Cell(row, column, false, true);
                }
            }
        }

        private int[] ValidateCellRange(int[] indices)
        {
            int row = indices[0];
            int column = indices[1];

            if (row == BoardHeight)
            {
                indices[0] = 0;
            }

            if (row == -1)
            {
                indices[0] = BoardHeight - 1;
            }

            if (column == BoardWidth)
            {
                indices[1] = 0;
            }

            if (column == -1)
            {
                indices[1] = BoardWidth - 1;
            }

            return indices;
        }
        
        // CONSTRUCTORS
        public WrapBoard(int width, int height)
        {
            BoardHeight = height;
            BoardWidth = width;
            
            InitialiseCellArray();
        }
        
        public WrapBoard(InputData input)
        {
            BoardHeight = input.boardHeight;
            BoardWidth = input.boardWidth;
            SeedHeight = input.seedHeight;
            SeedWidth = input.seedWidth;
            SeedString = input.seedString;

            InitialiseCellArray();
            PlantSeed();
        }
    }
}