    class Program
    {
        static void Main(string[] args)
        {
            FlaggedEnum fruitbowl = FlaggedEnum.Apples | FlaggedEnum.Oranges | FlaggedEnum.Pears;
            Console.WriteLine(fruitbowl);
            Console.ReadLine();
        }
    }
    [Flags]
    enum FlaggedEnum
    {
        None = 0,
        Apples = 1,
        Pears = 2,
        Oranges = 4,
        Pineapples = 8
    }
