using System;

class Program
{
    static int FindIntersectionLength(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        // Находим пересечение по вертикали (по оси X)
        int verticalIntersection = 0;
        if (Math.Max(x1, x2) >= Math.Min(x3, x4) && Math.Min(x1, x2) <= Math.Max(x3, x4))
        {
            verticalIntersection = Math.Min(x2, x4) - Math.Max(x1, x3);
        }

        // Находим пересечение по горизонтали (по оси Y)
        int horizontalIntersection = 0;
        if (Math.Max(y1, y2) >= Math.Min(y3, y4) && Math.Min(y1, y2) <= Math.Max(y3, y4))
        {
            horizontalIntersection = Math.Min(y2, y4) - Math.Max(y1, y3);
        }

        // Возвращаем сумму пересечений по обеим осям
        return verticalIntersection + horizontalIntersection;
    }

    static void Main()
    {
        // Ввод данных
        string[] input1 = Console.ReadLine().Split();
        string[] input2 = Console.ReadLine().Split();
        string[] input3 = Console.ReadLine().Split();
        string[] input4 = Console.ReadLine().Split();

        // Преобразуем в целые числа
        int x1 = int.Parse(input1[0]), y1 = int.Parse(input1[1]);
        int x2 = int.Parse(input2[0]), y2 = int.Parse(input2[1]);
        int x3 = int.Parse(input3[0]), y3 = int.Parse(input3[1]);
        int x4 = int.Parse(input4[0]), y4 = int.Parse(input4[1]);

        // Находим максимальную длину общей части траекторий
        int result = FindIntersectionLength(x1, y1, x2, y2, x3, y3, x4, y4);

        // Вывод результата
        Console.WriteLine(result);
    }
}
