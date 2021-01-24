    public class MyBaseClass<T>
    {
        public virtual T MyMethod() { return default(t); }
    }
    public class MyIntClass : MyBaseClass<int>
    {
        public override int MyMethod() { return 1; }
    }
    
    public class MyListClass : MyBaseClass<List<string>>
    {
        public override List<string>> MyMethod() { return new List<string>(); }
    }
