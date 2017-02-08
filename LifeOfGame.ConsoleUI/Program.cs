using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LifeOfGame.Library;
namespace LifeOfGame.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new LifeGrid(25,100);
            //grid.currentState[1, 2] = CellState.Alive;
            //grid.currentState[2, 2] = CellState.Alive;
            //grid.currentState[3, 2] = CellState.Alive;

            grid.Randomize();

            ShowGrid(grid.currentState);

            while(Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.currentState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = currentState.GetUpperBound(1)+1;

            var output = new StringBuilder();

            foreach(var state in currentState)
            {
                output.Append(state == CellState.Alive ? '0' : '.');
                x++;
                if (x >= rowLength)
                { 
                    x = 0;
                    output.AppendLine();
                }
            }

            Console.Write(output.ToString());
        }

    }
}
