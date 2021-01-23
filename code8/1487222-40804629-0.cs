    class MyClassB{
        public MyClassA paramClassA;
        public int Height { get; set; }
    
        public MyClassB(MyClassB param){
            this.Heigth = param.Height;
            this.MyClassA = param.MyClassA;
        }
    }
