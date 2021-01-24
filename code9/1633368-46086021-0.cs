    static void Main(string[] args)
    {
        string[,] array1 = { { "123", "09/17/17" }, { "456", "09/17/17" }, { "789", "09/18/17" } };
        string[,] array2 = { { "147", "09/17/17" }, { "789", "09/20/17" }, { "123", "09/19/17" } };
        // .ToArray() not required when only iterating once
        // and .Length is not required
        var elements = array1.Except2D(array2).ToArray();
        // make it a 2D array, if required
        string[,] combined = new string[elements.Length, 2];
        for (int i = 0; i < elements.Length; i++)
        {
            combined[i, 0] = elements[i].Item1;
            combined[i, 1] = elements[i].Item2;
        }
        Console.ReadLine();
    }
    static IEnumerable<Tuple<string, string>> Except2D(this string[,] a, string[,] b)
    {
        HashSet<string> keys = new HashSet<string>();
        for (int index = 0; index < a.GetLength(0); index++)
        {
            if(keys.Add(a[index, 0]))
            {
                yield return new Tuple<string, string>(a[index, 0], a[index, 1]);
            }
        }
    }
