    public static class Extensions
    {
        public static T NextItem<T>(this Random r, params T[] items)
        {
            return items[r.Next(0, items.Length - 1)];
        }
    }
...
    Random rnd = new Random();
    string name = rnd.NextItem("-", "+");
