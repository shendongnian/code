    //Models
    public class Course
    {
        [Key]
        public int Id { get; set; }
        //more properties here
         public virtual /*important*/ ICollection<StudentCourse> studs { get; set; }
     }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        //more properties here
         public virtual /*important*/ ICollection<StudentCourse> courses { get; set; }
     }
    [Table("inscribe")]
    public class StudentCourse
    {
        [Key, Column(Order = 0)]
        public int StudentId {get; set'}
        [Key, Column(Order = 1)]
        public int CourseId {get; set'}
        //extra properties
        [ForeignKey("StudentId")]
        public virtual Student stud { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course course { get; set; }
    }
    //Controller
    var courses = _dbContext.courses.Where(c/*c is "link"*/ => c.Student/*StudentCourse prop*/.Any(s/*link again*/ => s.StudentId == someId/*param*/));//again courses
    
