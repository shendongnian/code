    public class CombinedKey
    {
        public string Key1;
        public string Key2;
        // It is necessary to override Equals and GetHashCode to make
        // it work properly as a dictionary key.
        public override bool Equals(object obj)
        {
            var otherCombinedKey = obj as CombinedKey;
            return otherCombinedKey != null
                && otherCombinedKey.Key1 == this.Key1
                && otherCombinedKey.Key2 == this.Key2;
        }
        public override int GetHashCode()
        {
            return Key1.GetHashCode() ^ Key2.GetHashCode();
        }
    }
