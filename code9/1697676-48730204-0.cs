    public class Person
    {
        public int Id { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public Person Person { get; set; }
    }
    var person = new Person { BirthDate = DateTime.Now };
    var employee = new Employee
    {
        Person = person,
        HireDate = DateTime.Now
    };
    context.Employees.Add(employee);
    context.SaveChanges();
