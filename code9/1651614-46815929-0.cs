    public class CreateUserByAdminHandler : IAsyncRequestHandler<CreateUserByAdmin, CreateUserResult>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserByAdminHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserResult> Handle(CreateUserByAdmin command)
        {
            var result = new CreateUserResult();
            try
            {
                var appUser = new AppUser
                {
                    UserName = command.Username.Trim(),
                    FirstName = command.FirstName.Trim(),
                    LastName = command.LastName.Trim(),
                    Email = command.Email,
                    PhoneNumber = command.PhoneNumber,
                    Status = UserStatus.Active
                };
                var createResult = await _userManager.CreateAsync(appUser, command.Password);
                if (!createResult.Succeeded)
                {
                    // IdentityResult has Errors property, which is a list of 
                    // IdentityError. IdentityError has Code and Description
                    // property. It's up to you to select whichever property 
                    // for the error message.
                    result.AddErrors(createResult.Errors.Select(ier => ier.Description));
                    return result;
                }
                result.NewUser = appUser;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }
            return result;
        }
    }
