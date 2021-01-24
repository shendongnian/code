    public class Employee {
    
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public int phoneNumber { get; set; }
    
            public Employee()
            {
    
            }
    
            public Employee(string fname,string lname,int age,int phone)
            {            
                this.FirstName = fname;
                this.LastName = lname;
                this.Age = age;
                this.phoneNumber = phone;
            }
    }
