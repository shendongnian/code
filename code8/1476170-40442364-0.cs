    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    public class Test
    {
        static void Main()
        {
            int multiplier = 3;
            IQueryable<int> values = new List<int> { 1, 2 }.AsQueryable();
            Expression<Func<int, int>> expression = x => x * multiplier;
            
            // Prints 3, 6
            foreach (var item in values.Select(expression))
            {
                Console.WriteLine(item);
            }
            
            multiplier = 5;
    
            // Prints 5, 10
            foreach (var item in values.Select(expression))
            {
                Console.WriteLine(item);
            }
        }
    }
