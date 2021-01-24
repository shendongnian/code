    [TestMethod]
    public void DataService_Should_Get_Lesson() {
        //Arrange
        var id = 1;
        var lesson = new Lesson {
            Id = id,
            //...code removed for brevity
        };
        var mock = new Mock<IUnitOfWork>();
        mock.Setup(_ => _.Lessons.FindById(id)).Returns(lesson);
    
        var sut = new LessonDataService(mock.Object);
    
        //Act
        var actual = sut.FindById(id);
    
        //Assert
        lession.Should().BeEquivalentTo(actual);
    }
