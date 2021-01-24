    static T[][] MultiThreadRemoveColumn<T>(T[][] matrix, int index)
    {
        T[][] objArray = new T[matrix.Length][];
        Parallel.For(0, matrix.Length, i =>
        {
            var line = matrix[i];
            var reducedline = new T[line.Length - 1];
            Array.Copy(line, 0, reducedline, 0, index);
            Array.Copy(line, index + 1, reducedline, index, line.Length - index - 1);
            objArray[i] = reducedline;                
        });
        return objArray;
    }
