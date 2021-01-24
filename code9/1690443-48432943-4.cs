    public class Student
        {
            public int ID { get; set; }
            public string LastName { get; set; }
            public string FirstMidName { get; set; }
            public DateTime EnrollmentDate { get; set; }
    
            public ICollection<Enrollment> Enrollments { get; set; }
        }
    
    public class Enrollment
        {
            public int EnrollmentID { get; set; }
            public int CourseID { get; set; }
            public int StudentID { get; set; }
            public Grade? Grade { get; set; }
    
            public Course Course { get; set; }
            public Student Student { get; set; }
        }
    
    public class Course
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int CourseID { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }
    
            public ICollection<Enrollment> Enrollments { get; set; }
        }
