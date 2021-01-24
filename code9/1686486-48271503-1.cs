    [Test]
    public void TestGetAllPeople() {
        //Arrange
        var expected = peopleList.Count;
        personRepoMock.GetPeople().Returns(peopleList);
        var subject = new PersonService(personRepoMock);
        //Act
        var actual = subject.GetAllPeople().Count;
      
        //Assert
        Assert.AreEqual(expected, actual);
        personRepoMock.Received().GetPeople();
    }
