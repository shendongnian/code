    public class MyClass
    {
        public List<MyObject> MyObjects {get; set;
    }
    
    public class JsonTypeHandler: SqlMapper.ITypeHandler
    {
       public void SetValue(IDbDataParameter parameter, object value)
       {
           parameter.Value = JsonConvert.SerializeObject(value);
       }
    
       public object Parse(Type destinationType, object value)
       {
           return JsonConvert.DeserializeObject(value as string, destinationType);
       }
    }
    SqlMapper.AddTypeHandler(typeof(List<MyObject>),new JsonTypeHandler());
