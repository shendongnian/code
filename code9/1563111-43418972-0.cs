    [Fact]
    public void Delete() {
        var dbContext = new Mock<DbContexts.MVCWebAppDbContext>();
        IStudentsService studentService = new StudentsService(dbContext.Object);
        var students = new List<Student>()
        {
            new Student() { StudentID = 1, RefNo = "12456343", FirstName = "John", LastName = "Smith", DateOfBirth = DateTime.Now.AddYears(-10), DateCreated = DateTime.Now },
            new Student() { StudentID = 2, RefNo = "87984564", FirstName = "Pete", LastName = "Luck", DateOfBirth = DateTime.Now.AddYears(-20), DateCreated = DateTime.Now.AddDays(1) }
        };
        dbContext
            .Setup(m => m.Students.Remove(It.IsAny<Student>()))
            .Callback<Student>((entity) => students.Remove(entity));
        int idToDelete = 1;
        dbContext
            .Setup(s => s.Students.Find(idToDelete))
            .Returns(students.Single(s => s.StudentID == idToDelete));
        // call delete method now
        studentService.Delete(idToDelete);
        // 1 object deleted, it should return 1
        Assert.AreEqual(1, students.Count());
        dbContext.Verify(s => s.Students.Find(idToDelete), Times.Once);
        dbContext.Verify(s => s.Students.Remove(It.IsAny<Student>()), Times.Once);
        dbContext.Verify(s => s.SaveChanges(), Times.Once);
    }
