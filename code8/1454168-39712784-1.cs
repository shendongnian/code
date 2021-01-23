    public class Base
    {
        public virtual void print()
        {
            Console.WriteLine("this is a BASE method");
        }
    }
    public class Derived : Base
    {
        public override void print()
        {
            Console.WriteLine("this is a DERIVED method");
        }
    }
    static void Main()
    {
        List<Base> lists = new List<Base>();
        lists.Add(new Base());
        lists.Add(new Derived());
        foreach (var a in lists)
        {
            a.print();
        }
        Console.ReadLine();
    }
