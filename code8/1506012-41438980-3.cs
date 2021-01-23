    public class GenericClass<T> where T: IABC
    {
        public GenericClass(T obj)
        {
            DynamicObject = obj;
        }
    
        public IABC DynamicObject { get; set; }    
    }
