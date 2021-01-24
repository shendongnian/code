    class A
    {    
    
        public string uname { get; set; }
        public string fname { get; set; }
        private A() {} // mark this private so that no other instances of A can be created
        public static readonly A Instance = new A();
    
    }
    class B
    {
    
        public void Main(){
            // here we are setting A.Instance, which is the only instance there is
            A.Instance.uname = "James";    
            A.Instance.fname = "Blunt"; 
        
        }
    
    }
    class C
    {
    
        public void Main()   {
            B b = new B();
            b.Main();
            string username = A.Instance.uname;
            string fistname = A.Instance.fname;
        }
    
    }
