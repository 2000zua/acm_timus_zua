MOD = 10**9

def in_bounds(x, y, n, m):
    return 0 <= x < n and 0 <= y < m

def dfs(x, y, grid, visited, n, m):
    visited[x][y] = True
    directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]
    for dx, dy in directions:
        nx, ny = x + dx, y + dy
        if in_bounds(nx, ny, n, m) and not visited[nx][ny] and grid[nx][ny] == '.':
            dfs(nx, ny, grid, visited, n, m)

def count_spanning_trees(n, m, grid):
    visited = [[False] * m for _ in range(n)]
    components = 0
    
    for i in range(n):
        for j in range(m):
            if grid[i][j] == '.' and not visited[i][j]:
                dfs(i, j, grid, visited, n, m)
                components += 1

    return components

n, m = map(int, input().split())
grid = [input().strip() for _ in range(n)]

components = count_spanning_trees(n, m, grid)
if components == 1:
    print(1)
else:
    print(0)
