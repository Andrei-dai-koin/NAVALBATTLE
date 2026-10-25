using System;

class Program
{
    static void Main()
    {
        const int Size = 5;
        Random rnd = new Random();

        int shipRow = rnd.Next(Size);
        int shipCol = rnd.Next(Size);

        Console.WriteLine("=== МОРСКОЙ БОЙ 5x5 ===");
        Console.WriteLine("В море спрятан однопалубный корабль.");
        Console.WriteLine("Стреляйте, указывая координаты (строка и столбец от 0 до 4).");
        Console.WriteLine("Победа — попадание в корабль.\n");

        int shots = 0;

        while (true)
        {
            DrawBoard(Size);

            int row, col;
            if (!TryReadCoordinates(Size, out row, out col))
                continue;

            shots++;

            if (row == shipRow && col == shipCol)
            {
                Console.WriteLine($"\nПОПАДАНИЕ! Корабль потоплен за {shots} выстрел(ов).");
                break;
            }
            else
            {
                Console.WriteLine("\nМимо. Попробуйте ещё раз.\n");
            }
        }

        Console.WriteLine("Игра окончена.");
    }

    static void DrawBoard(int size)
    {
        Console.Write("   ");
        for (int c = 0; c < size; c++)
            Console.Write(c + " ");
        Console.WriteLine();

        for (int r = 0; r < size; r++)
        {
            Console.Write(r + "  ");
            for (int c = 0; c < size; c++)
                Console.Write(". ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static bool TryReadCoordinates(int size, out int row, out int col)
    {
        row = col = -1;

        Console.Write("Строка: ");
        string rowInput = Console.ReadLine();
        if (!int.TryParse(rowInput, out row) || row < 0 || row >= size)
        {
            Console.WriteLine("Некорректная строка. Введите число от 0 до " + (size - 1) + ".\n");
            return false;
        }

        Console.Write("Столбец: ");
        string colInput = Console.ReadLine();
        if (!int.TryParse(colInput, out col) || col < 0 || col >= size)
        {
            Console.WriteLine("Некорректный столбец. Введите число от 0 до " + (size - 1) + ".\n");
            return false;
        }

        return true;
    }
}