#include <iostream>
#include <vector>
#include <tuple>
#include <cmath>

using namespace std;

pair<int, int> find_balancing_line(const vector<pair<int, int>> &points)
{
    int n = points.size(); // Número de pontos
    for (int i = 0; i < n; ++i)
    { // Iterar sobre o primeiro ponto
        for (int j = i + 1; j < n; ++j)
        { // Iterar sobre o segundo ponto (evitando repetição)
            auto [x_a, y_a] = points[i];
            auto [x_b, y_b] = points[j];
            int left = 0, right = 0; // Contadores de pontos à esquerda e à direita

            for (int k = 0; k < n; ++k)
            { // Percorrer todos os outros pontos
                if (k == i || k == j)
                { // Ignorar os pontos usados para formar a reta
                    continue;
                }
                auto [x_k, y_k] = points[k];

                // Cálculo do lado usando produto vetorial
                int side = (x_b - x_a) * (y_k - y_a) - (y_b - y_a) * (x_k - x_a);

                if (side > 0)
                { // Ponto à esquerda da reta
                    left++;
                }
                else if (side < 0)
                { // Ponto à direita da reta
                    right++;
                }
            }

            // Se metade dos pontos está em cada lado, achamos a resposta
            if (left == right && left == (n / 2 - 1))
            {
                return {i + 1, j + 1}; // Retorna os índices dos pontos (1-based)
            }
        }
    }
    return {-1, -1}; // Caso não encontre uma solução
}

int main()
{
    int n;
    cin >> n; // Lê o número de pontos
    vector<pair<int, int>> points(n);

    for (int i = 0; i < n; ++i)
    {
        cin >> points[i].first >> points[i].second; // Lê as coordenadas
    }

    auto [i, j] = find_balancing_line(points);
    cout << i << " " << j << endl; // Imprime os índices dos pontos que formam a reta de equilíbrio
    return 0;
}
