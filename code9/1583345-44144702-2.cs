    public class CountryKVP<TKey, TValue>
    {
        public TKey CountryKey { get; }
        public TValue CountryValue { get; }
        public CountryKVP(TKey key, TValue value)
        {
            CountryKey = key;
            CountryValue = value;
        }
        public CountryKVP(KeyValuePair<TKey, TValue> input)
        {
            CountryKey = input.Key;
            CountryValue = input.Value;
        }
    }
