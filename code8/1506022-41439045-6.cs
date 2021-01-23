    public class GenericClass<T> where T : IHasAddress  // just for the sake of generics
    {
        public GenericClass(T obj)
        {
            DynamicObject = obj;
        }
    
        public T DynamicObject { get; set; }    
    }
