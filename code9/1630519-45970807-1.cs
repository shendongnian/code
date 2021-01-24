    public class Employee
    {
        public int ID { get; set; }
    }
    public class EmpTypeOne : Employee
    {
        public string Name { get; set; }
        public EmpTypeOne(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
    public class EmpTypeTwo : Employee
    {
        public string Name { get; set; }
        public string City { get; set; }
        public EmpTypeTwo(int id, string name, string city)
        {
            ID = id;
            Name = name;
            City = city;
        }
    }
