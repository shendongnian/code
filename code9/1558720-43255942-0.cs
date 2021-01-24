    public class Program
    {
        public static void Main(string[] args)
        {
            int[] t = {1, 2, 3};
            ref int a = ref t[0];
            a += 10;
            System.Console.WriteLine($"a={a}");       // 11
            System.Console.WriteLine($"t[0]={t[0]}"); // 11
        }
    }
