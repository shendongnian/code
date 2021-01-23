    [TestMethod]
    public void Abc_log_Test() {
        //Arrange
        Abc.ServerPath = new FakeServerPath();
        string filename = "fakeFile.txt";
        string expected = @"C:\" + filename;
    
        //Act
        string actual = Abc.log(filename);
     
        //Assert
        Assert.AreEqual(expected, actual);
    }
