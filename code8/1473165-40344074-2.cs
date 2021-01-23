    public class Options
    {
        public readonly string x;
        public readonly string y;
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }
