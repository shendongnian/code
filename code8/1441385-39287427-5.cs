    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> test = new LinkedList<int>(Enumerable.Range(0, 10)),
                shuffled = Shuffle(test);
            Console.WriteLine(string.Join(", ", shuffled));
        }
        static LinkedList<T> Shuffle<T>(LinkedList<T> source)
        {
            LinkedList<T> result = new LinkedList<T>();
            T[] choices = source.ToArray();
            ShuffleArray(choices);
            foreach (T choice in choices)
            {
                result.AddLast(choice);
            }
            return result;
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
