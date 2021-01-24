    public static TKey GetNextKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, 
        TKey currentKey, TValue nextValue)
    {
        var ckFounded = false;
        for (var i = 0; i < 2; i++)
        {
            foreach (var pair in dictionary)
            {
                if (ckFounded && pair.Value.Equals(nextValue))
                {
                    return pair.Key;
                }
                if (pair.Key.Equals(currentKey))
                {
                    ckFounded = true;
                }
            }
        }
        throw new Exception("Key not found");
    }
