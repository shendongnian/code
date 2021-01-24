    public class Foo
    {
        public virtual double Price { get; set; }
    }
    public class Bar : Foo
    {
        [Obsolete]
        public override double Price { get; set; }
    }
    Bar b = new Bar();
    b.Price = 1; // warning
    Foo f = new Bar();
    f.Price = 1; // no warning :(
