    public static Person getInfo(string info)
    {
        string inputName;
        string inputSalary;
        
        Console.WriteLine("Information of the employee: {0}", info);
        Console.WriteLine("Name:");
        inputName = Console.ReadLine();
        Console.WriteLine("Salary:");
        inputSalary = Console.ReadLine();
        Person person = new Person();
        person.Name = inputName;
        person.Salary = int.Parse(inputSalary);
        return person;
    }
