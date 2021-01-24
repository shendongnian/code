    public class Student
        {
            public Student()
            {
                Courses = new HashSet<Course>();
            }
            [Key]
            public int Id { get; set; }
    
            [Required]
            [Display(Name = "Student Name")]
            public string Name { get; set; }
          
            public virtual ICollection<Course> Courses { get; set; }
        }
    
    public class Course
        {
            public Course()
            {
                Students = new HashSet<Student>();
            }
            [Key]
            public int Id { get; set; }
    
            [Required]
            [Display(Name = "Course Name")]
            public string Name { get; set; }
            public virtual ICollection<Student> Students { get; set; }
    
        }
