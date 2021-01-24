    public async Task Validate_Password() {
  
        //Arrange
        var userManagerMock = new GetMockUserManager();
        var subjetUnderTest = new CustomPasswordValidator();
        var user = new AppUser() {
            Name = "user" 
        }; 
        //set the test password to get flagged by the custom validator
        var password = "Thi$user12345";
        //Act
        IdentityResult result = await subjetUnderTest.ValidateAsync(userManager.Object, user, password);
    
    
        //...code removed for brevity
    
    }
