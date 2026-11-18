using System.Runtime;

internal class Program
{
    public static void Main(string[] args)
    {
        Program menu = new Program();
        menu.RunMenu();
    }

    private void PrintMenu()
    {
        Console.WriteLine("1. Задание 6: Проверка пересечения отрезков");
        Console.WriteLine("2. Задание 7: Перегрузка операций");
        Console.WriteLine("0. Выход");
    }

    private void PrintMenu7()
    {
        Console.WriteLine("1. Унарные операции ! и ++");
        Console.WriteLine("2. Операции приведения типа");
        Console.WriteLine("3. Бинарные операции !");
        Console.WriteLine("0. Выход");
    }

    private void RunMenu()
    {
        Validator validator = new Validator();
        int choice = -1;
        while (choice != 0)
        {
            PrintMenu();
            choice = validator.ReadIntInterval("Выберите пункт (0-2):", 0, 2);
            switch (choice)
            {
                case 1:
                    {
                        double x1 = validator.ReadDouble("Введите начало первого отрезка (x1):");
                        double y1 = validator.ReadDouble("Введите конец первого отрезка (y1):");
                        LineSegment segment1 = new LineSegment(x1, y1);

                        double x2 = validator.ReadDouble("Введите начало второго отрезка (x2):");
                        double y2 = validator.ReadDouble("Введите конец второго отрезка (y2):");
                        LineSegment segment2 = new LineSegment(x2, y2);

                        Console.WriteLine($"Первый отрезок: {segment1}");
                        Console.WriteLine($"Второй отрезок: {segment2}");
                        bool isIntersected = segment1.Intersects(segment2);
                        Console.WriteLine($"Пересекаются ли отрезки: {isIntersected}");
                        break;
                    }
                case 2:
                    {
                        Task7();
                        break;
                    }
                case 0:
                    {
                        Console.WriteLine("Выход из программы.");
                        break;
                    }
            }
        }
    }
    private void Task7()
    {
        Validator validator = new Validator();
        int choice = -1;
        double x = validator.ReadDouble("Введите координату x для отрезка:");
        double y = validator.ReadDouble("Введите координату y для отрезка:");
        LineSegment line = new LineSegment(x, y);
        while (choice != 0)
        {
            Console.WriteLine($"\nСозданный отрезок: {line}");
            PrintMenu7();
            choice = validator.ReadIntInterval("Выберите пункт (0-3):", 0, 3);
            switch (choice)
            {
                case 1:
                    {
                        double length = !line;
                        Console.WriteLine($"Длина диапазона (!): {length}");

                        line++;
                        Console.WriteLine($"После расширения на 1 вправо и влево (++): {line}");
                        break;
                    }
                case 2:
                    {

                        int intX = line;
                        Console.WriteLine($"Неявное приведение к int (целая часть x): {intX}");

                        double doubleY = (double)line;
                        Console.WriteLine($"Явное приведение к double (координата y): {doubleY}");
                        break;
                    }
                case 3:
                    {
                        int Val1 = validator.ReadInt("Введите целое число для уменьшения координаты x (segment - val):");
                        LineSegment segment1 = line - Val1;
                        Console.WriteLine($"Результат: {segment1}");

                        int Val2 = validator.ReadInt("Введите целое число для уменьшения координаты y (val - segment):");
                        LineSegment segment2 = Val2 - line;
                        Console.WriteLine($"Результат: {segment2}");

                        Console.WriteLine("\nВведите второй отрезок для проверки операции пересечения (<):");
                        double otherX = validator.ReadDouble("Введите x второго отрезка:");
                        double otherY = validator.ReadDouble("Введите y второго отрезка:");
                        LineSegment otherSegment = new LineSegment(otherX, otherY);

                        bool intersectsOp = line < otherSegment;
                        Console.WriteLine($"Результат проверки операции (line1 < line2): {intersectsOp}");
                        break;
                    }
                case 0:
                    {
                        Console.WriteLine("Выход из программы.");
                        break;
                    }
            }
        }
    }
}