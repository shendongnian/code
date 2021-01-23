    [Serializable]
    public struct TripleKey<TKeyA, TKeyB, TKeyC>
    {
        private readonly TKeyA _keyA;
        private readonly TKeyB _keyB;
        private readonly TKeyC _keyC;
        public TKeyA KeyA => _keyA;
        public TKeyB KeyB => _keyB;
        public TKeyC KeyC => _keyC;
        public TripleKey(TKeyA keyA, TKeyB keyB, TKeyC keyC)
        {
            this._keyA = keyA;
            this._keyB = keyB;
            this._keyC = keyC;
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
    public static KeyTriple
    {
        public static TripleKey<TKeyA, TKeyB, TKeyC> Create<TKeyA, TKeyB, TKeyC>(TKeyA keyA, TKeyB keyB, TKeyC keyC)
        {
            return new TripleKey<TKeyA, TKeyB, TKeyC>(keyA, keyB, keyC);
        }
    }
    public class MultiKeyDictionary<TKeyA, TKeyB, TKeyC, TValue> : Dictionary<KeyTriple<TKeyA, TKeyB, TKeyC>, TValue>
    {
        public TValue this[TKeyA keyA, TKeyB keyB, TKeyC keyC]
        {
            get
            {
                var key = KeyTriple.Create(keyA, keyB, keyC);
                return base.ContainsKey(key) ? base[key] : default(TValue);
            }
            set
            {
                var key = KeyTriple.Create(keyA, keyB, keyC);
                if (!ContainsKey(key))
                    base.Add(key, value);
                this[key] = value;
            }
        }
        public bool ContainsKey(TKeyA keyA, TKeyB keyB, TKeyC keyC)
        {
            var key = KeyTriple.Create(keyA, keyB, keyC);
            return base.ContainsKey(key);
        }
        public void Add(TKeyA keyA, TKeyB keyB, TKeyC keyC, TValue value)
        {
            base.Add(KeyTriple.Create(keyA, keyB, keyC), value);;
        }
    }
