    public class CustomResolver : IValueResolver<Source, Destination, Dictionary<string, object>>
    {
        public Dictionary<string, object> Resolve(Source source, Destination destination, Dictionary<string, object> destMember, ResolutionContext context)
        {
            destMember = new Dictionary<string, object>();
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceProperties = typeof(Source).GetProperties(flags);
            foreach (var property in sourceProperties)
            {
                if (typeof(Destination).GetProperty(property.Name, flags) == null)
                {
                    destMember.Add(property.Name, property.GetValue(source));
                }
            }
            return destMember;
        }
    }
