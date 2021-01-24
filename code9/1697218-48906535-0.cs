     internal struct EntityLinkKey
     {
        private readonly Type _first;
        private readonly Type _second;
        public EntityLinkKey(Type first, Type second)
        {
            this._first = first;
            this._second = second;
        }
        public override int GetHashCode()
        {
            return this._first.GetHashCode() * 17 + this._second.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (GetType() != obj.GetType()) return false;
            EntityLinkKey p = (EntityLinkKey)obj;
            return p._first == this._first && p._second == this._second;
        }
    }
