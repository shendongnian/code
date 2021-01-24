    public class ApplicationUserManager : UserManager<UserDB>
	{
		public ApplicationUserManager(UserStore store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<UserDB> passwordHasher, IEnumerable<IUserValidator<UserDB>> userValidators, IEnumerable<IPasswordValidator<UserDB>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<UserDB>> logger, IHttpContextAccessor contextAccessor) 
			: base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger, contextAccessor)
		{
            if (!optionsAccessor.Value.Tokens.ProviderMap.ContainsKey("DefaultTokenProvider"))
                optionsAccessor.Value.Tokens.ProviderMap.Add("DefaultTokenProvider", new TokenProviderDescriptor(typeof(UserStore)));
        }
	}
