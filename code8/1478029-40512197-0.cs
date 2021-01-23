    public class BaseClass{
        public virtual int x {get {return 1;}}
    
        public static void print(BaseClass objClass)
        {
            Console.WriteLine(objClass.GetType().Name + " " + objClass.x); 
        }
    }
    
    public class DerivedClass : BaseClass{
        public override int x {get {return 2;}}
    }
