    [TestMethod]
    public void TestSomething()    
    {
       // Create the user data
       var educationUsers = new List<EducationUser>
       {
           new EducationUser
           {
               UsrName = "andrew",
               UsrPwd = "DefaultPassword"
           }
       }.AsQueryable();
       
       // Create the DbSet that contains the user data and wire it up to return the user data that was created above
       Mock<DbSet<EducationUser>> educationUsersDbSet = new Mock<DbSet<EducationUser>>();
       educationUsersDbSet.As<IQueryable<EducationUser>>().Setup(m => m.Provider).Returns(educationUsers.Provider);
       educationUsersDbSet.As<IQueryable<EducationUser>>().Setup(m => m.Expression).Returns(educationUsers.Expression);
       educationUsersDbSet.As<IQueryable<EducationUser>>().Setup(m => m.ElementType).Returns(educationUsers.ElementType);
       educationUsersDbSet.As<IQueryable<EducationUser>>().Setup(m => m.GetEnumerator()).Returns(educationUsers.GetEnumerator());
       
       // Create the mock context and wire up its EducationUsers property to return the DbSet that was created above
       var context = new Mock<IEducationEntities>();
       context.Setup(e => e.EducationUsers).Returns(educationUsersDbSet.Object);
       // Create the account controller using the mock DbContext
       _accountController = new AccountController(context.Object);
       // ... the rest of your testing code ...
    }
