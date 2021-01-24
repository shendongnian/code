    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace en
    {
        class Program
        {
            static void Main(string[] args)
            {
                // three sample lists, for demonstration purposes.
                var a = new List<string>() { "a", "b", "c" };
                var b = new List<string>() { "1", "2", "3" };
                var c = new List<string>() { "i", "ii", "iii" };
                // the function needs everything in one argument, so create a list of the lists.
                var lists = new List<List<string>>() { a, b, c };
                var en = DoStuff(lists).GetEnumerator();
                while (en.MoveNext())
                {
                    Console.WriteLine(en.Current);
                }
            }
            // This is the internal function. I only made it private because the "prefix" variable
            // is mostly for internal use, but there might be a use case for exposing that ...
            private static IEnumerable<String> DoStuffRecursive(IEnumerable<String> prefix, IEnumerable<IEnumerable<String>> lists)
            {
                // start with a sanity check
                if (object.ReferenceEquals(null, lists) || lists.Count() == 0)
                {
                    yield return String.Empty;
                }
                // Figure out how far along iteration is
                var len = lists.Count();
                // down to one list. This is the exit point of the recursive function.
                if (len == 1)
                {
                    // Grab the final list from the parameter and iterate over the values.
                    // Create the final string to be returned here.
                    var currentList = lists.First();
                    foreach (var item in currentList)
                    {
                        var result = prefix.ToList();
                        result.Add(item);
                        yield return String.Join(" ", result);
                    }
                }
                else
                {
                    // Split the parameter. Take the first list from the parameter and 
                    // separate it from the remaining lists. Those will be handled 
                    // in deeper calls.
                    var currentList = lists.First();
                    var remainingLists = lists.Skip(1);
                    foreach (var item in currentList)
                    {
                        var iterationPrefix = prefix.ToList();
                        iterationPrefix.Add(item);
                        // here's where the magic happens. You can't return a recursive function
                        // call, but you can return the results from a recursive function call.
                        // http://stackoverflow.com/a/2055944/1462295
                        foreach (var x in DoStuffRecursive(iterationPrefix, remainingLists))
                        {
                            yield return x;
                        }
                    }
                }
            }
            // public function. Only difference from the private function is the prefix is implied.
            public static IEnumerable<String> DoStuff(IEnumerable<IEnumerable<String>> lists)
            {
                return DoStuffRecursive(new List<String>(), lists);
            }
        }
    }
