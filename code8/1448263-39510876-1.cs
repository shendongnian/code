    public class Base 
    {
        public void Do() 
        {
            Console.WriteLine("Base");
        }
    }
    public class Sub : Base
    {
        public new void Do() 
        {
            Console.WriteLine("Sub");
        }
    }
    public class Program 
    {
        public static void Main(string[] args) 
        {
            Sub sub = new Sub();
            Base base = sub;
            sub.Do(); //prints Sub
            base.Do(); //prints Base, even though it is the same object.
        }
    }
