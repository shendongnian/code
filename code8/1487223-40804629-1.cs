    class MyClassB : ICloneable {
        public MyClassA paramClassA;
        public int Height { get; set; }
    
        public object Clone(){
            return new MyClassB 
            {
                this.Height;
                this.MyClassA;
            };
        }
    }
