    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> array, string seperator)
    {
        var currentIndex = 0;
        while (currentIndex < array.Count)
        {
            var part = array.Skip(currentIndex).TakeWhile(item => !item.Equals(seperator));
            currentIndex += part.Count() + 1;
            yield return part;
        }
    }
