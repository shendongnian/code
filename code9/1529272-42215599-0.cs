    static void Main(string[] args)
    {
        var keys = new string[5] { "1111", "2222", "3333", "4444", "5555" };
        var speed = new double[5] { 1, 2, 1, 1, 5 };
        var speed2 = new double[5] { 1, 2, 3, 4, 5 };
        var dictionary1 = new Dictionary<string, double>();
        var dictionary2 = new Dictionary<string, double>();
        for (int iRow = 0; iRow < keys.Length; iRow++)
        {
            dictionary1.Add(keys[iRow], speed[iRow]);
            dictionary2.Add(keys[iRow], speed2[iRow]);
        }
        // the solution
        var result = dictionary1.ToDictionary(x => x.Key, kv => kv.Value == 1 ? dictionary2[kv.Key] : kv.Value);
    }
