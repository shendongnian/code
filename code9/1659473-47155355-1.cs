    class Program
    {
        static void Main(string[] args)
        {
            List<object> items = new List<object>();
            //code to fill the list...
            object item = items.RemoveFirst();
        }
    }
    static class Extensions
    {
        public static T RemoveFirst<T>(this ICollection<T> items)
        {
            T item = items.FirstOrDefault();
            if (item != null)
            {
                items.Remove(item);
            }
            return item;
        }
    }
