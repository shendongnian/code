    [TestMethod()]
    public void BaseController_When_Authenticated_Should_Return_UserId() {
        //Arrange
        //Create test user
        var expected = 12345;
    
        var identity = new LtfClaimsIdentity("Ltf"); // Or how ever it is you initialize your identity
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, expected.ToString()));
        
        var principal = new GenericPrincipal(identity, roles: new string[] { });
        var user = new ClaimsPrincipal(principal);
    
        // Set the User on the controller directly
        var controller = new BaseController () {
            User = user
        };
    
        //Act
        var actual = controller.UserId;
    
        //Assert
        Assert.AreEqual(expected, actual);
    }
