    public class Model {
    
            public class Employee {
                public int ID { get; set; }
                public string Department { get; set; }
            }
            public class Root {
                public string Name { get; set; }
                public Employee Employee { get; set; }
            }
        }
