    public class Base
    {
        public override string ToString()
        {
            return "this is a BASE method";
        }
    }
    public class Derived : Base
    {
        public override string ToString()
        {
            return "this is a DERIVED method";
        }
    }
    class Program
    {
        static void Main()
        {
            List<object> lists = new List<object>();
            lists.Add(new Base());
            lists.Add(new Derived());
            foreach (var a in lists)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();
        }
    }
