    abstract class Person
    {
        public string Name {get; set}
        public Gender Gender {get; set;}
        public DateTime Birthday {get; set;}
    }
    public class Teacher : Person
    {
        public int Id {get; set;}
        ...
    }
    public class Student : Person
    {
        public int Id {get; set;}
        ...
    }
