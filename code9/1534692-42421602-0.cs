     public static IViewModelCache MockViewModelCache()
     {
         var cache = Mock.Of<IViewModelCache>();
         var viewModel = Mock.Of<RoutableViewModelBase<IReportData>>();
         Mock.Get(cache)
            .Setup(mock => mock.GetViewModel(It.IsAny<Type>)))
            .Returns(viewModel);
         return cache;
     }
