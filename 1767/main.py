def find_intersection_length(x1, y1, x2, y2, x3, y3, x4, y4):
    # Находим пересечение по вертикали (по оси X)
    vertical_intersection = 0
    if max(x1, x2) >= min(x3, x4) and min(x1, x2) <= max(x3, x4):
        vertical_intersection = min(x2, x4) - max(x1, x3)

    # Находим пересечение по горизонтали (по оси Y)
    horizontal_intersection = 0
    if max(y1, y2) >= min(y3, y4) and min(y1, y2) <= max(y3, y4):
        horizontal_intersection = min(y2, y4) - max(y1, y3)

    # Возвращаем сумму пересечений по обеим осям
    return vertical_intersection + horizontal_intersection

# Ввод данных
x1, y1 = map(int, input().split())  # координаты дома доктора Ди
x2, y2 = map(int, input().split())  # координаты Собора Святого Павла
x3, y3 = map(int, input().split())  # координаты Национальной галереи
x4, y4 = map(int, input().split())  # координаты Британского музея

# Находим максимальную длину общей части траекторий
result = find_intersection_length(x1, y1, x2, y2, x3, y3, x4, y4)

# Вывод результата
print(result)
