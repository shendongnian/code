     public static class SimpleInjectorConfig
    {
        public static Container Configure()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<AppIdentityDbContext>(Lifestyle.Scoped);
            container.Register<AppUserManager>(Lifestyle.Scoped);
            container.Register(
                () =>
                    container.IsVerifying
                        ? new OwinContext().Authentication
                        : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);
            container.Register<AppSignInManager>(Lifestyle.Scoped);
            container.Verify();
            return container;
        }
    }
