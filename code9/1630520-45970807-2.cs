    public class Employee
    {
        public int ID { get; set; }
        public virtual void DisplayInfo()
        {
        }
    }
    public class EmpTypeOne : Employee
    {
        public string Name { get; set; }
        public EmpTypeOne(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("I'm a Type A Employee");
            Console.WriteLine("ID : {0}, Name : {1}", ID, Name);
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
        public override void DisplayInfo()
        {
            Console.WriteLine("I'm a Type B Employee");
            Console.WriteLine("ID : {0}, Name : {1}, City : {2}", ID, Name, City);
        }
    }
    public static void Main()
    {
        List<Employee> emps = new List<Employee>();
        emps.Add(new EmpTypeOne(1, "Tim"));
        emps.Add(new EmpTypeTwo(2, "Jane", "Chicago"));
        emps[0].DisplayInfo();
        Console.WriteLine();
        emps[1].DisplayInfo();
        Console.ReadLine();
    }
