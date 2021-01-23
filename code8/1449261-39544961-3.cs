    namespace MyTypesNamespace
    {
    
        public abstract class BaseItem
        {
            public abstract bool Use(object onMyObject);
        }
        public class Door
        {
            public bool IsLocked { get; set; }
    
            public bool Open()
            {
                if (IsLocked)
                {
                    System.Console.WriteLine("Cannot open door. It is locked!");
                    return false;
                }
    
                //Some code
                System.Console.WriteLine("Door is opened!");
                return true;
            }
        }
    }
