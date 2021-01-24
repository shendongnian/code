    public void _WhenAgeOver3_Kid_IsAdult() {
        //Arrange
        var initialAge = 2;
        var expectedAge = initialAge + 1;
        var kid = new Kid();
        var wrapper = new PrivateObject(kid);            
        wrapper.SetProperty("Age", initialAge);
        Assert.AreEqual(initialAge, kid.Age);
        //Act
        kid.OnHourPass();
        //Assert
        Assert.AreEqual(expectedAge, kid.Age); // should be 3.
        Assert.AreEqual(true, kid.IsAdult); // should be true.
    }
