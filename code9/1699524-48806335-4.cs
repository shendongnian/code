    public static T[][] ToJaggedArray<T>(IList<List<T>> arrays)
    {
    
        var result = new T[arrays.Count][];
        for (var i = 0; i < arrays.Count; i++)
        {
            var array = arrays[i];
            var length = array.Count;
            result[i] = new T[length];
            for (var j = 0; j < length; j++)
            {
                result[i][j] = array[j];
            }
        }
    
        return result;
    }
