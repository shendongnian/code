    public static class Extensions
    {
        public static void PrintAll(Object root)
        {
            foreach (var x in root.SelectAll())
            {
                Console.WriteLine(x);
            }
        }
        public static IEnumerable<Object> SelectAll(this object o)
        {
            //  C#7
            if (o is IEnumerable e)
            {
                foreach (var child in e)
                {
                    yield return child;
                }
            }
            else
            {
                yield return o;
            }
        }
    }
