    public class Course
    {
        public int CourseID {get; set;}
        public string CourseName {get; set;}
       public virtual ICollection<CoursePersons> Courses { get; set; }
    }
    public class Person
    {
       public int PersonID {get; set;}
       public virtual ICollection<PersonCourse> Courses { get; set; }
    }
    public class PersonCourseMap 
    {
      public int PersonID {get; set;}
      public int CourseID {get; set;}
      public virtual ICollection<Person> Persons { get; set; }
      public virtual ICollection<Course> Courses { get; set; }
    }
