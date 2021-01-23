    public class A
    {
        public A(string N)
        {
            Name = N;
        }
        public string Name { get; set; }
    
        public void GetName()
        {
            Console.Write(Name);
        }
    }
    
    public class B : A
    {
        public B(string N) : base(N)
        {
        }
    
        public new void GetName()
        {
            base.GetName();
            Console.Write(new string(Name.Reverse().ToArray()));
        }
    }
