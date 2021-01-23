    class Program
    {
        static void M(string s)
        {
            Console.WriteLine("Hello " + s);
        }
        static void Main(string[] args)
        {
            MethodInfo method = typeof (Program).GetMethod("M", BindingFlags.Static | BindingFlags.NonPublic);
            //Rest of your code
        }
    }
