    private class KeyValuePairEqualityComparer : IEqualityComparer<KeyValuePair<int, int>>
    {
        public bool Equals(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            return x.Key == y.Value && x.Value == y.Key;
        }
        public int GetHashCode(KeyValuePair<int, int> obj)
        {
            // Equality check happens on HashCodes first.
            // Multiplying key/value pairs, ensures that mirrors
            // are forced to check for equality via the Equals method
            return obj.Key * obj.Value;
        }
    }
