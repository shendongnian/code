    class Program
    {
        static void Main(string[] args)
        {
            var b = new Base
            {
                IntOnBase = 1
            };
            var overlay = new Overlay();
            overlay.Base = b;
            var super = overlay.Super;
            var intValue = super.IntOnBase;
            super.StringOnSuper = 8;
            var stringValue = super.StringOnSuper;
            System.Diagnostics.Debug.WriteLine(stringValue);
            super.NoProblem();
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct Overlay
    {
        [FieldOffset(0)]
        public Super Super;
        [FieldOffset(0)]
        public Base Base;
    }
    public class NewClass
    {
        public string cat { get; set; }
    }
    public class Super : Base
    {
        private Super imNull;
        public Super()
        {
           // imNull = new Super();
            System.Diagnostics.Debug.WriteLine("well i get initialized...");
        }
        public int StringOnSuper { get; set; }
        public void NoProblem()
        {
            System.Diagnostics.Debug.Write("You know, I am really a " + this.GetType().Name + " kind of class. But my super is " + imNull.ToString() );
        }
    }
    public class Base
    {
        public int IntOnBase { get; set; }
    }
