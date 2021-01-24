    [Test]
    public void TEST()
    {
        //arrange
        var mock = new Mock<ITarget>();
        var calls = new List<Tuple<string, string>>();
        mock.Setup(m => m.A(It.IsAny<string>()))
            .Callback<string>(s => calls.Add(new Tuple<string, string>("A", s)));
        mock.Setup(m => m.B(It.IsAny<string>()))
            .Callback<string>(s => calls.Add(new Tuple<string, string>("B", s)));
    
        var sut = new Sut(mock.Object);
    
        //act
        sut.Do();
    
        //assert
        //inspect calls
    }
