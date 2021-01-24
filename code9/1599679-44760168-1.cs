    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {1, 3, 2};
            Console.WriteLine(string.Join(",", list.FluentInvoke(o => o.Sort())));
            Console.ReadLine();
        }
    }
