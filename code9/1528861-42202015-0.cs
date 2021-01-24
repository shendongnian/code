    public class Program
    {
        public interface IObject
        {
            float calc();
        }
        
        public class ObjectA : IObject
        {
            public float calc() { return 5*3;}
        }
        
        public class ObjectB : IObject
        {
            public float calc() { return 8*7;}
        }
        
        private static float DoCalc(IObject obj)
        {
            return obj.calc();
        }
        
        public static void Main(string[] args)
        {
            IObject objA = new ObjectA();
            IObject objB = new ObjectB();
            
            Console.WriteLine(DoCalc(objA));
            Console.WriteLine(DoCalc(objB));
        }
    }
