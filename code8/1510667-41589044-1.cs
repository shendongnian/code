    [TestMethod()]
    public void SavePlayerLocTests() {
        //Arrange
        //Create test user
        var username = "admin";
        var identity = new GenericIdentity(username, "");
        var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, username);
        identity.AddClaim(nameIdentifierClaim);
        var principal = new GenericPrincipal(identity, roles: new string[] { });
        var user = new ClaimsPrincipal(principal);
        // Set the User on the controller directly
        var controller = new TestApiController() {
            User = user
        };
        //Act
        var actionResult = controller.SavePlayerLoc(GetLocationList());
        var response = actionResult as OkNegotiatedContentResult<IEnumerable<bool>>;
        //Assert
        Assert.IsNotNull(response);
    }
