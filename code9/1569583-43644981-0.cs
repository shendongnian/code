    public class FooValidator : AbstractValidator<Foo>
    {
       public FooValidator()
       {
           CascadeMode = CascadeMode.StopOnFirstFailure;
           // rules here
       }
    }
