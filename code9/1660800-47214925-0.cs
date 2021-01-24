    //Models
    public class Course
    {
        [Key]
        public int Id { get; set; }
        //more properties here
         public virtual /*important*/ ICollection<Student> studs { get; set; }
     }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        //more properties here
         public virtual /*important*/ ICollection<Course> courses { get; set; }
     }
     //Controller
    var stud = _dbContext.studs.Where(s => s.Id == /*param*/id).FirstOrDefault();
    var courses = stud.courses.ToList();
