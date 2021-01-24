    public class Department
    { 
        public string Name { get; set; }
        [MustHaveMoreThanOneItem(typeof(Employee))]
        public IList<Employee> { get; set; }
    }
