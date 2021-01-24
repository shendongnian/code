        services.AddAuthorization(options =>
        {
            options.AddPolicy("HasAdminTeamAccess", policy =>
                policy.Requirements.Add(new TeamAccessRequirement()));
        });
        services.AddTransient<IAuthorizationHandler, TeamAccessHandler>();
