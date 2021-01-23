    //Arrange
    var expected = "MyProperty";
    var actual = string.Empty;
    
    var viewModel = {...some calss that inherits from ViewModelBase};
    
    viewModel.PropertChanged += (s,e) => {
        actual = e.PropertyName;
    }
    
    //Act
    viewModel.MyProperty = "Test";
    
    //Assert
    actual.Should().Be(expected);
