    public void Test_GetAllBooks_ReturnsListOfBooksItReceivesFromReadAllMethodOfReadItemCommand_WhenCalled()
    {
        //Arrange
        var mockReadItemCommand = new Mock<ReadItemCommand>();
        var catalogue = new Catalogue(mockReadItemCommand.Object);
        
        var expected = new List<Book>(){
            new Book {
                Title = "Book1", 
                //populate other properties  
            },
            new Book { 
                Title = "Book2", 
                //populate other properties  
            }
        };
        mockReadItemCommand
            .Setup(_ => _.ReadAll())
            .Returns(expected);
        //Act
        var actual = catalogue.GetAllBooks();
        //Assert
        Assert.AreSame(expected, actual);
    }
