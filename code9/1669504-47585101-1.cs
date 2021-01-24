    public static T[,] To2dArray<T>(this List<List<T>> list)
        {
            if (list.Count == 0 || list[0].Count == 0)
                throw new ArgumentException("The list must have non-zero dimensions.");
    
            var result = new T[list.Count, list[0].Count];
            for (int rows = 0; rows < list.Count; rows++)
            {
                for (int cols = 0; cols < list[rows].Count; cols++)
                {
                    if (list[rows].Count != list[0].Count)
                        throw new InvalidOperationException("The list cannot contain elements (lists) of different sizes.");
    
                    result[rows, cols] = list[rows][cols];
                }
            }
    
            return result;
        }
