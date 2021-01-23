    public class GenericClass<T> where T : Base
    {
        public GenericClass(T obj)
        {
            DynamicObject = obj;
        }
    
        public T DynamicObject { get; set; }
    
    
        public void UseClassPro()
        {
            Console.WriteLine("Address " + DynamicObject.Address);//Compiles now
        } 
    }
