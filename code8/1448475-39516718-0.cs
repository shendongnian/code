    public static class DictionaryHelper
    {
        public static bool TryRemoveIfValue<TKey, TValue>(this IDictionary<TKey,TValue> owner, TKey key, TValue value)
        {
            var success = false;
            lock (owner)
            {
                TValue existingValue;
                if (owner.TryGetValue(key, out existingValue))
                {
                    if (value.Equals(existingValue))
                    {
                        owner.Remove(key);
                        success = true;
                    }
                }
            }
            return success;
        }
    }
