    public class Employee
    {
        public int Key { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName => FirstName + " " + SecondName;
    
        public Employee(int key, string first = null, string second = null)
        {
            Key = key;
            FirstName = first;
            SecondName = second;
        }
    }
