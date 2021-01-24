    public static class ArrayListExtensions
    {
        public static ArrayList Intersect(this ArrayList source, ArrayList other)
            => new ArrayList(source.ToArray().Intersect(other.ToArray()).ToArray());
    }
