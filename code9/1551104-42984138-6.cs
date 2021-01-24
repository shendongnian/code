    public void GivenARequestToFooShouldExecuteFoo() {
        //Arrange
        var expected = true;
        var key = ActionType.Foo;
        var action = new Mock<Foo>();
        action.Setup(x => x.Execute(It.IsAny<ActionRequest>())).Returns(expected);
        var actions = new Mock<IActionCollection>();
        actions.Setup(_ => _[key]).Returns(() => { return () => action.Object; });
        actions.Setup(_ => _.ContainsKey(key)).Returns(true);
        var sut = new Executor(actions.Object);
        var request = new ActionRequest {
            ActionType = ActionType.Foo
        };
        //Act
        var actual = sut.ExecuteAction(request);
        //Assert
        Assert.AreEqual(expected, actual);
    }
