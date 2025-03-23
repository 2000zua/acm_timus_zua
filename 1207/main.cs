using System;
using System.Collections.Generic;

class Program
{
    static Tuple<int, int> FindBalancingLine(List<Tuple<int, int>> points)
    {
        int n = points.Count;  // Número de pontos
        for (int i = 0; i < n; i++)
        {  // Iterar sobre o primeiro ponto
            for (int j = i + 1; j < n; j++)
            {  // Iterar sobre o segundo ponto (evitando repetição)
                var a = points[i];
                var b = points[j];
                int left = 0, right = 0;  // Contadores de pontos à esquerda e à direita

                for (int k = 0; k < n; k++)
                {  // Percorrer todos os outros pontos
                    if (k == i || k == j)
                    {  // Ignorar os pontos usados para formar a reta
                        continue;
                    }
                    var c = points[k];

                    // Cálculo do lado usando produto vetorial
                    int side = (b.Item1 - a.Item1) * (c.Item2 - a.Item2) - (b.Item2 - a.Item2) * (c.Item1 - a.Item1);

                    if (side > 0)
                    {  // Ponto à esquerda da reta
                        left++;
                    }
                    else if (side < 0)
                    {  // Ponto à direita da reta
                        right++;
                    }
                }

                // Se metade dos pontos está em cada lado, achamos a resposta
                if (left == right && left == (n / 2 - 1))
                {
                    return Tuple.Create(i + 1, j + 1);  // Retorna os índices dos pontos (1-based)
                }
            }
        }
        return Tuple.Create(-1, -1);  // Caso não encontre uma solução
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());  // Lê o número de pontos
        var points = new List<Tuple<int, int>>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            points.Add(Tuple.Create(x, y));  // Lê as coordenadas
        }

        var result = FindBalancingLine(points);
        Console.WriteLine($"{result.Item1} {result.Item2}");  // Imprime os índices dos pontos que formam a reta de equilíbrio
    }
}
