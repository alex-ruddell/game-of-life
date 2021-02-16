
// COMPLETE. Holds edge board related functionality

namespace GoL_kata
{
    public class EdgeBoard : Board
    {
        public bool CellExists(int[] cellIndex)
        {
            int row = cellIndex[0];
            int column = cellIndex[1];
            
            if (row == BoardHeight || row == -1 || column == BoardWidth || column == -1)
            {
                return false;
            }

            return true;
        }
        
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
                    
                    if (CellExists(testingCellIndex))
                    {
                        Cell testingCell = CellArray[i, j];
                        if (!Equals(currentCell, testingCell) && testingCell.alive)
                        {
                            aliveCount++;
                        }
                    }
                }
            }

            return aliveCount;
        }

        public sealed override void InitialiseCellArray()
        {
            CellArray = new Cell[BoardHeight, BoardWidth];
            
            for (int row = 0; row < BoardHeight; row++)
            {
                for (int column = 0; column < BoardWidth; column++)
                {
                    // If it is an overflow cell, "not active"
                    var active = !(row < NumOverflow || column < NumOverflow || row >= BoardHeight - NumOverflow ||
                                   column >= BoardWidth - NumOverflow);

                    CellArray[row, column] = new Cell(row, column, false, active);
                }
            }
        }

        // CONSTRUCTORS
        public EdgeBoard(int width, int height)
        {
            BoardHeight = height;
            BoardWidth = width;
            
            InitialiseCellArray();
        }
        
        public EdgeBoard(InputData input)
        {
            NumOverflow = 10;

            BoardHeight = input.boardHeight + (NumOverflow * 2);
            BoardWidth = input.boardWidth + (NumOverflow * 2);
            SeedHeight = input.seedHeight;
            SeedWidth = input.seedWidth;
            SeedString = input.seedString;

            InitialiseCellArray();
            PlantSeed();
        }
    }
}