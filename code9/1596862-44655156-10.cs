    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> array, string seperator)
    {
        var currentIndex = 0;
        while (currentIndex < array.Count())
        {
            var part = array.Skip(currentIndex).TakeWhile(item => 
            {
                currentIndex++;
                return !item.Equals(seperator);
            });
            yield return part;
        }
    }
