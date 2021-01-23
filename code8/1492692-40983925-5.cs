    //Arrange
    var updatedBook = new Book { Name = "Update Book Name" };
    var id = 1;
    var mockRepository = new Mock<IGenericRepository<Book>>();
    mockRepository
        .Setup(m => m.Update(updatedBook, id))
        .Returns(updatedBook);
    var service = new MyDataService<Book>(mockRepository.Object);
    //Act
    var data = service.Update(updatedBook, id);
    //Assert
    //...
