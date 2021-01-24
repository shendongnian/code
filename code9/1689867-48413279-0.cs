    public class Student
    {
        public Student()
        {
            StudentDoc = new Document();
        }
       public Document StudentDoc { get; set; }
    }
    public class Document
    {
        public Document()
        {
            StudentBio = new StudentBio();
        }
        public StudentBio StudentBio { get; set; }
    }
    public class StudentBio
    {
        public StudentBio()
        {
            StudentCourse = new StudentCourse();
        }
        public StudentCourse StudentCourse { get; set; }
    }
    public class StudentCourse
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
