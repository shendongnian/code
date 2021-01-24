    public class IdGeneratorClassMapConvention : ConventionBase, IClassMapConvention
    {
        public void Apply(BsonClassMap classMap)
        {
                map.AutoMap();
                map.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
        }
    }
