    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkC(); //Gives 24
            //BenchmarkD(); //Gives 24
        }
        static void BenchmarkC()
        {
            long StopBytes = 0;
            long StartBytes = System.GC.GetTotalMemory(true);
            C objC = new C();
            StopBytes = System.GC.GetTotalMemory(true);
            GC.KeepAlive(objC);
            Console.WriteLine(StopBytes - StartBytes);
            Console.ReadKey();
        }
        static void BenchmarkD()
        {
            long StopBytes = 0;
            long StartBytes = System.GC.GetTotalMemory(true);
            D objD = new D();
            StopBytes = System.GC.GetTotalMemory(true);
            GC.KeepAlive(objD);
            Console.WriteLine(StopBytes - StartBytes);
            Console.ReadKey();
        }
    }
    public abstract class A
    {
        public int TheInt { get; set; }
        public string GetString(double dbl)
        {
            return dbl.ToString();
        }
    }
    public class B
    {
        public int TheInt { get; set; }
        public string GetString(double dbl)
        {
            return dbl.ToString();
        }
    }
    public class C : A
    {
    }
    public class D : B
    {
    }
