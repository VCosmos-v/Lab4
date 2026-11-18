

internal class Program
{
    public static void Main(string[] args)
    {
        Program menu = new Program();
        menu.RunMenu();
    }

    private void PrintMenu()
    {
        Console.WriteLine("1. Одинаковые элементы списков");
        Console.WriteLine("2. Продолжение списка зеркально");
        Console.WriteLine("3. Посещения ТРЦ");
        Console.WriteLine("4. Подсчет разных русских букв в файле");
        Console.WriteLine("5. Соревнования по многоборью");
        Console.WriteLine("0. Выход");
    }

    private void RunMenu()
    {
        Validator validator = new Validator();
        int choice = -1;
        while (choice != 0)
        {
            PrintMenu();
            choice = validator.ReadIntInterval("Выберите пункт (0-5):", 0, 5);
            switch (choice)
            {
                case 1:
                    {
                        int n = 0, x = 0;
                        List<int> L1 = new List<int>();
                        List<int> L2 = new List<int>();
                        n = validator.ReadIntNatural("Введите размер первого списка(>0): ");
                        for (int i = 1; i <= n; i++)
                        {
                            x = validator.ReadInt("Введите число: ");
                            L1.Add(x);
                        }
                        n = validator.ReadIntNatural("Введите размер второго списка(>0): ");
                        for (int i = 1; i <= n; i++)
                        {
                            x = validator.ReadInt("Введите число: ");
                            L2.Add(x);
                        }
                        List<int> result = Tasks.SameElem(L1, L2);
                        Console.WriteLine("Общие элементы: " + string.Join(", ", result));
                        break;
                    }
                case 2:
                    {
                        int n = 0, x = 0;
                        n = validator.ReadIntNatural("Введите размер списка(>0): ");
                        LinkedList<int> list = new LinkedList<int>();
                        for (int i = 0; i < n; i++)
                        {
                            x = validator.ReadInt("Введите число: ");
                            list.AddLast(x);
                        }
                        Tasks.AppendList(list);
                        Console.Write("Результат: ");
                        foreach (int item in list)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                    }
                case 3:
                    {
                        int mallsCount = validator.ReadIntInterval("Введите количество ТРЦ в перечне(1-100):", 1, 100);
                        List<string> allMalls = new List<string>();
                        for (int i = 0; i < mallsCount; i++)
                        {
                            Console.WriteLine($"Введите название ТРЦ {i + 1}:");
                            string? mallName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(mallName))
                            {
                                allMalls.Add(mallName);
                            }
                        }

                        int studentsCount = validator.ReadIntInterval("Введите количество студентов в группе:", 1, 100);
                        List<HashSet<string>> studentVisits = new List<HashSet<string>>();

                        for (int i = 0; i < studentsCount; i++)
                        {
                            Console.WriteLine($"\nВведите названия ТРЦ, которые посетил студент {i + 1} (по одному на строку, пустая строка для завершения):");
                            HashSet<string> visitedMalls = new HashSet<string>();
                            while (true)
                            {
                                string? input = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(input))
                                {
                                    break;
                                }
                                if (allMalls.Contains(input))
                                {
                                    visitedMalls.Add(input);
                                }
                                else
                                {
                                    Console.WriteLine("Такого ТРЦ нет в общем списке.");
                                }
                            }
                            studentVisits.Add(visitedMalls);
                        }

                        Tasks.Malls(allMalls, studentVisits);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Введите текст на русском языке:");
                        string? text = Console.ReadLine();
                        if (text == null)
                        {
                            text = string.Empty;
                        }

                        int uniqueCount = Tasks.CountUniqueRussianLetters(text);
                        Console.WriteLine($"Количество уникальных русских букв: {uniqueCount}");
                        break;
                    }
                case 5:
                    {
                        int n = validator.ReadIntInterval("Введите N кол-во спортсменов(1-999):", 1, 999);

                        int m = validator.ReadIntNatural("Введите M число видов спорта(> 0):");

                        List<Tasks.Athlete> athletes = new List<Tasks.Athlete>();

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Введите данные спортсмена {i + 1}(Фамилия Имя Баллы):");

                            string? line = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                i--;
                            }

                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length < m + 2)
                            {
                                Console.WriteLine($"Ошибка в строке {i + 1}. Ожидается Фамилия, Имя и {m} баллов. Повторите ввод строки:");
                                i--;
                            }

                            string surname = parts[0];
                            string name = parts[1];
                            int[] scores = new int[m];
                            bool flag = true;

                            for (int j = 0; j < m; j++)
                            {
                                if (!int.TryParse(parts[2 + j], out scores[j]))
                                {
                                    flag = false;
                                    break;
                                }
                            }

                            if (!flag)
                            {
                                Console.WriteLine($"Ошибка в баллах спортсмена {i + 1}. Повторите ввод строки:");
                                i--;
                                continue;
                            }

                            athletes.Add(new Tasks.Athlete(surname, name, scores));
                        }

                        Tasks.Sorting(athletes);
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
