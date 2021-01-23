    public interface IStudent
    {
        int StudentId { get; set; }
        string StudentName { get; set; }
        string Address { get; set; }
    }
    public class Student : IStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
    }
