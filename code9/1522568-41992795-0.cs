    public static class IMapperExtensions
    {
        public static IContract GetSingle(this IMapper mapper, params object[] objects)
        {
            return mapper.Get(objects).FirstOrDefault();
        }
    }
