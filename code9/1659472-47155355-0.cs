    class Program
    {
        static void Main(string[] args)
        {
            List<object> items = new List<object>();
            //instructions to fill the list....
            object item = items.RemoveFirst();
        }
    }
    static class Extend
    {
        public static object RemoveFirst(this List<object> items)
        {
            object item = items.FirstOrDefault();
            if (item != null)
            {
                items.Remove(item);
            }
            return item;
        }
    }
