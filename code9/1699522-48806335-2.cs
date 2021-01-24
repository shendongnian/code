    public static T[,] ToMultiArray<T>(this IList<T[]> arrays)
    {
        var length = arrays[0].Length;
        var result = new T[arrays.Count, length];
        for (var i = 0; i < arrays.Count; i++)
        {
            var array = arrays[i];
            if (array.Length != length)
            {
                throw new ArgumentException("Misaligned arrays");
            }
    
            for (var j = 0; j < length; j++)
            {
                result[i, j] = array[j];
            }
        }
    
        return result;
    }
