    namespace System.Linq
    {
    public static class LinqExtensions
    {
        // This one's more or less like "Contains" except for the "params" part
        // Example: book.Id.In(1, 2, 3, 4, 5)
        public static bool In<T>(this T item, params T[] list)
        {
            foreach (T args in list)
            {
                if (args.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        // Same idea as above except using an equality tester
        // Example: listBooks.Where(book => book.In((bk, id) => bk.Id == id, 1, 2, 3, 4, 5));
        public static bool In<T, U>(this T item, Func<T, U, bool> equalitytester, params U[] list)
        {
            foreach (U arg in list)
            {
                if (equalitytester(item, arg))
                {
                    return true;
                }
            }
            return false;
        }
        // See if any item in the first list is also in the second list
        public static bool In<T, U>(this IEnumerable<T> list, Func<T, U, bool> equalityTester, params U[] argList)
        {
            foreach (T item in list)
            {
                foreach (U arg in argList)
                {
                    if (equalityTester(item, arg))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    }
