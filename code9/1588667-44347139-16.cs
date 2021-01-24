    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return LastName + ", " + FirstName;
        }
    }
