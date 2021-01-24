    public bool Load(string employeesFile)
    {
        using (StreamReader reader = new StreamReader("employees.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Suppose that your line is splittable using a comma...
                string[] temp = line.Split(',');
                // This is really simplicistic. In a real world scenario
                // you should check if the line contains correctly all the 
                // fields required to populate an Employee...
                Employee emp = new Employee() 
                { 
                     firstName = temp[0], 
                     lastName=temp[1]
                };
                // This class is derived from List<T>
                // so you can use the Add method 
                // to add the employee to itself...
                Add(emp);
            }
            return true;
           }
        }
    }
