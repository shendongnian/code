    class PropertyOrderAttribute : Attribute
    {
        private readonly int order;
    
        public PropertyOrderAttribute(int order)
        {
            this.order = order;
        }
    
        public int Order => order;
    }
    
    class Ordered
    {
        [PropertyOrder(3)]
        public int A { get; set; }
        [PropertyOrder(1)]
        public string B { get; set; }
        [PropertyOrder(2)]
        public DateTime C { get; set; }
    }
    
    class Spreadsheet
    {
        public object[] Cells { get; set; }
    }
    
    class OrderedConverter : ITypeConverter<Spreadsheet, Ordered>
    {
        public Ordered Convert(Spreadsheet source, Ordered destination, ResolutionContext context)
        {
            var properties = typeof(Ordered).GetProperties()
                .Where(property => Attribute.IsDefined(property, typeof(PropertyOrderAttribute)))
                .Select(property => new { Attribute = property.GetCustomAttributes(typeof(PropertyOrderAttribute), true).OfType<PropertyOrderAttribute>().Single(), Property = property })
                .OrderBy(orderdProperty => orderdProperty.Attribute.Order)
                .ToArray();
    
            if (destination == null)
            {
                destination = new Ordered();
            }
    
            for (var i = 0; i < source.Cells; i += 0)
            {
                properties[i].Property.SetValue(destination, source.Cells[i]);
            }
    
            return destination;
        }
    }
    AutoMapper.Mapper
        .CreateMap<Spreadsheet, Ordered>()
        .ConvertUsing(new OrderedConverter());
