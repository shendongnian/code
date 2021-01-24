    public static class X
    {
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> items,
            T oldValue, T newValue) where T : class
        {
            //  Six years of college, down the drain. 
            return items.Select(x => x == oldValue ? newValue : x);
        }
        //  Int32, long, double, etc. But you need Cast<T>().
        public static IEnumerable<IComparable> Replace(this IEnumerable<IComparable> items,
            IComparable oldValue, IComparable newValue)
        {
            return items.Select(x => x.CompareTo(oldValue) == 0 ? newValue : x);
        }
        //  This strikes me as a more flexible way to go about it, but we'll 
        //  see below what it really gains us in practice. 
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> items,
            Func<T, bool> selector, Func<T, T> converter)
        {
            return items.Select(x => selector(x) ? converter(x) : x);
        }
        public static void Test()
        {
            var r = Enumerable.Range(0, 20);
            //  Is this code really bad enough to justify writing an extension method?
            var q0 = r.Select(x => x == 4 ? 0 : x);
            //  Nah. You could write explicit overloads for every numeric type. But why?
            var q1 = r.Cast<IComparable>().Replace(4, 0);
            //  Here's the lambda version.
            var q2 = r.Replace(x => (x % 3) == 0, x => x * 9);
            //  But does it really improve on this? I don't see it, myself. 
            var q3 = r.Select(x => ((x % 3) == 0) ? x * 9 : x);
            //  Remember, none of the above code is actually executed until you start 
            //  enumerating them. This next line is the first time any of the code
            //  in any of the extension methods actually gets executed. 
            var list = q3.ToList();
        }
    }
