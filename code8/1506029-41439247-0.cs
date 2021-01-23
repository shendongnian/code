    // the generic class
    public class GenericClass<T> where T: IABC
    {
        public GenericClass(T obj)
        {
            DynamicObject = obj;
        }
        public IABC DynamicObject { get; set; }    
        public T GetPropertyValue<T>(string propertyName)
        {
            var obj = GetType().GetProperty(propertyName).GetValue(this);
            return (T)Convert.ChangeType(obj, typeof(T))
        }
    }
    A objA = new A("Mohit", "India");
    GenericClass<A> objGenericClass = new GenericClass<A>(objA);
    var address = objGenericClass.GetPropertyValue<string>("address");
