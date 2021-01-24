    public async Task Validate_Password()
    
        //...code removed for brevity
 
        var user = new Mock<AppUser>();
        //How can I assign user name/password values here?
        user.Setup(_ => _.Name).Returns("user");
        //create a password that has the username and sequence '12345' to generate errors
        user.Setup(_ => _.Password).Returns("user12345");
   
        IdentityResult result = await PasswordValidator<AppUser>.ValidateAsync(userManager.Object, user.Object, user.Object.Password);
    
    
        //...code removed for brevity
    
    }
