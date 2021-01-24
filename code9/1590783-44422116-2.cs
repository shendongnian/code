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
            //  Thank you, eocron
            if (o is String)
            {
                yield return o;
            }
            else if (o is IEnumerable)
            {
                var e = o as IEnumerable;
                foreach (var child in e.SelectAll())
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
