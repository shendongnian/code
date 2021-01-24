    Func<string, byte[]> getPwHash = (pwStr) => {
        using (SHA512CryptoServiceProvider provider = new SHA512CryptoServiceProvider())
        {
            return provider.ComputeHash(Encoding.UTF8.GetBytes(pwStr));
        }            
    };
    
    
    
    var nullpwUsers = _entities.SoftwareUser.Where(user => user.UsrPwd == null);
    foreach(var user in nullpwUsers) 
    {
        user.UserPwd = getPwHash("DefaultPassword");
    }
    _entities.SaveChanges();
