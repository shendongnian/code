    class Bar
    {
        public int Value;
        public Bar(int value)
        {
            this.value = value;
        }
    }    
    class Foo : ICloneable
    {
        public String Id;
        public Bar MyBar;
        public Foo(int value) {
            this.MyBar = new Bar(value);
        }
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
