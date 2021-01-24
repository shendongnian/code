    public class Program
    {
        public static void Main()
        {
            Developer developer = new Developer();
            PrintSalaryWithHiding(developer);
            PrintSalaryWithOverriding(developer);
        }
        
        public static void PrintSalaryWithHiding(Employee employee)
        {
            Console.WriteLine("Salary (with hiding): " + employee.SalaryWithHiding);
        }
        public static void PrintSalaryWithOverriding(Employee employee)
        {
            Console.WriteLine("Salary (with overriding): " + employee.SalaryWithOverriding);
        }
    }
