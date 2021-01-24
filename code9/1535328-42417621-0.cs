    public class T1
    {
        public virtual int add()
        {
            return 1;
        }
    }
    public class T2 : T1
    {       
    }
    public class T3 : T2
    {
        public override int add()
        {
            return 3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            T1 t1 = new T3();            
            ((T3)t1).add();
        }
    }
