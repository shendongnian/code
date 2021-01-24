    public class ParentsDetail
    {
        public string Parent_Name { get; set; }
        public string Gender { get; set; }
    }
    public class StudentInfo
    {
        public string RegNo { get; set; }
        public string ID { get; set; }
        public List<ParentsDetail> parentsDetails { get; set; }
        public string Student_Name { get; set; }
        public string Student_Status { get; set; }
    }
    public class RootObject
    {
        public string status { get; set; }
        public StudentInfo studentInfo { get; set; }
    }
