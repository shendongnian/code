    public class MyRequest 
    {
        [TypeConverter(typeof(EnumerableTypeConverter<string>))]
        public IEnumerable<string> Names {get;set;}
        [TypeConverter(typeof(EnumerableTypeConverter<Guid>))]
        public IEnumerable<Guid> Ids {get;set;}
    }
