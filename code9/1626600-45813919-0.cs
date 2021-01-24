    public abstract class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public Employee(string Name, string ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
	
	public class HR : Employee
    {
        public HR(string Name, string ID) : base(Name, ID)
        {
        }
        public HR() : base("No name", "No ID")
        {
        }
    }
	
    public class IT : Employee
    {
        public IT(string Name, string ID) : base(Name, ID)
        {
        }
        public IT() : base("No name", "No ID")
        {
        }
    }	
