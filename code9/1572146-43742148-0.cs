    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace en
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = new List<string>() { "a", "b", "c" };
                var b = new List<string>() { "1", "2", "3" };
                var c = new List<string>() { "i", "ii", "iii" };
                var lists = new List<List<string>>() { a, b, c };
                var en = DoStuff(lists).GetEnumerator();
                while (en.MoveNext())
                {
                    Console.WriteLine(en.Current);
                }
            }
            private static IEnumerable<String> DoStuffRecursive(string prefix, IEnumerable<IEnumerable<String>> lists)
            {
                var len = lists.Count();
                if (object.ReferenceEquals(null, lists) || len == 0)
                {
                    yield return prefix;
                }
                else if (len == 1)
                {
                    var currentList = lists.First();
                    foreach (var item in currentList)
                    {
                        yield return prefix + " " + item.ToString();
                    }
                }
                else
                {
                    var currentList = lists.First();
                    var remainingLists = lists.Skip(1);
                    foreach (var item in currentList)
                    {
                        foreach (var x in DoStuffRecursive(item.ToString(), remainingLists))
                        {
                            yield return prefix + " " + x.ToString();
                        }
                    }
                }
            }
            public static IEnumerable<String> DoStuff(IEnumerable<IEnumerable<String>> lists)
            {
                return DoStuffRecursive(string.Empty, lists);
            }
        }
    }
