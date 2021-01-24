    public class SameCharacterPasswordValidator<TUser>: IPasswordValidator<TUser> 
           where TUser : class
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, 
                                                  TUser user, 
                                                  string password)
        {
            return Task.FromResult(password.Distinct().Count() == 1 ? 
                IdentityResult.Failed(new IdentityError
                {
                    Code = "SameChar",
                    Description = "Passwords cannot be all the same character."
                }) : 
                IdentityResult.Success);
        }
    }
