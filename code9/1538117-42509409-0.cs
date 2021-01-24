    public static IEnumerable<string> Sort(this IEnumerable<string> enumerable, string first, string second)
    {
        return enumerable.TakeWhile(s => s != second)
            .Concat(enumerable.SkipWhile(s => s != second).OrderBy(a => a != first));
    }
