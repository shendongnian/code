    public class Student
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public virtual ICollection<StudentSchedule> Schedules {get;set;}
    }
    class StudentSchedule
    {
        public int Id {get;set;}
        public int StudentId {get;set;}
        public string ClassName {get;set;}
        public virtual Student Student {get;set;}
    }
