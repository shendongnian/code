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
        public string Name {get; set;}
        public string Family{get; set;}
        public string Deartment {get; set;}
        public Skill[] Skills {get; set;}
    }
    class skill{
        public string Type{get; set;}
        public string Grade{get; set;}
    }
