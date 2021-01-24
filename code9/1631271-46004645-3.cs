    public class Student
    {
        public int StudentId {get;set;}
        public string StudentFirstName {get;set;}
        public string StudentLastName {get;set;}
        public virtual ICollection<StudentSchedule> StudentSchedules {get;set;}
    }
    class StudentSchedule
    {
        public int StudentScheduleId {get;set;}
        public int StudentId {get;set;}
        public string ClassName {get;set;}
        public virtual Student Student {get;set;}
    }
