    [Fact]
    public void CreateBlog() {
        //Arrange
        var mockDbSet = new Mock<DbSet<Blog>>();
        var mockContext = new Mock<IContext>();
        mockContext.Setup(m => m.Blogs).Returns(mockDbSet.Object);
        var service = new BlogController(mockContext.Object);
        //Act
        service.AddBlog("ADO.NET Blog", "adtn.com");
        //Assert
        mockDbSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
