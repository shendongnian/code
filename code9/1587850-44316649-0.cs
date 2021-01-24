    public class C {
        private class D {  }
        //  Nobody outside C can know about D, so this is forbidden. 
        public D Property { get; set; }
        //  But this is OK, because object is public. 
        private D _d = new D();
        public Object Property2 => _d;
    }
