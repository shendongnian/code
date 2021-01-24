    class A
    {
        public int Value { get; }
        public A(int value)
        {
            Value = value;
        }
    }
    class B
    {
        public int Value { get; }
        public B(int value)
        {
            Value = value;
        }
    }
    static void Main(string[] args)
    {
        const int minCount = 5, maxCount = 15, maxValue = 50;
        Random random = new Random();
        int listACount = random.Next(minCount, maxCount),
            listBCount = random.Next(minCount, maxCount);
        A[] listA = RandomOrderedSequence(random, maxValue, listACount).Select(i => new A(i)).ToArray();
        B[] listB = RandomOrderedSequence(random, maxValue, listBCount).Select(i => new B(i)).ToArray();
        Console.WriteLine("listA: ");
        Console.WriteLine(string.Join(", ", listA.Select(a => a.Value)));
        Console.WriteLine("listB: ");
        Console.WriteLine(string.Join(", ", listB.Select(b => b.Value)));
        foreach (object o in Merge<object, A, B, int>(listA, listB, a => a.Value, b => b.Value))
        {
            A a = o as A;
            if (a != null)
            {
                // Do something with object of type A
                Console.WriteLine($"a.Value: {a.Value}");
            }
            else
            {
                // Must be a B. Do something with object of type B
                B b = (B)o;
                Console.WriteLine($"b.Value: {b.Value}");
            }
        }
    }
    static IEnumerable<int> RandomOrderedSequence(Random random, int max, int count)
    {
        return RandomSequence(random, max, count).OrderBy(i => i);
    }
    static IEnumerable<int> RandomSequence(Random random, int max, int count)
    {
        while (count-- > 0)
        {
            yield return random.Next(max);
        }
    }
