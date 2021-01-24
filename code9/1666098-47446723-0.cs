    internal interface IFoo { }
    
    internal class Boo : IFoo
    {
        [Import] public string SomeString;
    
        [ImportingConstructor]
        public Boo(int someInt) { }
    }
    
    internal class Moo : IFoo
    {
        [Import] public float SomeFloat;
    }
