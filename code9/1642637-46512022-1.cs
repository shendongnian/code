    internal sealed class SecurityService : ISecurityService
    {
        private readonly SignInManager<User, long> _signInManager;
        public SecurityService(SignInManager<User, long> signInManager)
        {
            _signInManager = signInManager;
            _signInManager.UserManager.UserValidator = new UserValidator<User, long>(_signInManager.UserManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }
        public SignInStatus SignIn(string email, string password, bool isPersistent)
        {
            var status = _signInManager.PasswordSignIn(email, password, isPersistent, shouldLockout: false);
            return status;
        }
        public void SignOut()
        {
            _signInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                DefaultAuthenticationTypes.TwoFactorCookie);
        }
    }
    public sealed class ApplicationExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            Container.RegisterType<IPrincipal>(new InjectionFactory(c => HttpContext.Current.User));
            Container.RegisterType<ISecurityService, SecurityService>(new PerRequestLifetimeManager());
        }
    }
