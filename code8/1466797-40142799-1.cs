    public class RandomCustomization<T> : ICustomization
    {
        private readonly Type _defaultType;
        private readonly Type[] _types;
        public RandomCustomization(Type defaultType, params Type[] types)
        {
            _defaultType = defaultType;
            _types = types;
        }
        public void Customize(IFixture fixture)
        {
            fixture.Customize<T>(v => v.FromFactory(new RandomFactory(_defaultType, _types)));
        }
    }
    public class RandomFactory : ISpecimenBuilder
    {
        private readonly Type _defaultType;
        private readonly Type[] _types;
        private readonly Random _ran = new Random();
        public RandomFactory(Type defaultType, params Type[] types)
        {
            _defaultType = defaultType;
            _types = defaultType.Concat(types).ToArray();
        }
        public object Create(object request, ISpecimenContext context)
        {
            var which = _types[_ran.Next() % _types.Length];
            var toret = context.Resolve(which);
            if (toret == null || toret is OmitSpecimen)
            {
                toret = context.Resolve(_defaultType);
            }
            return toret;
        }
    }
