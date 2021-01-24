    struct B
    {
        public int x;
    }
    
    struct A
    {
        public B b;
        public int x {
            get { return b.x; }
            set { b.x = value; }
        }
    }
    
    }
    
    var a = new A();
    
    a.b.x = 1;
    a.x = 1;
