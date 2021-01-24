    class Test 
    {
        public static bool IsEqual<T>(T a, T b)
            where T : IEquatable<T>
        { return a.Equals(b); }
    }
