using System;
using System.Collections.Generic;

class Program
{
    static string CanBlockRoutes(int K, int N, int M, int S, int F, List<int> policeNeeded, List<Tuple<int, int>> edges)
    {
        // Criar a lista de adjacência
        var graph = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge.Item1)) graph[edge.Item1] = new List<int>();
            if (!graph.ContainsKey(edge.Item2)) graph[edge.Item2] = new List<int>();
            graph[edge.Item1].Add(edge.Item2);
            graph[edge.Item2].Add(edge.Item1);
        }

        // Encontrar os nós que pertencem a todos os caminhos entre S e F
        Dictionary<int, int> Bfs(int start, HashSet<int> avoid)
        {
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            var parents = new Dictionary<int, int>();
            queue.Enqueue(start);
            visited.Add(start);
            parents[start] = -1;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbor in graph[node])
                {
                    if (!visited.Contains(neighbor) && !avoid.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                        parents[neighbor] = node;
                        if (neighbor == S)
                        {
                            return parents;
                        }
                    }
                }
            }
            return new Dictionary<int, int>();
        }

        // Executar BFS a partir do refúgio dos ladrões
        var avoidSet = new HashSet<int> { S, F };
        var pathNodes = new HashSet<int>();

        var parents = Bfs(F, avoidSet);
        if (parents.Count == 0)
        {
            return "NO";
        }

        // Reconstruir caminho de F para S
        var node = S;
        while (node != -1)
        {
            pathNodes.Add(node);
            node = parents[node];
        }

        // Remover S e F, pois não podem ser bloqueados
        pathNodes.Remove(S);
        pathNodes.Remove(F);

        // Verificar se temos policiais suficientes
        int totalPoliceNeeded = 0;
        foreach (var pathNode in pathNodes)
        {
            totalPoliceNeeded += policeNeeded[pathNode - 1];
        }

        return totalPoliceNeeded <= K ? "YES" : "NO";
    }

    static void Main()
    {
        int K, N, M, S, F;
        var inputs = Console.ReadLine().Split();
        K = int.Parse(inputs[0]);
        N = int.Parse(inputs[1]);
        M = int.Parse(inputs[2]);
        S = int.Parse(inputs[3]);
        F = int.Parse(inputs[4]);

        var policeNeeded = new List<int>();
        var policeInputs = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            policeNeeded.Add(int.Parse(policeInputs[i]));
        }

        var edges = new List<Tuple<int, int>>();
        for (int i = 0; i < M; i++)
        {
            var edgeInputs = Console.ReadLine().Split();
            edges.Add(Tuple.Create(int.Parse(edgeInputs[0]), int.Parse(edgeInputs[1])));
        }

        string result = CanBlockRoutes(K, N, M, S, F, policeNeeded, edges);
        Console.WriteLine(result);
    }
}
