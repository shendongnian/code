    public class SomeClass
    {
        public SomeClass(Func<IBase, string> handlerFcn)
        {
            // something gets done
            this.Handler=handlerFcn;
        }
        public Func<IBase, string> Handler { get; set; }
    }
    public static class Program
    {
        static void Main(string[] args)
        {
            var s1 = new SomeClass((x) => x.SomeMethod());
            var xt = new ExtendedClass();
            var result = s1.Handler(xt);
            // result = "yolo extended edition!"
        }
    }
