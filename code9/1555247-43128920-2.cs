    [TestMethod]
    public void ShouldNotInvokeHandlerWhenOtherPropertyChanged()
    {
        var sourceMock = new Mock<INotifyPropertyChanged>();
        var sut = new PropertyChangedEventManager();
        bool handlerInvoked = false;
        sut.AddHandler(sourceMock.Object, (s, e) => handlerInvoked = true, "Foo");
        
        sourceMock.Raise(m => m.PropertyChanged += null, new PropertyChangedEventArgs("Bar"));
        
        Assert.IsFalse(handlerInvoked);
    }
