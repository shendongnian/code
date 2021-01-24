    public class MyBaseClass
    {
        public virtual object MyMethod() { return null; }
    }
    public class MyIntClass : MyBaseClass
    {
        public override object MyMethod() { return (object)1; }
    }
    
    public class MyListClass : MyBaseClass
    {
        public override object MyMethod() { return (object)new List<string>(); }
    }
