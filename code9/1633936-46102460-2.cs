    private ViewModel _viewModel;
    [Test]
    public void Test()
    {
        _viewModel = new ViewModel
        {
            StrategyManager = new Mock<IStrategyManager>().Object,
            Person = "whatever"
        };
    }
