    [TestMethod]
    [ExpectedException(typeof(BusinessException), "Not a valid Business Case")]
    public void TnC_Should_Throw_BusinessException() {
        //Arrange
        var bookingService = new Mock<IBookingService>();
    
        var controller = new LinkBookingController(bookingService.Object);
    
        var viewModel  = new myViewModel
        {
            //...params
        };
    
        bookingService.Setup(_ => _.TnC(viewModel, It.IsAny<IPrincipal>())).Throws<BusinessException>()
    
        //Act
        var expectedResult = controller.TnC(viewModel);
    
        //Assert
        //...the ExpectedException attribute should assert if it was thrown
    }
