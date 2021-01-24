    public static int[] GetIndexOfDifferences<T>(T[] array1, T[] array2) where T : IEquatable<T>
    {
        var diff_check = array1.Zip(array2, (x, y) => x.Equals(y));
        var get_index = Enumerable.Range(0, array1.Length).Zip(diff_check, (i, z) => z ? -1 : i);
        return get_index.Where((i) => i>=0).ToArray();
    }
    static void Main(string[] args)
    {
        var a = new[] { 1, 1, 1, 2, 2, 3, 5, 5, 6, 3, 3, 2, 2 };
        var b = new[] { 1, 1, 2, 2, 3, 3, 3, 4, 6, 5, 4, 3, 2 };
        // equals?      Y  Y  N  Y  N  Y  N  N  Y  N  N  N  Y
        // index:       0  1  2  3  4  5  6  7  8  9 10 11 12
        // expected result = { 2, 4, 6, 7, 9, 10, 11 }
        var result = GetIndexOfDifferences(a, b); // check
    }
