    public abstract class A
    {
        public string Name { get { return GetName(); } }
        
        public virtual string GetName()
        {
            return this.Name.ToString();
        }
        protected abstract void SomeMethod();
    }
    public class B : A
    {
        public B() : base()
        {
            SomeMethod();
        }
        
        public new string Name { get; set; }
        
        public override string GetName()
        {
            return Name;
        }
        
        protected override void SomeMethod()
        {
            this.Name = "Ayberk";
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            B b = new B();
            Console.WriteLine(b.GetName());
        }
    }
