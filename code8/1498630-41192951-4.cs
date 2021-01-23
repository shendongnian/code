    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateBackingAcc_PersoneIdInvalid_ThrowsException()
    {
        // Arrange
        Mock<IService> serviceMock = new Mock<IService>();
        const int invalidPersonId = -1;
        serviceMock.Setup(s => s.GetAccDetails(It.Is<int>(i => i == invalidPersonId)))
            .Throws<InvalidOperationException>();
        Person person = new Person(invalidPersonId, serviceMock.Object);
        // Act
        person.UpdateBackingAcc();
        // Assert
        // Throws exception
    }
