    var cache = Mock.Of<IViewModelCache>();
    var viewModel = Mock.Of<IViewModel>();
    var viewModelType = typeof(IViewModel);
    Mock.Get(cache)
       .Setup(mock => mock.GetViewModel(viewModelType))
       .Returns(viewModel);
