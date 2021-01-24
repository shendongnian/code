    class Program
    {
        static List<string> MyGenericList = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine($"My list class's type is: {MyGenericList.GetType()}, and its first generic argument is: {MyGenericList.GetType().GetGenericArguments()[0]}");
            Console.ReadLine();
        }
    }
