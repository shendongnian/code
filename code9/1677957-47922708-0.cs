    public static class IDbSetExtensions
    {
        public static ICollection<T> FindMany( this IDbSet<T> @this, IEnumerable<object[]> keys )
        {
            return keys.Select( key => @this.Find( key ) ).ToList();
        }
    }
