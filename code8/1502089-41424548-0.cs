    public TopClass<T> where T : GenericType{
    }
 
    public MiddleClass<T> : TopClass<T> where T : GenericType{
    }
    public BottomClass : MiddleClass<SpecificType>{
    }
