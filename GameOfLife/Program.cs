using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board("......X.\nXX......\n.X...XXX");

            for (int i = 0; i < 130; i++)
            {
                board.Step();
                Console.Clear();
                Console.Write(board);
                Thread.Sleep(100);
            }
        }
    }
}
