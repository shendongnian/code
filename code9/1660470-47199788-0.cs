    List<Employee> iList = new List<Employee>();
    public void GetEmployeeData()
    {
        for (int i = 0; i < 10; i++)
        {
             iList[i].age = 12;
             iList[i].Name = "Sandhya";
             iList[i].cadder = "A+";
        }
    }
    void PassListData(List<Employee> list)
    {
        foreach(var e in list)
        {
            Console.WriteLine(e.Name);
            Console.WriteLine(e.age);
            Console.WriteLine(e.Cadder);
        }
    } 
