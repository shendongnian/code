    [TestMethod]
    public void FooEventRaisedByIBarImplementation()
    {
	    var foo = new Mock<Foo>();
        foo.As<IBar>().Setup(bar => bar.BarMethod())
                .Raises(bar => bar.As<Foo>().FooEventHandler += null, new EventArgs());
    }
