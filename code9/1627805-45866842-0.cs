    abstract class Worker
    {
        public static IEnumerable<T> GetAll<T>() where T : Worker
        {
            //your code
        }
    }
    
    class Manager : Worker
    {
    }
    
    class Employee : Worker
    {
    }
