    public abstract class Base {
        protected Environment Environment { get; set; }
         public Init(Environment NewEnvironment) {
            Environment = NewEnvironment;
        }
    }
    
    public A : Base{ 
        public void UseEnvironment() {
         }
    }
    public B : Base{ 
        public void UseEnvironment() {
         }
    }
