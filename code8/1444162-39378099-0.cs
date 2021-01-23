     public class Employee
    {
        public int salary { get; set; }
    
    }
    public class Manager : Employee
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Manager man = new Manager();
            System.Object emp = (object) man;
            Console.WriteLine(emp.GetType());
        }
    }
