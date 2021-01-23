    public class DetailsComparer : IEqualityComparer<Details>
    {
        public bool Equals(Details x, Details y)
        {
            return x.id == y.id && x.symbol == y.symbol && x.code == y.code;
        }
        public int GetHashCode(Details obj)
        {
            return (obj.id + obj.symbol + obj.code).GetHashCode();
        }
    }
