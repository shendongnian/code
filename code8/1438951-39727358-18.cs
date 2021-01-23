    [Serializable]
    public struct TripleKey<TKeyA, TKeyB, TKeyC>
    {
        public TKeyA KeyA { get; };
        public TKeyB KeyB { get; };
        public TKeyC KeyC { get; };
        public TripleKey(TKeyA keyA, TKeyB keyB, TKeyC keyC)
        {
            this.KeyA = keyA;
            this.KeyB = keyB;
            this.KeyC = keyC;
        }
        // this code is almost the same as it is in Microsoft implementation
        public override string ToString()
        {
            var sBuilder = new StringBuilder();
            sBuilder.Append('(');
            if (KeyA != null)
            {
                sBuilder.Append(KeyA.ToString());
            }
            sBuilder.Append(", ");
            if (KeyB != null)
            {
                sBuilder.Append(KeyB.ToString());
            }
            sBuilder.Append(", ");
            if (KeyC != null)
            {
                sBuilder.Append(KeyC.ToString());
            }
            sBuilder.Append(')');
            return sBuilder.ToString();
        }
    }
    public static class TripleKey
    {
        public static TripleKey<TKeyA, TKeyB, TKeyC> Create<TKeyA, TKeyB, TKeyC>(TKeyA keyA, TKeyB keyB, TKeyC keyC)
        {
            return new TripleKey<TKeyA, TKeyB, TKeyC>(keyA, keyB, keyC);
        }
    }
    public class MultiKeyDictionary<TKeyA, TKeyB, TKeyC, TValue> : Dictionary<TripleKey<TKeyA, TKeyB, TKeyC>, TValue>
    {
        public TValue this[TKeyA keyA, TKeyB keyB, TKeyC keyC]
        {
            get
            {
                var key = TripleKey.Create(keyA, keyB, keyC);
                return base.ContainsKey(key) ? base[key] : default(TValue);
            }
            set
            {
                var key = TripleKey.Create(keyA, keyB, keyC);
                if (!ContainsKey(key))
                    base.Add(key, value);
                this[key] = value;
            }
        }
        public bool ContainsKey(TKeyA keyA, TKeyB keyB, TKeyC keyC)
        {
            var key = TripleKey.Create(keyA, keyB, keyC);
            return base.ContainsKey(key);
        }
        public void Add(TKeyA keyA, TKeyB keyB, TKeyC keyC, TValue value)
        {
            base.Add(TripleKey.Create(keyA, keyB, keyC), value);
        }
    }
