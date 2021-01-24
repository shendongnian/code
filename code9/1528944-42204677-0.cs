    delegate void Employee(); // Note that this is equivalent to the Action delegate
    static void Main(string[] args)
    {
        IList employees = new List<Employee>();
        for (int i = 0; i < 3; i++)
        {
            employees.Add(new Employee(() => Console.Write(i)));
        }
        foreach (Employee employee in employees)
        {
            employee();
        }
    }
