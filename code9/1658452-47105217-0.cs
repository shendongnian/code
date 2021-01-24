    public class SubClass : BaseClass
    {
        private const string _name = "flip flops";
        private static readonly Color _color = Color.FromArgb(255, 0, 255, 255);
        private static readonly string[] _info = new string[] { "a", "b", "c" };
        private static readonly OtherClass[] _otherClasses = new otherClass[] {
            new OtherClass("hard"),
            new OtherClass("coded"),
            new OtherClass("data") 
        };
        public override string name { get { return _name; } }
        public override Color color { get { return _color; } }
        public override string[] info { get { return _info; } }
        public override OtherClass[] otherClasses { get { return _otherClasses; } }
    }
