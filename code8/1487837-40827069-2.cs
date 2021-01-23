    MappedObject mappedObject = JsonConvert.DeserializeObject<MappedObject>(yourJson);
    
    class MappedObject{
        public Person person;
        public Employee employee; 
    }
    
    class Person{
        public string name;
        public string family;
    }
    class Employee {
        public intid{get; set;}
        public string deartment {get; set;}
        public Skill[] skills {get; set;}
    }
    class skill{
        public string type{get; set;}
        public string grade{get; set;}
    }
