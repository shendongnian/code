    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        public static class ExtensionMethods
        {
            public static T FindFirstGap<T>(this IEnumerable<T> @this, Func<T, T> getNext, IEqualityComparer<T> comparer) where T : struct
            {
                using (var enumerator = @this.GetEnumerator())
                {
                    T nextItem = default(T);
                    while (enumerator.MoveNext())
                    {
                        var currentItem = enumerator.Current;
                        if (!comparer.Equals(currentItem, nextItem))
                            return nextItem;
                        nextItem = getNext(currentItem);
                    }
                    return nextItem;
                }
            }
    
            public static int FindFirstGap(this IEnumerable<int> @this)
            {
                return FindFirstGap(@this, i => i + 1, EqualityComparer<int>.Default);
            }
        }
        //examples
        class Program
        {
            static void Main(string[] args)
            {
                //Your original example
                var items = new List<int> { 0, 1, 5, 7 };
                var gap = items.FindFirstGap();
                Console.WriteLine(gap); //shows 2
    
                //No gaps
                items = new List<int> { 0, 1, 2, 3 };
                gap = items.FindFirstGap();
                Console.WriteLine(gap); //shows 4
    
                //no 0
                items = new List<int> { 1, 2, 3, 4 };
                gap = items.FindFirstGap();
                Console.WriteLine(gap); //shows 0
                Console.ReadLine();
            }
        }
    }
