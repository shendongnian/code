    public class School
    {
        // ...
        public virtual ICollection<SchoolPicture> Pictures {get;set;}
    }
    public class Student
    {
        // ...
        public virtual ICollection<StudentPicture> Pictures {get;set;}
    }
