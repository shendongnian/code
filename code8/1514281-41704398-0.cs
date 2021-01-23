    using System;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            new c().f1(3);
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
    class c
    {
        public void f1(int n)
        {
            f(n-1 , n, "");
        }
        public string f(int n,int depth, string r)
        {
            if(depth == 0)
            {
                Console.WriteLine(r);
                return "";
            }
            for (int i = 1; i <= n ; i++)
            {                
                string r1 =  r + i.ToString();
                f(n, depth - 1, r1);
            }
            return "";
        }        
    }
    }
