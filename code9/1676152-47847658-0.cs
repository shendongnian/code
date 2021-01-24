    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace Testing
    {
    
    
        public class Property
        {
            public string Name { get; set; }
        }
    
        public class JoinedProperty
        {
            public Property Name1 { get; set; }
            public Property Name2 { get; set; }
    
            public override string ToString()
            {
                return (Name1 == null ? "" : Name1.Name)
                    + (Name2 == null ? "" : Name2.Name);
            }  
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var list1 = new List<Property>
            {
                new Property{ Name = "A" },
                new Property{ Name = "A" },
                new Property{ Name = "A" },
                new Property{ Name = "B" }
            };
    
                var list2 = new List<Property>
            {
                new Property{ Name = "A" },
                new Property{ Name = "B" },
                new Property{ Name = "B" }
            };
    
             
    
                var result = list1.FullOuterJoin(
                    list2,
                    p1 => p1.Name,
                    p2 => p2.Name,
                    (p1, p2) => new JoinedProperty
                    {
                        Name1 = p1,
                        Name2 = p2
                    }).ToList();
    
    
                foreach (var res in result)
                {
                    Console.WriteLine(res.ToString());
                }
                Console.ReadLine();
               
            }
          
        }
    
        public static class MyExtensions
        {
    
    
    
            public static IEnumerable<TResult>
                FullOuterJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                    IEnumerable<TInner> inner,
                                    Func<TSource, TKey> pk,
                                    Func<TInner, TKey> fk,
                                    Func<TSource, TInner, TResult> result)
                where TSource : class where TInner : class
            {
    
                var fullList = source.Select(s => new Tuple<TSource, TInner>(s, null))
                    .Concat(inner.Select(i => new Tuple<TSource, TInner>(null, i)));
    
    
                var joinedList = new List<Tuple<TSource, TInner>>();
    
                foreach (var item in fullList)
                {
                    var matchingItem = joinedList.FirstOrDefault
                        (
                            i => matches(i, item, pk, fk)
                        );
    
                    if(matchingItem != null)
                    {
                        joinedList.Remove(matchingItem);
                        joinedList.Add(combinedMatchingItems(item, matchingItem));
                    }
                    else
                    {
                        joinedList.Add(item);
                    }
                }
                return joinedList.Select(jl => result(jl.Item1, jl.Item2)).ToList();
    
            }
    
            private static Tuple<TSource, TInner> combinedMatchingItems<TSource, TInner>(Tuple<TSource, TInner> item1, Tuple<TSource, TInner> item2)
                where TSource : class
                where TInner : class
            {
                if(item1.Item1 == null && item2.Item2 == null && item1.Item2 != null && item2.Item1 !=null)
                {
                    return new Tuple<TSource, TInner>(item2.Item1, item1.Item2);
                }
    
                if(item1.Item2 == null && item2.Item1 == null && item1.Item1 != null && item2.Item2 != null)
                {
                    return new Tuple<TSource, TInner>(item1.Item1, item2.Item2);
                }
    
                throw new InvalidOperationException("2 items cannot be combined");
            }
    
            public static bool matches<TSource, TInner, TKey>(Tuple<TSource, TInner> item1, Tuple<TSource, TInner> item2, Func<TSource, TKey> pk, Func<TInner, TKey> fk)
                where TSource : class
                where TInner : class
            {          
                
                if (item1.Item1 != null && item1.Item2 == null && item2.Item2 != null && item2.Item1 == null && pk(item1.Item1).Equals(fk(item2.Item2)))
                {
                    return true;
                }
    
                if (item1.Item2 != null && item1.Item1 == null && item2.Item1 != null && item2.Item2 == null && fk(item1.Item2).Equals(pk(item2.Item1)))
                {
                    return true;
                }
    
                return false;
    
            }
    
        }
    }
