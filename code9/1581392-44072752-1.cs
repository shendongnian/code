    [TestMethod]
    public void TestMethod1() {
        //Arrange
        var _streamWriterMock = new Mock<StringWriter>();
        string[] expectedLines = new[] { "line1", "line2" };
        var subject = new SubjectUnderTest(_streamWriterMock.Object);
        //Act
        subject.WriteLines(expectedLines);
        //Assert
        foreach (var line in expectedLines) {
            _streamWriterMock.Verify(a => a.Write(line), Times.Exactly(1));
        }
    }
