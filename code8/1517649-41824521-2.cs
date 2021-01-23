    [Test]
    public void Mapping_Profile_Must_Not_Habe_Unmapped_Properties()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TestProfile>();
        });
        var mapper = config.CreateMapper();
        var unmappedProperties = GetUnmappedSimpleProperties(mapper);
        Assert.AreEqual(unmappedProperties.Count, 0);
    }
    private List<UnmappedProperty> GetUnmappedSimpleProperties(IMapper mapper)
    {
        return mapper.ConfigurationProvider.GetAllTypeMaps()
            .SelectMany(m => m.GetUnmappedPropertyNames()
            .Where(x =>
            {
                var z = m.DestinationType.GetProperty(x);
                return z != null && (z.PropertyType.IsValueType || z.PropertyType.IsArray || z.PropertyType == typeof(string));
            })
            
            .Select(n => new UnmappedProperty
            {
                DestinationTypeName = m.DestinationType.Name,
                PropertyName = n,
                SourceTypeName = m.SourceType.Name
            })).ToList();
    }
    internal class UnmappedProperty
    {
        public string PropertyName { get; set; }
        public string DestinationTypeName { get; set; }
        public string SourceTypeName { get; set; }
        public override string ToString()
        {
            return $"{this.PropertyName}: {this.SourceTypeName}->{this.DestinationTypeName}";
        }
    }
