     class Program
        {
            static void Main(string[] args)
            {
                C1 o1 = new C1();
                C2 o2 = new C2();
                Console.WriteLine(o1.M1() + " " + o1.M2() + " " + o2.M1() + " " + ((C2)o2).M2() + "\n");
                Console.ReadKey();
            }
        }
    
        public class C1
        {
            public C1()
            {
            }
            public virtual int M1()
            {
                return 1;
            }
            public  int M2()
            {
                return M1();
    
            }
        }
    
        public class C2 : C1
        {
            public C2()
            {
            }
            public override int M1()
            {
                return 2;
            }
        }
