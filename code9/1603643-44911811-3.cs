    public static class GenericCounter<T>
    {
        public static int Count { get; set; } = 0;
    }
    GenericCounter<int>.Count++;
    GenericCounter<int>.Count++;
    GenericCounter<string>.Count++;
    Console.WriteLine(GenericCounter<double>.Count); // 0
    Console.WriteLine(GenericCounter<int>.Count); // 2
    Console.WriteLine(GenericCounter<string>.Count); // 1
