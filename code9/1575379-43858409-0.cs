    public enum MyObject
    {
        Type1,
        Type2
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            MyObject foo = MyObject.Type1;
            switch (foo) {
                case MyObject.Type1:
                    Console.WriteLine("myobject's type1");
                break;
                case MyObject.Type2:
                    Console.WriteLine("myobject's type2");
                    break;
            }
        }
    }
