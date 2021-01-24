    public static class Extensions
    {
        public static void PrintAll(this Object root)
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
                foreach (var child in e)
                {
                    foreach (var child2 in child.SelectAll())
                        yield return child2;
                }
            }
            else
            {
                yield return o;
            }
        }
    }
