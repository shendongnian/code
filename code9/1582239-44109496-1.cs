    public sealed class MyMethodInfo {
        public int A { get; set; } = 0;
        public int B { get; set; } = 1;
    }
    
    public void MyMethod(MyMethodInfo info) {
    }
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This method is obsolete, use MyMethod(MyMethodInfo) instead.")]
    public void MyMethod(int a = 0) {
        MyMethod(new MyMethodInfo { A = a });
    }
