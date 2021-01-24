         public class Employee 
            {
                public string Name { get; set; }
                public int Age { get; set; }
                public decimal? Salary { get; set; }
            }    
            
            Employee employee= new Employee
                {
                    Name = "Heisenberg",
                    Age = 44
                };
        
                string jsonWithNullValues = JsonConvert.SerializeObject(person, Formatting.Indented);
    
  
