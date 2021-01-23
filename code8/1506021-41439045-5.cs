    public class NotSoGenericClass
    {
        public GenericClass(IHasAddress obj)
        {
            DynamicObject = obj;
        }
    
        public IHasAddress DynamicObject { get; set; }    
    }
