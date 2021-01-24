       services.Replace(ServiceDescriptor.Scoped<IUserValidator<User>, CustomUserValidator<User>>());
  
       public class CustomUserValidator<TUser> : IUserValidator<TUser> where TUser : class
       {
        private readonly List<string> _allowedDomains = new List<string>
        {
            "elanderson.net",
            "test.com"
        };
 
        public UserValidator(IdentityErrorDescriber errors = null)
        {
            Describer = errors ?? new IdentityErrorDescriber();
        }
        public IdentityErrorDescriber Describer { get; }
        public virtual async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var errors = new List<IdentityError>();
            await ValidateUserName(manager, user, errors);
            if (manager.Options.User.RequireUniqueEmail)
                await ValidateEmail(manager, user, errors);
            return errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }
        private async Task ValidateUserName(UserManager<TUser> manager, TUser user, ICollection<IdentityError> errors)
        {
            var userName = await manager.GetUserNameAsync(user);
            if (string.IsNullOrWhiteSpace(userName))
                errors.Add(Describer.InvalidUserName(userName));
            else if (!string.IsNullOrEmpty(manager.Options.User.AllowedUserNameCharacters) && userName.Any(c => !manager.Options.User.AllowedUserNameCharacters.Contains(c)))
            {
                errors.Add(Describer.InvalidUserName(userName));
            }
        }
        private async Task ValidateEmail(UserManager<TUser> manager, TUser user, List<IdentityError> errors)
        {
            var email = await manager.GetEmailAsync(user);
            if (string.IsNullOrWhiteSpace(email))
                errors.Add(Describer.InvalidEmail(email));
            else if (!new EmailAddressAttribute().IsValid(email))
            {
                errors.Add(Describer.InvalidEmail(email));
            }
            else if (_allowedDomains.Any(allowed =>
                email.EndsWith(allowed, StringComparison.CurrentCultureIgnoreCase)))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidDomain",
                    Description = "Domain is invalid."
                });
            }
            else
            {
                var byEmailAsync = await manager.FindByEmailAsync(email);
                var flag = byEmailAsync != null;
                if (flag)
                {
                    var a = await manager.GetUserIdAsync(byEmailAsync);
                    flag = !string.Equals(a, await manager.GetUserIdAsync(user));
                }
                if (!flag)
                    return;
                errors.Add(Describer.DuplicateEmail(email));
            }
        }
      }
