    interface IBar { /* common properties */ }
    interface IFoo : IBar
    {
        double Price { get; set; }
    }
    class Bar : IBar 
    {
         public long PriceA { get; set;}
         public long PriceB { get; set;}
    }
    class Foo : IFoo { ... }
