using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    class Board
    {
        HashSet<Cell> alive;

        public Board(string board = "")
        {
            this.alive = new HashSet<Cell>();
            Read(board);
        }

        // Read the string to initialize the board 
        private void Read(string board)
        {
            int y = 0;
            foreach (var line in board.Split('\n'))
            {
                y++;
                int x = 0;
                foreach (var c in line)
                {
                    x++;
                    if (c == 'X')
                    {
                        this.alive.Add(new Cell(x, y));
                    }
                }
            }
        }

        // Return true if the cell is alive
        public bool IsAlive(Cell cell)
        {
            return this.alive.Contains(cell);
        }

        // Add a cell to the internal hashmap that represents the board
        public void AddCell(int x, int y)
        {
            this.alive.Add(new Cell(x, y));
        }

        // Return a disctionary that for each cell (that has neighbors) tells us how many neighbors it has.
        private Dictionary<Cell, int> NeighborsCount()
        {
            var counts = new Dictionary<Cell, int>();

            foreach (Cell cell in this.alive)
            {
                foreach (Cell neighbor in cell.Neighbors())
                {
                    if (counts.ContainsKey(neighbor))
                    {
                        var value = counts[neighbor];
                        value++;
                        counts[neighbor] = value;
                    }
                    else
                    {
                        counts.Add(neighbor, 1);
                    }
                }
            }

            return counts;
        }

        // Advance the board
        public void Step()
        {
            var newAlive = new HashSet<Cell>();

            foreach (var entry in this.NeighborsCount())
            {
                if (entry.Value == 3 || this.IsAlive(entry.Key) && entry.Value == 2)
                {
                    newAlive.Add(entry.Key);
                }
            }

            this.alive = newAlive;
        }

        // Rerturn a string representation of the board
        public override string ToString()
        {
            const int padding = 0;

            var minx = Int32.MaxValue;
            var miny = Int32.MaxValue;
            var maxx = Int32.MinValue;
            var maxy = Int32.MinValue;

            foreach (Cell cell in this.alive)
            {
                minx = Math.Min(cell.x, minx);
                miny = Math.Min(cell.y, miny);
                maxx = Math.Max(cell.x, maxx);
                maxy = Math.Max(cell.y, maxy);
            }

            var board = new StringBuilder();

            for (int y = miny - padding; y < maxy + 1 + padding; y++)
            {
                for (int x = minx - padding; x < maxx + 1 + padding; x++)
                {
                    if (this.alive.Contains(new Cell(x, y)))
                    {
                        board.Append("X");
                    }
                    else
                    {
                        board.Append(".");
                    }
                }
                board.Append("\n");
            }

            return board.ToString();
        }
    }
}
