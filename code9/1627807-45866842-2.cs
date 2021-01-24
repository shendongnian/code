    abstract class Worker<T> where T : Worker<T>
    {
        protected static string name;
    
        public static IEnumerable<T> GetAll() 
        {
            Console.WriteLine(name);
            return Enumerable.Empty<T>();
        }
    }
    
    class Manager : Worker<Manager>
    {
        static Manager()
        {
            name = "Manager";
        }
    }
    
    class Employee : Worker<Employee>
    {
        static Employee()
        {
            name = "Employee";
        }
    }
