using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell : System.Object
    {
        public int x { get; }
        public int y { get; }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Return a list list of all neighbors of this cell
        public List<Cell> Neighbors()
        {
            var neighbors = new List<Cell>();
            for (int x = this.x - 1; x < this.x + 2; x++)
            {
                for (int y = this.y - 1; y < this.y + 2; y++)
                {
                    if (x != this.x || y != this.y)
                    {
                        neighbors.Add(new Cell(x, y));
                    }
                }
            }
            return neighbors;
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Cell other = obj as Cell;
            if ((System.Object)other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (x == other.x) && (y == other.y);
        }

        public bool Equals(Cell other)
        {
            if (other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (x == other.x) && (y == other.y);
        }

        public override string ToString()
        {
            return "Cell(" + x + "," + y + ")";
        }
    }

}