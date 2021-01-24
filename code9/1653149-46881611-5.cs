    services.AddMvc()
        .AddRazorPagesOptions(options =>
        {
            options.Conventions.AuthorizeFolder("/MembersOnly");
            options.Conventions.AuthorizeFolder("/Manage", "Admins"); // with specific policy
            options.Conventions.AuthorizePage("/Account/Logout");
            options.AllowAnonymousToFolder("/Public"); // folder
            options.AllowAnonymousToPage("/Contact"); // page
        });
