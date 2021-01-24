    services.AddAuthorization(options => {
        options.AddPolicy("EndingContracts", policy =>
            policy.RequireAssertion(context => context.User.HasClaim(c => (c.Type == "department" && c.Value == "MIS" ||
            c.Type == "UserName" && "John Doe, Jane Doe".Contains(c.Value)))));
    });
