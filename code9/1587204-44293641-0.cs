    internal class Program
        {
            private static void Main(string[] args)
            {
                var nestedSortedList = new NestedSortedList<string>();
                nestedSortedList.Add("1", new NestedSortedList<string>());
                nestedSortedList.Add("2", new NestedSortedList<string>());
                nestedSortedList.Add("3", new NestedSortedList<string>());
    
                nestedSortedList["1"].Add("11", new NestedSortedList<string>());
                nestedSortedList["2"].Add("21", new NestedSortedList<string>());
                nestedSortedList["2"].Add("22", new NestedSortedList<string>());
    
                foreach (var item in nestedSortedList)
                {
                    Console.WriteLine(item);
                    foreach (var value in item.Value.Values)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
    }
