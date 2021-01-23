    public StudentReport ParseStudentReport(Student e)
    {
        return new StutentReport{
             Id = e.Id
             Name = e.Name
             Family = e.Family
             BirthDate = e.BirthDate
             RegisterDate = e.RegisterDate
        }
     }
