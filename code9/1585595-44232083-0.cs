    public class Employee
    {
        public string lastName {get;set;}
        public string firstName {get;set;}
        public override string ToString()
        {
            return lastName + ", " + firstName;
        }
    }
