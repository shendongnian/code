    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    // Just for type inference...
    public static class DeferredEnumerable
    {
        public static IEnumerable<T> For<T>(Func<IEnumerable<T>> func) =>
            new DeferredEnumerable<T>(func);
    }
    
    public sealed class DeferredEnumerable<T> : IEnumerable<T>
    {
        private readonly Func<IEnumerable<T>> func;
        
        public DeferredEnumerable(Func<IEnumerable<T>> func)
        {
            this.func = func;
        }
        
        public IEnumerator<T> GetEnumerator() => func().GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    class Test
    {
        static void Main()
        {
            var query = 
                from c in DeferredEnumerable.For(Console.ReadLine)
                group c by char.IsDigit(c) into gr
                select new { IsDigit = gr.Key, Count = gr.Count() };
    
            
            Console.WriteLine("First go round");
            Console.WriteLine(string.Join(Environment.NewLine, query));
            
            Console.WriteLine("Second go round");
            Console.WriteLine(string.Join(Environment.NewLine, query));
        }
    }
