
// COMPLETE. Holds cell functionality.

namespace GoL_kata
{
    public class Cell
    {
        public int row;
        public int column;
        public bool alive;
        public bool active; // Not an edge cell
        
        public void UpdateCellStatus(int aliveNeighbours, bool alive, bool active)
        {
            this.active = active;
            
            if (alive)
            {
                if (aliveNeighbours < 2 || aliveNeighbours > 3)
                {
                    this.alive = false;
                }
                else
                {
                    this.alive = true;
                }
            }
            else
            {
                if (aliveNeighbours == 3)
                {
                    this.alive = true;
                }
            }
        }

        public Cell(int row, int column, bool alive, bool active)
        {
            this.row = row;
            this.column = column;
            this.alive = alive;
            this.active = active;
        }
    }
}