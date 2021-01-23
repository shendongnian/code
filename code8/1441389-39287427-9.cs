    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> test = new LinkedList<int>(Enumerable.Range(0, 10));
            Shuffle(test);
            Console.WriteLine(string.Join(", ", test));
        }
        static void Shuffle<T>(LinkedList<T> source)
        {
            T[] choices = new T[source.Count];
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = source.First.Value;
                source.RemoveFirst();
            }
            ShuffleArray(choices);
            foreach (T choice in choices)
            {
                source.AddLast(choice);
            }
        }
        static void ShuffleArray<T>(T[] array)
        {
            // Naturally, in real code you'd want to reuse the same Random object
            // across multiple calls, by making it static readonly
            Random random = new Random();
            for (int i = array.Length; i > 1; i--)
            {
                int j = random.Next(i);
                if (i - 1 != j)
                {
                    T t = array[i - 1];
                    array[i - 1] = array[j];
                    array[j] = t;
                }
            }
        }
    }
