    public static T[] Except<T>(this T[] first, T[] second)
    {
        if (first == null)
            throw new ArgumentNullException(nameof(first));
        if (second == null)
            throw new ArgumentNullException(nameof(second));
        if (second.Length == 0)
            return first;
        var counter = 0;
        var newArray = new T[first.Length];
        foreach (var f in first)
        {
            var found = false;
            foreach (var s in second)
            {
                if (f.Equals(s))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                newArray[counter] = f;
                counter++;
            }
        }
        Array.Resize(ref newArray, counter);
        return newArray;
    }
