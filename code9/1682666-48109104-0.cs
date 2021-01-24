    class CustomAttribute: Attribute 
    {
        public Type[] Included { get; set; }
        public Type[] Excluded { get; set; }
    }
    [CustomAttribute(Included = new Type[] {typeof(ComponentA)}, Excluded = new 
    Type[] {typeof(ComponentB)} )]  
    class Processor 
    {
       // something here
    }
