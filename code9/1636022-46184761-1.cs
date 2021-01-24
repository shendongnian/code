    services.ConfigureApplicationCookie(options =>
    {
        var protectionProvider = DataProtectionProvider.Create(new DirectoryInfo(@"c:\shared-auth-ticket-keys\"));
        options.Cookie.Name = ".AuthCookie";
        options.Cookie.Expiration = TimeSpan.FromDays(7);
        options.LoginPath = "/Account/Login";
        options.Cookie.Domain = ".example.com";
        options.DataProtectionProvider = protectionProvider;
        options.TicketDataFormat = new TicketDataFormat(protectionProvider.CreateProtector("Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", "Cookies", "v2"));
    });
