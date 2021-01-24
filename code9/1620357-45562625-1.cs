    public static class ListExtensions
    {
        public static List<object> OfTypeRecursive<T>(this List<object> source)
            where T : INestedList
        {
            var itemsToDigInto = source.OfType<T>().ToList();
            var output = source.Except(itemsToDigInto.Cast<object>()).ToList();
            foreach (T item in itemsToDigInto)
            {
                Console.WriteLine($"Extracting from InnerList of {item}");
                output.AddRange(item.InnerList.OfTypeRecursive<T>());
                Console.WriteLine($"Finished processing for {item}");
            }
            return output;
        }
    }
    public class Program
    {
        public static void Main()
        {
            var x = 2;
            var y = 4.3m;
            var z = "sf";
            var p = new ContainsNestedList("p", new List<object> { x, y });
            var q = new ContainsNestedList("q", new List<object> { z, p });
            var r = new ContainsNestedList("r", new List<object> { x, y, p, q });
            var source = new List<object> { x, y, z, q, p, r };
            var result = source.OfTypeRecursive<ContainsNestedList>();
            result.ForEach(i => Console.WriteLine("{0}", i));
            Console.ReadKey();
        }
    }
