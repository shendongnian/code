    public class A {
        public int X {get; set;}
    }
    public class B : A{
        B : base() {}
    }
    ...
    var a = new B();
    a.X = 24;
