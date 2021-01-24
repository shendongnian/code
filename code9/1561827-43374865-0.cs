    static void Main(string[] args)
    {
        Company company = // Whatever you do to retrieve your company
        foreach (var employee in company.Employees)
        {
            Console.WriteLine(employee.Person.Name);
        }
    }
    public class Company
    {
        public List<Employee> Employees { get; set; }
    }
    public class Employee
    {
        public int DepartmentId { get; set; }
        public Person Person { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
    }
