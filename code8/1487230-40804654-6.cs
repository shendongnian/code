    class MyClassB{
        public MyClassA paramClassA;
        public int Height { get; set; }
        public MyClassB(MyClassB param){
            Height = param.Height;
            paramClassA = new MyClassA();
            if (param.paramClassA != null)
            {
              paramClassA.Width = param.paramClassA.Width;
            }
        }
    }
