    public class A
    {
        public A(string name, int value) 
        {
          this.Name = name;
          this.Value = value;
        }
        public string Name { get; set; }
        public int Value { get; set; }
    }
    
    public class B : A
    {
        public B(A a) : this(a.Name, a.Value, 0)
        {
        }
        public B(string name, int value, int ranking) : base(name, value)
        {
          this.Ranking = ranking;
        }
        public int Ranking { get; set; }
    }
