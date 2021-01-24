    public static class NullExtensions
    {
        public static bool ExactlyNull(this object toCheck)
        {
            return ReferenceEquals(toCheck, null);
        }
    }
