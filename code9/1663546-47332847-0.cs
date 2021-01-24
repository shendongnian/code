    public void ListStudentData()
    {
        foreach (Student student in studentList)
        {
            Console.WriteLine("First Name: {0}", student.firstName);
            Console.WriteLine("Last Name: {0}", student.lastName);
            Console.WriteLine("Address: {0}", student.address);
            ...
            ...
            ...
        }
    }
