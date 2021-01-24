    public class Course
    {
        public int CourseID {get; set;}
        public string CourseName {get; set;}
        public virtual ICollection<Person> Person {get; set}
    }
    
    public class Person
    {
       public int PersonID {get; set;}
       public virtual ICollection<Course> Course {get; set;}
    }
    using System.ComponentModel.DataAnnotation.Schema;
    public class PersonCouseMap 
    {
       [ForeignKey("Person")]
       public int PersonID {get; set;}
       [ForeignKey("Course")]
       public int CourseID {get; set;}
    
       public virtual ICollection<Person> Person {get; set;}
       public virtual ICollection<Course> Course {get; set;}
    }
