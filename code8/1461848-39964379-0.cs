    [Test]
    public async Task Display_Validate_Account_Page_On_Successful_Registration()
    {
        //arrange
        var businessContract = Mapper.Map<BusinessViewModel, BusinessContract>(_userRegisterationViewModel.Business);
        var userContract = Mapper.Map<UserViewModel, UserContract>(_userRegisterationViewModel.User);
    
        var accountContract = new AccountContract()
        {
            Business = businessContract,
            User = userContract
        };
    
    
        _mockAccountContract
            .Setup(contract => contract.Result.Value.Business)
            .Returns(accountContract.Business);
    
        _mockAccountContract
            .Setup(contract => contract.Result.Value.User)
            .Returns(accountContract.User);
    
        _mockAccountServiceChannel
            .Setup(svc => svc.RegisterAsync(accountContract))
            .ReturnsAsync(_mockAccountContract.Object);
        //act
        var result = (RedirectToRouteResult) await _registerController.Register(_userRegisterationViewModel);
    
        //assert
        Assert.That(result.RouteValues["action"], Is.EqualTo("ValidateAccount"));
    }
