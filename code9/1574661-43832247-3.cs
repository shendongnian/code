    public class Program
    {
        public static void Main()
        {
            Developer developer = new Developer();
            Console.WriteLine("Developer salary when declared as developer: " + developer.SalaryWithHiding);
            // these are the same object!
            Employee employee = developer;		
            Console.WriteLine("Developer salary when declared as employee: " + employee.SalaryWithHiding);
        }
    }
