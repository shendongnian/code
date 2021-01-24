    public class CountryKVP<K, V>
    {
        public K CountryKey { get; }
        public V CountryValue { get; }
        public CountryKVP(K key, V value)
        {
            CountryKey = key;
            CountryValue = value;
        }
        public CountryKVP(KeyValuePair<K, V> input)
        {
            CountryKey = input.Key;
            CountryValue = input.Value;
        }
    }
