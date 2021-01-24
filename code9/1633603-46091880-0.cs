    public class Student
    {
        public string Name { get; set; }
        public string number { get; set; }
        public string place { get; set; }
    }
    
    public class RootObject
    {
        public string count { get; set; }
        public List<Student> data { get; set; }
    }
