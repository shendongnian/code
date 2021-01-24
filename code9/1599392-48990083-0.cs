    public class CustomDiscriminatorConvention : ConventionBase, IClassMapConvention
    {
        public void Apply(BsonClassMap classMap)
        {
            Type type = classMap.ClassType;
            if (type.IsClass
                && type != typeof(string)
                && type != typeof(object)
                && !type.IsAbstract)
            {
                classMap.SetDiscriminator(GetCustomDiscriminatorFor(type));
            }
        }
    }
