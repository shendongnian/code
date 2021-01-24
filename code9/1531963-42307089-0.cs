    namespace ConsoleApp
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string[] values = { "This", "That", "The Other Thing" };
                    foreach (var item in values)
                    {
                        Console.Clear();
                        Console.WriteLine(item);
                    }
