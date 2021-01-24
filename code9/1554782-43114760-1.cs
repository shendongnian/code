    public class ComparerFd : IEqualityComparer<FD>
    {
        public bool Equals(FD x, FD y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(FD obj)
        {
            Random rnd = new Random();
            return rnd.Next();//Or whatever way to get hash code
        }
    }
