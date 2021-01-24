    public class Firstclass
    {
        int Pos = 1;
        int Neg = 0;
        Secondclass obj = new Secondclass();    //    this should be here
        public void Method1(string str)
        {
            if (Pos > Neg)
            {
                //Secondclass obj = new Secondclass(); -- you shouldn't create new object any time Method1 is called
                obj.Pos += 1;
                obj.Method2();
            }
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Firstclass objj = new Firstclass();    //    this should be here
            for (; ; )
            {
                string e = Console.ReadLine();
                //Firstclass objj = new Firstclass(); -- you shouldn't create new object on every iteration
                objj.Method1(e);
            }
        }
    }    
    
