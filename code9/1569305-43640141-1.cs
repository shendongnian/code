    public class ExceptionContext<TEx> 
        where TEx : Exception
    {
        public ExceptionContext(TEx exception)
        {
            this.Ex = exception;
        {
        public <TEx> Ex{get; set;}
    }
    
    var context = new ExceptionContext(new MyCustomException());
    var factory = new FooFactory();
    var fooInstance = factory.Create(context.Ex);
