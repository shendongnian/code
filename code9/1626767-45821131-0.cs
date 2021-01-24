    [Test]
    public void Test1()
    {
        _filmService.Setup(f => f.FindById(It.IsAny<int>())).Throws<Exception>();
        _filmController.Test();
        _filmService.Verify(f => f.Exists(It.IsAny<Film>()), Times.Once);
    }
