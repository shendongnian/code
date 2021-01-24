    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var types = new[]
            {
                typeof(IEnumerable<int>),
                typeof(ICollection<int>),
                typeof(Stack<int>),
                typeof(IList<int>),
                typeof(int[])
            };
            
            var leaves = types.Where(candidate =>
                !types.Any(t => t != candidate && candidate.IsAssignableFrom(t)));
            Console.WriteLine(string.Join(Environment.NewLine, leaves));
        }
    }
