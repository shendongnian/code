     public class UsernameValidator<TUser> : IUserValidator<TUser>
    where TUser : User
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {                
            if (user.UserName.Any(x=>x ==':' || x == ';' || x == ' ' || x == ','))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "InvalidCharactersUsername",
                    Description = "Username can not contain ':', ';', ' ' or ','"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }        
    }
