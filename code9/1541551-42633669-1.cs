    public class Employee
    {
        ...
        public virtual ICollection<Region> Regions { get; set; }
    }
    public class Region
    {
        ...
        public virtual ICollection<Employee> Employees { get; set; }
    }
