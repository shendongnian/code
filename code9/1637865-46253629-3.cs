    [Fact]
    void TestMethod() {
        //Arrange
        var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
        optionsBuilder.UseSqlServer("connection string here");
        using (var context = new MyContext(optionsBuilder.Options)) {
            var service = new MyService(context);
    
            //Act
            var result = service.GetAll();//Error here
    
            //Assert
            Assert.True(result.Count() > 0);
        }
    }
