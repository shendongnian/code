    [assembly: Xamarin.Forms.Dependency(typeof(Foo))]
    public class Foo : IFoo
    {
    public IBar Bar { get; set; }
     public Foo(IBar bar)
     {
        Bar = bar;
     }
    }
    [assembly: Xamarin.Forms.Dependency(typeof(Bar))]    
    public class Bar : IBar
    { }
   
