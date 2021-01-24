    class Person
    {
        public int Id {get;set;}
        ...
    }
    class Student
     {
        public int Id {get;set;}
        // A student has Person data via foreign key:
        public int PersonId {get; set;}
        public Person Person {get; set;}
        ...        
     }
     class Teacher
     {
        public int Id {get;set;}
        // A Teacher has Person data via foreign key:
        public int PersonId {get; set;}
        public Person Person {get; set;}
        ...        
     }
    
