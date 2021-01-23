    public class Foo
    {
        public int Bar { get; set; }
        public void Deconstruct(out int bar)
        {
            bar = Bar;
        }
    }
    var foo = new Foo { Bar = 3 };
    var (num) = foo; //num is an int with a value of 3
    var obj = foo; //obj is a Foo object with the same reference as foo
