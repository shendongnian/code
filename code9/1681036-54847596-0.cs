            services.AddIdentityServer(opt => opt.IssuerUri = issuerUri)
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdServer.Configuration.GetApiResources())
                .AddInMemoryClients(IdServer.Configuration.GetClients())
                .AddProfileService<ProfileService>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                ;
