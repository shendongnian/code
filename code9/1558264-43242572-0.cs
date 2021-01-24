     public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
            {
                var dataProtectorProvider = Startup.DataProtectionProvider;
                var dataProtector = dataProtectorProvider.Create("My Identity");
                this.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, string>(dataProtector);
                //this.UserTokenProvider.TokenLifespan = TimeSpan.FromHours(24);
            }
