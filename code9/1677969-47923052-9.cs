    public struct Test {
        public int Int1;
        public string String1;
    }
   
    static unsafe void Main() {
        // works, return 16 in 64bit process - 4 for int, 4 for padding, because
        // alignment of the type is the size of its largest element, which is 8
        // and 8 for string
        var s1 = Unsafe.SizeOf<Test>();
        // doesn't work even with unsafe, 
        // cannot take size of variable of managed type "Test"
        // because Test contains field of reference type (string)
        var s2 = sizeof(Test);                        
    } 
          
    
