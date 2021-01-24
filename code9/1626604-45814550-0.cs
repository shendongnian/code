    public abstract class Employee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Employee(string Name, int ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
    public class HR : Employee
    {
        public HR() : base(null, 0) { } // default constructor is needed for serialization/deserialization
        public HR(string Name, int ID) : base(Name, ID) { }
    }
    public class IT : Employee
    {
        public IT() : base(null, 0) { }
        public IT(string Name, int ID) : base(Name, ID) { }
    }
    public class Group
    {
        [XmlArray("Employee")]
        [XmlArrayItem("HR",typeof(HR))]
        [XmlArrayItem("IT",typeof(IT))]
        public List<Employee> list { get; set; }
        public Group()
        {
            list = new List<Employee>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Group grp = new Group();
            grp.list.Add(new HR("Name HR", 1));
            grp.list.Add(new IT("Name IT", 2));
            XmlSerializer ser = new XmlSerializer(typeof(Group));
            ser.Serialize(Console.Out, grp);
        }
    }
