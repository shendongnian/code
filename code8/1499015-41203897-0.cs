    public class PascalCaseDictionaryKeyNamingStrategy : DefaultNamingStrategy
    {
        public PascalCaseDictionaryKeyNamingStrategy() : base() { this.ProcessDictionaryKeys = true; }
        public override string GetDictionaryKey(string key)
        {
            if (ProcessDictionaryKeys && key.Length > 0)
            {
                if (char.ToUpperInvariant(key[0]) != key[0])
                {
                    var builder = new StringBuilder(key);
                    builder[0] = char.ToUpperInvariant(key[0]);
                    return builder.ToString();
                }
            }
            return key;
        }
    }
