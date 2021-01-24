    public class CountryKVP
    {
        public string CountryKey { get; }
        public string CountryValue { get; }
        public CountryKVP(string key, string value)
        {
            CountryKey = key;
            CountryValue = value;
        }
        public CountryKVP(KeyValuePair<string, string> input)
        {
            CountryKey = input.Key;
            CountryValue = input.Value;
        }
    }
