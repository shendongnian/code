    public static class Extensions
    {
        public static T NextItem<T>(this Random r, params T[] items)
        {
            //  Thanks to nbokmans for catching my error here: The second parameter
            //  is not the largest value it can return; it's the "exclusive upper bound".
            return items[r.Next(0, items.Length)];
        }
    }
...
    Random rnd = new Random();
    string name = rnd.NextItem("-", "+");
