    public static bool ValidateUser(string Email, string Password)
        {
            var user = UserManager.FindByName(Email);
            return SignInManager.UserManager.CheckPassword(user, Password); 
        }
