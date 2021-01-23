    //Create test user
    var username = "username@example.com";
    var identity = new GenericIdentity(username, "");
    var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, username);
    identity.AddClaim(nameIdentifierClaim);
    var principal = new GenericPrincipal(identity, roles: new string[] { });
    var user = new ClaimsPrincipal(principal);
    // Set the User on the controller directly
    var messageController = new MessagesController(mesBL.Object){
        User = user
    };
