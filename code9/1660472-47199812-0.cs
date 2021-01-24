    public void GetEmployeeData()
    {
        var iList = new List<Employee>();
        for (int i = 0; i < 10; i++)
        {
             var employee = new Employee();             
             employee.age = 12;
             employee.Name = "Sandhya";
             employee.cadder = "A+";
             iList.Add(employee);
        }
        PassListData(iList);
    }
    
    void PassListData(List<Employee> employees)
    {
        // loop through here
    }
 
