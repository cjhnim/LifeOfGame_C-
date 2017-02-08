using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOfGame.Library
{
    public class LifeGrid
    {
        public CellState[,] currentState;
        private CellState[,] nextState;
        private int gridHeight;
        private int gridWidth;

        public LifeGrid()
        {

        }

        public LifeGrid(int height, int width)
        {
            gridHeight = height;
            gridWidth = width;
            currentState = new CellState[gridHeight, gridWidth];
            nextState = new CellState[gridHeight, gridWidth];

            for (int i = 0; i < gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    currentState[i, j] = CellState.Dead;
                }
        }

        public void UpdateState()
        {
            for(int i=0; i<gridHeight; i++)
                for(int j=0; j<gridWidth; j++)
                {
                    var liveNeighbors = GetLiveNeighbors(i, j);
                    nextState[i, j] = LifeRules.GetNewState(currentState[i, j], liveNeighbors);
                }

            currentState = nextState;
            nextState = new CellState[gridHeight, gridWidth];    // Todo: C#의 메모리 해제 매커니즘은?
        }

        private int GetLiveNeighbors(int positionX, int positionY)
        {
            int liveNeighbors = 0;
            for(int i=-1; i<=1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j==0)
                        continue;

                    int neighborX = positionX + i;
                    int neighborY = positionY + j;

                    if (neighborX >= 0 && neighborX <gridHeight &&
                        neighborY >= 0 && neighborY <gridWidth)
                    {
                        if(currentState[neighborX,neighborY] == CellState.Alive)
                            liveNeighbors++;
                    }
                }

            return liveNeighbors;
        }


        public void Randomize()
        {
            Random random = new Random();

            for (int i = 0; i < gridHeight; i++)
                for(int j=0; j<gridWidth; j++)
                {
                    var next = random.Next(2);
                    var newState = next < 1 ? CellState.Dead : CellState.Alive;
                    currentState[i, j] = newState;
                }
        }
    }
}
