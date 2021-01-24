    class TBL_Points: IEquatable<TBL_Points>
    {
        public bool Equals(TBL_Points other) => Code == other?.Code;
        public sealed override bool Equals(object obj) => obj is TBL_Points o && Equals(o);
        public sealed override int GetHashCode() => Code.GetHashCode();
        public static bool operator ==(TBL_Points x, TBL_Points y) => x?.Equals(y);
        public static bool operator !=(TBL_Points x, TBL_Points y) => !(x == y);
    }
