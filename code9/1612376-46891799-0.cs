    public static class Extenstions
    {
        public static IQueryable<TDestination> ProjectToExt<TDestination, TSource>(this IQueryable<TSource> @this,
            IMapper mapper)
        {
            return mapper.Map<IEnumerable<TDestination>>(@this).AsQueryable();
        }
    }
