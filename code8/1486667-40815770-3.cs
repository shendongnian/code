    [TestMethod]
    public void DetailsPrint_shouldPrint() {
        var result = _controller.DetailsPrint(1) as ActionResult;
        result.Should()
            .NotBeNull()
            .And
            .BeAssignableTo<ActionResult>();
    }
