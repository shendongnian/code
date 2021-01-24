    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using static System.Console;
    
    public static class DbSetExtension
    {
        public static void ShowSortedBy<T,TKey>(this DbSet<T> set, Func<T,TKey> keySelector) where T:class
        {
            var sortedSet = set.OrderBy(x => keySelector(x)).ToList();
    
            WriteLine();
            WriteLine($"Set: {typeof(T).Name} - {set.Count()} objects.");
            WriteLine();
    
            foreach (var e in sortedSet)
            {
                WriteLine(e);
            }
    
            WriteLine();
            WriteLine();
    
        }
    }
