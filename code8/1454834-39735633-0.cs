    interface I1<PlaceHolder>
    {        
    }
    class C1<ActualClass> : I1<ActualClass> where ActualClass: new()
    {
        public void Method()
        {
            ActualClass c = new ActualClass();
        }
    }
    
    interface IFactory<PlaceHolder> where PlaceHolder : new()
    {
        I1<PlaceHolder> Create<PlaceHolder>(); 
            
    }
    class ConcreteFactory<ActualClass>  where ActualClass : new()
    {
        public I1<ActualClass> Create()
        {
            return new C1<ActualClass>(); 
        }
    }
