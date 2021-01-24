    public struct Test {
        public int Int1;
        public string String1;
    }
   
    static unsafe void Main() {
        // works
        var s1 = Unsafe.SizeOf<Test>();
        // doesn't work even with unsafe, 
        // cannot take size of variable of managed type "Test"
        // because Test contains field of reference type (string)
        var s2 = sizeof(Test);                        
    } 
          
    
