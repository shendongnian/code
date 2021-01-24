    This can cause unfortunate situations:
        public interface I1<T>
        {
            string Foo(T fooable);
        }
        public class C1: I1<string>
        {
            public string Foo(string s) => "C1.Foo called";
        }
        public class C2: C1, I1<object>
        {
            public string Foo(object s) => "C2.Foo called";
        }
    And now:
        var c2 = new C2();
        Console.WriteLine(c2.Foo("Hello")); //C2.Foo(object o) is called,
                                            //not C1.Foo(string s)!
     So be careful! 
        
