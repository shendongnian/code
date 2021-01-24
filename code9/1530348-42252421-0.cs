    var student = new Student
    {
        Id = 9974,
        LastName = "Abc",
        FirstMidName = "Abcd",
        EnrollmentDate = Convert.ToDateTime("11/23/2010"),
        PaymentDue = 20
    }
    
    var listOfStudents = new List<Student>();
    listOfStudents.Add(student);
    mockStudentRepository.Setup(x =>
        x.GetStudentByID(student.Id))
        .Returns(student);
