    class Student {
       public string Name { get; set; }
       public string Phone { get; set; }
       //more properties
    }
    
    ...
    
    var student = new Student {
        Name = "My Name",
        Phone = "555-453-6547"
    };
    
    string json = JsonConvert.SerializeObject(student);//now in json format
    
    //now a Student object
    Student deserializedJson = JsonConvert.DeserializeObject<Student>(json);
