    services.AddAuthentication()
    .AddCookie("myscheme1", o => // scheme1
    {
            o.ExpireTimeSpan = TimeSpan.FromHours(1);
            o.LoginPath = new PathString("/forUser");
            o.Cookie.Name = "token1";
            o.SlidingExpiration = true;
    })
    .AddCookie("myscheme2", o => //scheme2
    {
            o.ExpireTimeSpan = TimeSpan.FromHours(1);
            o.LoginPath = new PathString("/forAdmin");
            o.Cookie.Name = "token2";
            o.SlidingExpiration = true;
    });
