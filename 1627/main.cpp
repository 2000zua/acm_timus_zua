#include <iostream>
#include <vector>
#include <stack>
using namespace std;

const int MOD = 1e9;

struct Cell
{
    int x, y;
};

int n, m;
vector<vector<char>> grid;
vector<vector<bool>> visited;
vector<Cell> bedrooms;

int dx[] = {-1, 1, 0, 0}; // Directions for movement (up, down, left, right)
int dy[] = {0, 0, -1, 1};

// Check if a cell is within the grid and is a bedroom
bool inBounds(int x, int y)
{
    return x >= 0 && y >= 0 && x < n && y < m && grid[x][y] == '.';
}

// Depth-first search to connect the bedrooms
void dfs(int x, int y, vector<vector<bool>> &visited)
{
    visited[x][y] = true;
    for (int i = 0; i < 4; ++i)
    {
        int nx = x + dx[i];
        int ny = y + dy[i];
        if (inBounds(nx, ny) && !visited[nx][ny])
        {
            dfs(nx, ny, visited);
        }
    }
}

// Count the number of connected components (spanning trees)
int countSpanningTrees()
{
    visited.assign(n, vector<bool>(m, false));
    int components = 0;

    for (auto &bedroom : bedrooms)
    {
        int x = bedroom.x, y = bedroom.y;
        if (!visited[x][y])
        {
            dfs(x, y, visited);
            ++components;
        }
    }

    return components;
}

int main()
{
    cin >> n >> m;
    grid.resize(n, vector<char>(m));

    for (int i = 0; i < n; ++i)
    {
        for (int j = 0; j < m; ++j)
        {
            cin >> grid[i][j];
            if (grid[i][j] == '.')
            {
                bedrooms.push_back({i, j});
            }
        }
    }

    int components = countSpanningTrees();
    if (components == 1)
    {
        cout << 1 << endl; // 1 way to connect all bedrooms (since it's already connected)
    }
    else
    {
        cout << 0 << endl; // No way to connect all bedrooms as one component
    }
    return 0;
}
