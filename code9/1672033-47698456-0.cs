    public class MyBinding : Binding
    {
        public MyBinding(string path, int value) : base(path) { } //primary
        public MyBinding(string path, bool value) : base(path) { } //secondary
    }
