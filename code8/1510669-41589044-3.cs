    [TestMethod()]
    public void SavePlayerLocTests() {
        //Arrange
        //Create test user
        var username = "admin";
        var userId = 2;
        var identity = new GenericIdentity(username, "");
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
        identity.AddClaim(new Claim(ClaimTypes.Name, username));
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
