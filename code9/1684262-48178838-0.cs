    class Program
    {
    
        static void Main(string[] args)
        {
            int x;
            Thread t = new Thread(() => {  sum(12, 6, out x); });
        }
    
        static void sum(int a, int b, out int p)
        {
            p = a + b;
        }    
    }
