    public class Student
    {
        public string regNo { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Student(string regno, string firstname, string lastname)
        {
            regNo = regno;
            firstName = firstname;
            lastName = lastname;
        }
    }
