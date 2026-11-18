internal class Tasks
{
    public static List<int> SameElem(List<int> L1, List<int> L2)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < L1.Count; i++)
        {
            int value = L1[i];
            if (L2.Contains(value) && !result.Contains(value))
            {
                result.Add(value);
            }
        }
        return result;
    }

    public static void AppendList(LinkedList<int> list)
    {
        if (list.First == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        List<int> temp = new List<int>();
        LinkedListNode<int>? current = list.First;
        while (current != null)
        {
            temp.Add(current.Value);
            current = current.Next;
        }

        for (int i = temp.Count - 1; i >= 0; i--)
        {
            list.AddLast(temp[i]);
        }
    }

    public static void Malls(List<string> allMalls, List<HashSet<string>> studentVisits)
    {
        if (studentVisits.Count == 0)
        {
            return;
        }

        HashSet<string> visitedAll = new HashSet<string>(allMalls);
        HashSet<string> visitedSome = new HashSet<string>();
        HashSet<string> visitedNone = new HashSet<string>(allMalls);

        for (int i = 0; i < studentVisits.Count; i++)
        {
            visitedAll.IntersectWith(studentVisits[i]);
            visitedSome.UnionWith(studentVisits[i]);
            visitedNone.ExceptWith(studentVisits[i]);
        }

        Console.WriteLine("Посетили все студенты:");
        foreach (string mall in visitedAll)
        {
            Console.WriteLine($"{mall}");
        }

        Console.WriteLine("Посетили некоторые студенты (хотя бы один):");
        foreach (string mall in visitedSome)
        {
            Console.WriteLine($"{mall}");
        }

        Console.WriteLine("Не посетил ни один студент:");
        foreach (string mall in visitedNone)
        {
            Console.WriteLine($"{mall}");
        }
    }

    public static int CountUniqueRussianLetters(string text)
    {
        HashSet<char> uniqueLetters = new HashSet<char>();
        for (int i = 0; i < text.Length; i++)
        {
            char character = char.ToLower(text[i]);
            if ((character >= 'а' && character <= 'я') || character == 'ё')
            {
                uniqueLetters.Add(character);
            }
        }
        return uniqueLetters.Count;
    }

    public class Athlete
    {
        private string _surname;
        private string _name;
        private int[] _scores;
        private int _totalScore;
        private int _rank;

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int[] Scores
        {
            get { return _scores; }
            set { _scores = value; }
        }

        public int TotalScore
        {
            get { return _totalScore; }
            set { _totalScore = value; }
        }

        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public Athlete(string surname, string name, int[] scores)
        {
            _surname = surname;
            _name = name;
            _scores = scores;
            _totalScore = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                _totalScore += scores[i];
            }
            _rank = 1;
        }
    }

    private class AthleteComparer : IComparer<Athlete>
    {
        public int Compare(Athlete? x, Athlete? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return 1;
            }
            if (y == null)
            {
                return -1;
            }
            return y.TotalScore.CompareTo(x.TotalScore);
        }
    }

    public static void Sorting(List<Athlete> athletes)
    {
        athletes.Sort(new AthleteComparer());

        if (athletes.Count > 0)
        {
            athletes[0].Rank = 1;
            for (int i = 1; i < athletes.Count; i++)
            {
                if (athletes[i].TotalScore == athletes[i - 1].TotalScore)
                {
                    athletes[i].Rank = athletes[i - 1].Rank;
                }
                else
                {
                    athletes[i].Rank = i + 1;
                }
            }
        }

        Console.WriteLine("\nРезультат:");
        for (int i = 0; i < athletes.Count; i++)
        {
            Athlete athlete = athletes[i];
            Console.WriteLine($"{athlete.Surname} {athlete.Name} {athlete.TotalScore} {athlete.Rank}");
        }
    }
}