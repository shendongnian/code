    findProductViewModel.FindProductCommand.Execute(null);
    SpinWait.SpinUntil(() => findProductViewModel.ProductViewModel.ProductInformationViewModel != null, 5000);
    
    var informationViewModel = findProductViewModel.ProductViewModel.ProductInformationViewModel;
    
    Assert.AreEqual("AFG00", informationViewModel.ProductGroup);
    
