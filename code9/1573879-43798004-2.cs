    `public class A
    {
        public virtual void print() {Console.WriteLine("a"); }
    }
    public class B:A
    {
        public override void print() 
        {
            base.print();
            Console.WriteLine("b"); 
        }
    }`
