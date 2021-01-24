    public class A
    {
        public A(string name, int value) 
        {
          this.Name = name;
          this.Value = value;
        }
        public virtual string Name { get; set; }
        public virtual int Value { get; set; }
    }
    
    public class B
    {
        private A a;
        public B(A a)
        {
          this.a = a;
        }
        public int Ranking { get; set; }
        public int Value 
        { 
          get { return this.a.Value; }
          set { this.a.Value = value; }
        }
        public string Name 
        { 
          get { return this.a.Name; } 
          set { this.a.Name = value; }
        }  
    }
