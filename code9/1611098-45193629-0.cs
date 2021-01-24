    using System;
    using System.Linq;
    
    public enum Order : byte
    {
        a = 1,
        b = 2,
        c = 3
    }
    
    public class Foo
    {
        public long A { get; set; }
        public long B { get; set; }
        public long C { get; set; }
    }
    
    public class Worker
    {
        private Foo[] orderFoos(Foo[] foos, Func<Foo, long> sort)
        {
            return foos.OrderByDescending(sort).ToArray();
        }
    
        public void Work()
        {
            Foo[] foos = { new Foo() { A = 1, B = 2, C = 3 }, new Foo() { A = 10, B = 1, C = 2 }, new Foo() { A = -1, B = 1, C = 10 } };
    
            var orderByA = orderFoos(foos, f => f.A);
            var orderByB = orderFoos(foos, f => f.B);
            var orderByC = orderFoos(foos, f => f.C);
    
            Console.WriteLine(orderByA.First().A); // I expect the second to be first here so 10
            Console.WriteLine(orderByB.First().A); // I expect the first to be first here so 1
            Console.WriteLine(orderByC.First().A); // I expect the third to be first here so -1
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
    
            worker.Work();
            Console.ReadLine();
        }
    }
