    public class MyClass
    {
        public int Value {get;set;}
        public override int GetHashCode() { return Value.GetHashCode(); }
        public override bool Equals(object other){return ((MyClass)other).Value.Equals(Value); }
    }
