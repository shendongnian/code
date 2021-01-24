    services.AddAuthorization(options => {
        options.AddPolicy("EditCustomer", policy =>
            policy.RequireAssertion(context => 
            context.User.HasClaim(c => (c.Type == "DeleteCustomer" || c.Type == "Superuser"))));
    });
