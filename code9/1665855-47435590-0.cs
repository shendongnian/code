    public class CustomResolver : ITypeConverter<List<object>, List<object>>
    {
        public List<object> Convert(List<object> source, List<object> destination, ResolutionContext context)
        {
            var objects = new List<object>();
            foreach (var obj in source)
            {
                var destinationType = context.ConfigurationProvider.GetAllTypeMaps().First(x => x.SourceType == obj.GetType()).DestinationType;
                var target = context.Mapper.Map(obj, obj.GetType(), destinationType);
                objects.Add(target);
            }
            return objects;
        }
    }
