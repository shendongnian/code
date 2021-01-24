    /// <summary>
    /// Gets student information from the user and adds a new student to the list
    /// </summary>
    /// <param name="existingStudents">The list of students to add to</param>
    private static void AddStudent(List<Student> existingStudents)
    {
        // Initialize the list if it's null
        if (existingStudents == null) existingStudents = new List<Student>();
        int tempInt;
        // Get student information from the user
        Console.WriteLine("Enter new student information");
        do
        {
            Console.Write(" 1. Enter student Id: ");
        } while (!int.TryParse(Console.ReadLine(), out tempInt));
        var id = tempInt;
        Console.Write(" 2. Enter student Name: ");
        var name = Console.ReadLine();
        Console.Write(" 3. Enter student Job Title: ");
        var jobTitle = Console.ReadLine();
        do
        {
            Console.Write(" 4. Enter student years of service: ");
        } while (!int.TryParse(Console.ReadLine(), out tempInt));
        var yrsOfService = tempInt;
        // Add the new student to the list
        existingStudents.Add(new Student(id, name, jobTitle, yrsOfService));
    }
