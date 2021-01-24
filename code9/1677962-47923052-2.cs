    public struct Test {
        public int Int1;
    }
    static void Main() {
        // works
        var s1 = Unsafe.SizeOf<Test>();
        // doesn't work, need to mark method with "unsafe"
        var s2 = sizeof(Test);            
    }
