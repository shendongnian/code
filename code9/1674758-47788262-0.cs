    class Employee
    {
        public int Id {get;set;}
        public string Name {get;set;}
    }
    
    //...
    
    var users = new List<Employee>();
    //fill users
    
    var filteredUsers = users.Where(o=>o.Name.Contains("a")).ToList();
