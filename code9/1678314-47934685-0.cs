    private HomeController controller;
    [TestInitialize]
    public void TestInitialize()
    {
        mock = new Mock<ILibraryRepository>();
        books = new List<Book>()
        {
            new Book { Id = 0, Title = "Title 0", Edition = 0, PublicationDate = DateTime.Now, Author = { Id = 0, Name = "Author 0", DateOfBirth = DateTime.Now, DateOfDeath = DateTime.Now }, AuthorId = 0 },
            new Book { Id = 1, Title = "Title 1", Edition = 1, PublicationDate = DateTime.Now, Author = { Id = 1, Name = "Author 1", DateOfBirth = DateTime.Now, DateOfDeath = DateTime.Now }, AuthorId = 1 },
            new Book { Id = 2, Title = "Title 2", Edition = 2, PublicationDate = DateTime.Now, Author = { Id = 2, Name = "Author 2", DateOfBirth = DateTime.Now, DateOfDeath = DateTime.Now }, AuthorId = 2 }
        };
        mock.Setup(m => m.Books).Returns(books.AsQueryable());
        controller = new HomeController(mock.Object);
    }
    [TestMethod]
    public void IndexLoadsValid()
    {
        // Arrange - use arrange from test initialise
    
        // Act
        var result = controller.Index() as ViewResult;
        // Assert
        Assert.IsNotNull(result);
    }
