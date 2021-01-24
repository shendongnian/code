     public void PopulateOurDatabase()
    {
       using (dbCntxt = new DatabaseContext())
       {
        stdnt = new Student {StudentID = 1, FirstName = "FN", LastName = "LN", 
        Age = 27, Sex = "Male", ContactNumber = "123456", Email = 
       "user1@gmail.com", AcademicYear = 1, AcademicDegree = "Electrical 
       Engineering", AcademicSubject = "blabla" };
        dbCntxt.Students.AddOrUpdate(stdnt);
        dbCntxt.SaveChanges();
       }
  
 
