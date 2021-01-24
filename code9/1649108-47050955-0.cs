    public class ApplicationUserManager : UserManager<YourIdentityUser, int>
    {
        public ApplicationUserManager(IUserSecurityStampStore<YourIdentityUser, Guid> store)
            : base(store)
        {
        }
    
        // *** some other code
    
        public override async Task<string> GenerateChangePhoneNumberTokenAsync(Guid userId, string phoneNumber)
        {
            var user = await FindByIdAsync(userId);
            var code = CustomRfc6238AuthenticationService.GenerateCode(user.SecurityStamp, phoneNumber, "optional modifier", TimeSpan.FromDays(14));
            return code;
        }
    }
