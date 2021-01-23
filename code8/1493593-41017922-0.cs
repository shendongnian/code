    public static object[] GetTuples()
    {
        return new Tuple<string, int>[10]; // R# warning here
    }
    public static void Test()
    {
        object[] tuples = GetTuples();
        tuples[0] = new Tuple<string, int>("", 1);
        tuples[1] = ""; // this will crash process, but no R# Warnings here
    }
