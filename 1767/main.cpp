#include <iostream>
#include <algorithm>
using namespace std;

int findIntersectionLength(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
{
    // Находим пересечение по вертикали (по оси X)
    int verticalIntersection = 0;
    if (max(x1, x2) >= min(x3, x4) && min(x1, x2) <= max(x3, x4))
    {
        verticalIntersection = min(x2, x4) - max(x1, x3);
    }

    // Находим пересечение по горизонтали (по оси Y)
    int horizontalIntersection = 0;
    if (max(y1, y2) >= min(y3, y4) && min(y1, y2) <= max(y3, y4))
    {
        horizontalIntersection = min(y2, y4) - max(y1, y3);
    }

    // Возвращаем сумму пересечений по обеим осям
    return verticalIntersection + horizontalIntersection;
}

int main()
{
    // Ввод данных
    int x1, y1, x2, y2, x3, y3, x4, y4;
    cin >> x1 >> y1;
    cin >> x2 >> y2;
    cin >> x3 >> y3;
    cin >> x4 >> y4;

    // Находим максимальную длину общей части траекторий
    int result = findIntersectionLength(x1, y1, x2, y2, x3, y3, x4, y4);

    // Вывод результата
    cout << result << endl;

    return 0;
}
