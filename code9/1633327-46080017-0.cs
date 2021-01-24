    public interface IBaseInterface
    {
       int ID { get; }
    }
    
    public class Impl1 : IBaseInterface 
    {
        public int ID { get; internal set; }
        
        public int Price {get; set;}
    }
    
    public class Impl2 : IBaseInterface 
    {
        public int ID { get { return 0;} }
        
        public int Subscription {get; set;}
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            IBaseInterface obj1 = new Impl1();
            SetProperty(obj1, "ID", 100);
            Console.WriteLine("Object1 Id is {0}", obj1.ID); 
            
            IBaseInterface obj2 = new Impl2();
            SetProperty(obj2, "ID", 500);
            Console.WriteLine("Object2 Id is {0}", obj2.ID); 
        }
        
        private static void SetProperty(IBaseInterface obj, string propertyName, object id){
            if(obj.GetType().GetProperty(propertyName).CanWrite) {
                obj.GetType().GetProperty(propertyName).SetValue(obj, id); 
                Console.WriteLine("CanWrite property '{0}' : {1}" , propertyName, obj.GetType().GetProperty(propertyName).CanWrite); 
            }
        }
    }
