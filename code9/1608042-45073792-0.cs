    class School
    {
        public int Id {get; set;}
        // a School has many Students:
        public virtual ICollection<Student> Students {get; set;}
        // a School has many Classes:
        public virtual ICollection<Class> Classes {get; set;}
        ...
    }
    public class Student
    {
        public int Id {get; set;}
        
        // A student belongs to one School via Foreign Key
        public int SchoolId {get; set;}
        public virtual School School {get; set;}
        // A student attends many classes
        public virtual ICollection<Class> Classes {get; set;}
        ...
    }
    class Class
    {
        public int Id {get; set;}
        // a class belongs to one School via foreign key:
        public int SchoolId {get; set;}
        public virtual School School {get; set;}
        // a class has many Students
        public virtual ICollection<Student> Students {get; set;}
        ...
    }
