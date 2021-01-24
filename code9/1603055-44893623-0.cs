    public static class MapperWrapper
    {
        public static Dest Map(object source)
        {
            return Mapper.Map<Dest>(source);
        }
    }
