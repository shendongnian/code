    public class A : ParentBase<A, B> {
    }
    public class B : ParentBase<B, C>, IChild<A> {
        public A Parent { get; set; }
    }
    public class C : IChild<B> {
        public B Parent { get; set; }
    }
    public class Demo {
        public static void Test() {
            var a = new A();
            var b = new B() { Parent = a };
            var c = new C() { Parent = b };
            a.Children.Add(b);
            b.Children.Add(c);
            System.Console.WriteLine(c.Parent.Parent == a);
        }
    }
