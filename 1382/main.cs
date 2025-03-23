using System;
using System.Collections.Generic;

class Program
{
    static int[] Solve(int N, List<Tuple<int, int, int>> data)
    {
        // Mapeamento para o resultado
        int[] result = new int[N];

        // Testar todas as combinações de veracidade das afirmações
        for (int mask = 0; mask < (1 << N); ++mask)
        {
            // Inicializamos o vetor de cartões
            int[] cards = new int[N];
            for (int i = 0; i < N; i++) cards[i] = -1;
            bool valid = true;

            // Verificar se as afirmações podem ser verdadeiras
            for (int i = 0; i < N; ++i)
            {
                var (a, b, c) = data[i];
                b -= 1;  // Corrigindo o índice para ser 0-based

                if ((mask >> i) & 1)
                {
                    // Se a primeira afirmação é verdadeira para o amigo i
                    if (cards[i] != -1 && cards[i] != a)
                    {
                        valid = false;
                        break;
                    }
                    cards[i] = a;
                    if (b != i)
                    {
                        if (cards[b] != -1 && cards[b] != c)
                        {
                            valid = false;
                            break;
                        }
                        cards[b] = c;
                    }
                }
                else
                {
                    // Se a segunda afirmação é verdadeira para o amigo i
                    if (cards[i] != -1 && cards[i] != c)
                    {
                        valid = false;
                        break;
                    }
                    cards[i] = c;
                    if (b != i)
                    {
                        if (cards[b] != -1 && cards[b] != a)
                        {
                            valid = false;
                            break;
                        }
                        cards[b] = a;
                    }
                }
            }

            if (valid)
            {
                // Se for válido, registra o resultado
                for (int i = 0; i < N; ++i)
                {
                    var (a, b, c) = data[i];
                    if ((mask >> i) & 1)
                    {
                        result[i] = 1;
                    }
                    else
                    {
                        result[i] = 2;
                    }
                }
                break;
            }
        }

        return result;
    }

    static void Main()
    {
        int N = 5;
        var data = new List<Tuple<int, int, int>>()
        {
            Tuple.Create(3, 4, 3),
            Tuple.Create(1, 3, 2),
            Tuple.Create(3, 2, 5),
            Tuple.Create(2, 5, 4),
            Tuple.Create(3, 4, 1)
        };

        var result = Solve(N, data);

        Console.WriteLine(string.Join(" ", result));
    }
}
