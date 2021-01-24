    public static IEnumerable<List<T>> Split<T>(this List<T> array, string seperator)
    {
        var currentIndex = 0;
        while (currentIndex < array.Count)
        {
            var part = array.Skip(currentIndex).TakeWhile(item => !item.Equals(seperator)).ToList();
            currentIndex += part.Count + 1;
            yield return part;
        }
    }
