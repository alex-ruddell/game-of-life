
// COMPLETE. Forces all functionality a board should contain.

namespace GoL_kata
{
    public abstract class Board
    {
        public int BoardHeight;
        public int BoardWidth;
        public int SeedHeight;
        public int SeedWidth;
        public string[] SeedString;
        public int NumOverflow;
        public Cell[,] CellArray;
        
        public abstract int CountLiveNeighbours(int[] cellIndex);

        public abstract void InitialiseCellArray();

        public bool NoLiveCells()
        {
            int count = 0;
            
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    if (CellArray[i, j].alive && CellArray[i, j].active)
                    {
                        count++;
                    }
                }
            }
            
            if (count == 0)
            {
                return true;
            }

            return false;
        }
        
        protected void PlantSeed()
        {
            int midHeight = BoardHeight / 2;
            int midWidth = BoardWidth / 2;

            int seedStartRow = midHeight - SeedHeight / 2;
            int seedStartColumn = midWidth - SeedWidth / 2;

            for (int i = 0; i < SeedHeight; i++)
            {
                for (int j = 0; j < SeedWidth; j++)
                {
                    if (SeedString[i][j] == 'X')
                    {
                        CellArray[seedStartRow + i, seedStartColumn + j].alive = true;
                    }
                }
            }
        }
    }
}