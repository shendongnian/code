    public class ExceptionContext<TEx> 
        where TEx : Exception
    {
        public <TEx> Ex{get; set;}
    }
    
    var context = new ExceptionContext<MyCustomException>(){ Ex = new MyCustomException (); }
    var factory = new FooFactory();
    var fooInstance = factory.Create(context.Ex);
