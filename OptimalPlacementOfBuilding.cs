using System;
using System.Collections.Generic;
using System.Text;

namespace BackTracking
{
    public class OptimalPlacementOfBuilding
    {
        /*
         * T.C: O(H*M P n) it is H * M with probability of n
         * S.C: (H*M)
         */
        int H;
        int W;
        int n;
        int[,] direction;
        int MinDistance;
        public OptimalPlacementOfBuilding(int H, int W, int n)
        {
            this.H = H;
            this.W = W;
            this.n = n;
        }

        public int computeDistance()
        {
            int[,] grid = new int[H, W];

           for(int i = 0; i < H; i++)
            {
                for(int j = 0; j < W; j++)
                {
                    grid[i, j] = -1;
                }
            }

            MinDistance = 0;
            direction = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            BackTracking(grid, 0, 0, n);
            return MinDistance;
        }
        /*
         *  for(int i= 0; i < direction.GetLength(0); i++)
            {
                int nr = direction[i, 0] + r;
                int nc = direction[i, 1] + c;

                if (nr >= 0 && nc >= 0 && nr < H && nc < W && grid[nr, nc] )
            }
         */

        private void bfs(int[,] grid)
        {
            bool[,] visitied = new bool[H, W];

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if(grid[i, j] == 0)
                    {
                        queue.Enqueue(new int[] { i, j });
                        visitied[i, j] = true;
                    }
                }
            }

            int distance = 0;
            while (queue.Count != 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int[] curr = queue.Dequeue();
                   
                    for (int j = 0; j < direction.GetLength(0); j++)
                    {
                        int nr = direction[j, 0] + curr[0];
                        int nc = direction[j, 1] + curr[1];

                        if (nr >= 0 && nc >= 0 && nr < H && nc < W && grid[nr, nc] == -1 && visitied[nr,nc] ==false)
                        {
                            queue.Enqueue(new int[] { nr, nc });
                            visitied[nr, nc] = true;
                        }
                    }
                }
                distance++;
            }

            MinDistance = Math.Min(MinDistance, distance - 1);
        }

        private void BackTracking(int[,] grid, int r, int c, int n)
        {
            //base
            if (n == 0)
            {
                bfs(grid);
                return;
            }

            //logic
            if(c == W)
            {
                r++;
                c = 0;
            }
            for(int i =r; i< H; i++)
            {
                for(int j = c; j < W; j++)
                {
                    grid[i,j] = 0;

                    BackTracking(grid, i, j + 1, n - 1);

                    grid[i, j] = -1;
                } 
            }
            
           
        }
    }
}
