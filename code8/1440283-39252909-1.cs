    internal sealed class AnonymousType<TName, TValue>
    {
        private readonly TName _name;
        private readonly TValue _value;
        public TName name => this._name;
        public TValue value => this._value;
        public AnonymousType(TName name, TValue value)
        {
            this._name = name;
            this._value = value;
        }
        public override bool Equals(object value)
        {
            var that = value as AnonymousType<TName, TValue>;
            return that != null &&
                EqualityComparer<TName>.Default.Equals(this._name, that._name) &&
                EqualityComparer<TValue>.Default.Equals(this._value, that._value);
        }
        public override int GetHashCode()
        {
            // ...
        }
    }
