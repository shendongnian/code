    public static class ListExtensions
    {
        public static List<T> OfTypeRecursive<T, TU>(this List<object> source)
            where TU : INestedList
        {
            var output = source.OfType<T>().ToList();
            var itemsToDigInto = source.OfType<TU>();
            foreach (TU item in itemsToDigInto)
            {
                Console.WriteLine($"Extracting from InnerList of {item}");
                output.AddRange(item.InnerList.OfTypeRecursive<T, TU>());
                Console.WriteLine($"Finished processing for {item}");
            }
            return output;
        }
    }
