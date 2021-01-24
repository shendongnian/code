    static void Main(string[] args)
    {
        var students = new List<Student>();
        students.Add(
            new Student
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "43 North West",
                City = "Capetown",
                Country = "South Africa",
                PostCode = "12345",
                Grade = "A+",
                StudentID = Guid.NewGuid().ToString("N")
            });
            
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }
