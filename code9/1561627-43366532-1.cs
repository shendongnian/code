    [HttpPut("WebServices/UsersService.svc/rest/users/user")]
    public void UpdatePassword([FromBody]UpdateModel model) {
        LoginData oldCredentials = model.oldCredentials;
        string newPassword = model.newPassword;
        NonceService.ValidateNonce(oldCredentials.Nonce);
    
        var users = UserStore.Load();
        var theUser = GetUser(oldCredentials.UserName, users);
    
        if (!UserStore.AuthenticateUser(oldCredentials, theUser)) {
            FailIncorrectPassword();
        }
    
        var iv = Encoder.GetRandomNumber(16);
        theUser.EncryptedPassword = Encoder.Encrypt(newPassword, iv);
        theUser.InitializationVektor = iv;
    
        UserStore.Save(users);
    }
