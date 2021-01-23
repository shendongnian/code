    public class Base
    {
        public string Address { get; set; }
    
        public A(string _address)
        {
            Address = _address;
        }        
    }
    
    public class A : Base
    {
        public string Name { get; set; }
    
        public A(string _name, string _address) : base(_address)
        {
            Name = _name;
        }        
    }
    
    public class B : Base
    {
        public string Name { get; set; }
    
        public B(string _name, string _address) : base(_address)
        {
            Name = _name;
        }        
    }
    
    public class C : Base
    {
        public string Name { get; set; }
    
        public C(string _name, string _address) : base(_address)
        {
            Name = _name;
        }        
    }
