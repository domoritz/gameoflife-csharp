using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            var board = new Board("......X.\nXX......\n.X...XXX");
            //var board = new Board("..X\nX.X\n.XX");

            Console.WriteLine("Start:");
            Console.WriteLine(board);
            board.Step();

            Console.WriteLine("Next:");
            Console.WriteLine(board);
            board.Step();

            Console.WriteLine("Next:");
            Console.WriteLine(board);
        }
    }
}
