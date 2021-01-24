    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program.DoStuff<string>();
				Program.DoStuff<Program>();
            }
            static void DoStuff<T>()
            {
            }
        }
    }
