    public static class Extensions
    {
        public static void PrintAll(this Object root)
        {
            foreach (var x in root.SelectAll(""))
            {
                Console.WriteLine(x.Item1 + x.Item2);
            }
        }
        public static IEnumerable<(string, Object)> SelectAll(this object o, string indentation)
        {
            //  Thank you, eocron
            if (o is String)
            {
                yield return (indentation, o);
            }
            else if (o is IEnumerable)
            {
                var e = o as IEnumerable;
                foreach (var child in e)
                {
                    foreach (var child2 in child.SelectAll(indentation + "  "))
                        yield return (child2.Item1, child2.Item2);
                }
            }
            else
            {
                yield return (indentation, o);
            }
        }
    }
