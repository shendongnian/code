        public async Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout, Func<string, EnumCompanyStatus> getCompanyStatus)
        {
            CompanyStatus = getCompanyStatus(userName);
            if (CompanyStatus != EnumCompanyStatus.Active)
                return SignInStatus.Failure;
            return await base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }
