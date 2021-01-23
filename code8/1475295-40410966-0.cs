    public class Employee 
    { 
        //Default constructor
        public Employee()
        {
            Name = "Some other name";
            Title = "Some other title";
        }
        //Static constructor
        static Employee()
        {
        }
        //Just a static method returning an Employee object
        public static Employee GetEmployee() 
        {      
            //Object initializer using the default constructor   
            var emp = new Employee() 
            { 
                Name = "Somebody", 
                Title = "Developer" 
            }; 
            return emp;
        }
        public string Name { get; set; } 
        public string Title { get; set; } 
    } 
