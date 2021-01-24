    public class Foo
    {
        public virtual int result1 { get; }
    }
    public class Bar : Foo
    {
        public const int field1 = 5;
        public override int result1
        {
            get { return field1; }
        }
    }
    public class Baz : Foo
    {
        public const int field1 = 10;
        public override int result1
        {
            get { return field1; }
        }
    }
