    This can cause unfortunate situations:
        public interface I1<T>
        {
            string Foo(T fooable);
        }
        public class C1: I1<int>
        {
            public string Foo(int i) => "C1.Foo called";
        }
        public class C2: C1, I1<double>
        {
            public string Foo(double d) => "C2.Foo called";
        }
    And now:
        var c2 = new C2();
        Console.WriteLine(c2.Foo(1)); //C2.Foo(double d) is called,
                                            //not C1.Foo(int i)!
     So be careful! 
        
