    public class LoginService : ILoginService
    {
        private readonly IEntityService<UserAccount> _entityService;
        public LoginService(IEntityService<UserAccount> entityService) 
        {
            _entityService = entityService;
        }
        async Task<UserProfileViewModel> ILoginService.GetLoginDetailAsync(string userName)
        {
            var userAcount = await _entityService.GetFirstOrDefaultAsync(c => c.Username.ToLower() == userName.Trim().ToLower() && c.Active);
            if (userAcount != null)
            {
                return Mapper.Map<UserAccount, UserProfileViewModel>(userAcount);
            }
            return null;
        }
    }
