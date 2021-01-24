    public class Class1
    {
        public void Print(out string dataToPrint)
        {
            dataToPrint = "some text here";
        }
        public string Print()
        {
            return "some text here";
        }
        [Benchmark]
        public void one()
        {
            string data;
            Print(out data);
        }
        [Benchmark]
        public void two()
        {
            Print();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Class1>();
        }
    }
