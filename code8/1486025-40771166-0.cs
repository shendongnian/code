    public class DetailsComparer : IEqualityComparer<Details>
    {
        public bool Equals(Details x, Details y)
            => x.id == y.id && x.symbol == y.symbol && x.code == y.code;
        public int GetHashCode(Details obj)
             => obj.code.GetHashCode();
    }
