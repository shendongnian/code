    public abstract class Foo{
        public result1 {
             get{
                 return get_field1();
             }
        }
        protected abstract int get_field1();
    }
    public class Bar : Foo{
        public const int field1 = 5;
        protected override int get_field1() { return field1;}
    }
    public class Baz : Foo{
        public const int field1 = 10;
        protected override int get_field1() { return field1;}
    }
