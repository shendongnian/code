    interface I1<PlaceHolder> where PlaceHolder : new()  { }
    
    class ActualClass {}
    
    class C1 : I1<ActualClass> 
    {
       public void Method() { ActualClass @class = new ActualClass();}
    }
    
    interface IFactory<PlaceHolder> where PlaceHolder : new() 
    {
       I1<PlaceHolder> Create();  
    } 
    
    class ConcreteFactory : IFactory<ActualClass>
    {
       public I1<ActualClass> Create() { return new C1(); }
    }
