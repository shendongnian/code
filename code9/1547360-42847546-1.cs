    static T IncrementEnum<T>(T value)
    {
        int[] values = Enum.GetValues(typeof(T)).Cast<int>().ToArray();
        int i = (int)(object)value,
            min = values.Min(),
            max = values.Max();
        return (T)(object)(i == max ? min : i + 1);
    }
