    //Arrange
    var expected = "test";
    var wmMock = new Mock<IWindowManager>();
    wmMock.Setup(w => 
        w.ShowDialog(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<IDictionary<string, object>>()))
          .Returns(true)
          .Callback<object, object, IDictionary<string, object>>((obj1, obj2, dic) => {
              var vm = obj1 as TestViewModel;
              if(vm ! = null) 
                  vm.CoolText = expected;
          });
    var mainVM = new MainViewModel(wmMock.Object);
    //Act
    mainVM.ShowDialog();
    //Assert
    Assert.That(mainVM.DialogResultText, Is.EqualTo(expected);
