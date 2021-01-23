    private static IEnumerable<Foo> GetAllFoosFIFO(Foo foo)
    {
        foreach (var c in foo.Children)
        {
            yield return c;
            var cc = GetAllFoosFIFO(c);
            foreach (var ccc in cc)
            {
                yield return ccc;
            }
        }
    }
