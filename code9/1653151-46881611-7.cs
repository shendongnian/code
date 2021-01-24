    services.AddMvc()
        .AddRazorPagesOptions(options =>
        {
            options.Conventions.AuthorizeFolder("/MembersOnly");
            options.Conventions.AuthorizePage("/Account/Logout");
            options.Conventions.AuthorizeFolder("/Pages/Admin", "Admins"); // with policy
            options.Conventions.AllowAnonymousToPage("/Pages/Admin/Login"); // excluded page
            options.Conventions.AllowAnonymousToFolder("/Public"); // just for completeness
        });
