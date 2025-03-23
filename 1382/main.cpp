#include <iostream>
#include <vector>
using namespace std;

vector<int> solve(int N, vector<tuple<int, int, int>> data) {
    // Mapeamento para o resultado
    vector<int> result(N, 0);
    
    // Testar todas as combinações de veracidade das afirmações
    for (int mask = 0; mask < (1 << N); ++mask) {
        // Inicializamos o vetor de cartões
        vector<int> cards(N, -1);
        bool valid = true;

        // Verificar se as afirmações podem ser verdadeiras
        for (int i = 0; i < N; ++i) {
            int a, b, c;
            tie(a, b, c) = data[i];
            b -= 1;  // Corrigindo o índice para ser 0-based

            if ((mask >> i) & 1) {
                // Se a primeira afirmação é verdadeira para o amigo i
                if (cards[i] != -1 && cards[i] != a) {
                    valid = false;
                    break;
                }
                cards[i] = a;
                if (b != i) {
                    if (cards[b] != -1 && cards[b] != c) {
                        valid = false;
                        break;
                    }
                    cards[b] = c;
                }
            } else {
                // Se a segunda afirmação é verdadeira para o amigo i
                if (cards[i] != -1 && cards[i] != c) {
                    valid = false;
                    break;
                }
                cards[i] = c;
                if (b != i) {
                    if (cards[b] != -1 && cards[b] != a) {
                        valid = false;
                        break;
                    }
                    cards[b] = a;
                }
            }
        }

        if (valid) {
            // Se for válido, registra o resultado
            for (int i = 0; i < N; ++i) {
                int a, b, c;
                tie(a, b, c) = data[i];
                if ((mask >> i) & 1) {
                    result[i] = 1;
                } else {
                    result[i] = 2;
                }
            }
            break;
        }
    }

    return result;
}

int main() {
    int N = 5;
    vector<tuple<int, int, int>> data = {
        {3, 4, 3},
        {1, 3, 2},
        {3, 2, 5},
        {2, 5, 4},
        {3, 4, 1}
    };

    vector<int> result = solve(N, data);

    for (int i : result) {
        cout << i << " ";
    }
    cout << endl;

    return 0;
}
