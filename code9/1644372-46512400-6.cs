    sealed class PointComparer: EqualityComparer<TBL_Points>
    {
        public override bool Equals(TBL_Points x, TBL_Points y) => x.Code == y.Code;
        public override int GetHashCode(TBL_Points point) => point.Code.GetHashCode();
    }
