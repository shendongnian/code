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
            //  C#7
            else if (o is IEnumerable e)
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
