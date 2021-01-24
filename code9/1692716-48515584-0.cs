    public class Student
    {
        public string Id { get; set; }
        public string Student { get; set; }
        public string Grade { get; set; }
    }
    public class RequestModel
    {
        public List<Student> data { get; set; }
        public string Token { get; set; }
        public List<string> header { get; set; }
        public int Rowcount { get; set; }
    }
