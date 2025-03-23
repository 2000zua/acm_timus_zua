using System;
using System.Collections.Generic;

class Program
{
    const int MOD = 1000000000;

    // Directions for moving in the grid (up, down, left, right)
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    // Check if the given coordinates are within bounds and if it's a bedroom ('.')
    static bool InBounds(int x, int y, int n, int m, char[,] grid)
    {
        return x >= 0 && y >= 0 && x < n && y < m && grid[x, y] == '.';
    }

    // Depth-First Search (DFS) to visit all connected bedrooms
    static void DFS(int x, int y, bool[,] visited, char[,] grid, int n, int m)
    {
        visited[x, y] = true;
        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            if (InBounds(nx, ny, n, m, grid) && !visited[nx, ny])
            {
                DFS(nx, ny, visited, grid, n, m);
            }
        }
    }

    // Count the number of connected components of bedrooms
    static int CountSpanningTrees(int n, int m, char[,] grid)
    {
        bool[,] visited = new bool[n, m];
        int components = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i, j] == '.' && !visited[i, j])
                {
                    DFS(i, j, visited, grid, n, m);
                    components++;
                }
            }
        }

        return components;
    }

    static void Main()
    {
        // Read the size of the grid
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        // Read the grid
        char[,] grid = new char[n, m];
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < m; j++)
            {
                grid[i, j] = line[j];
            }
        }

        // Count the connected components of bedrooms
        int components = CountSpanningTrees(n, m, grid);

        // If there's exactly one connected component of bedrooms, print 1, otherwise print 0
        if (components == 1)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
