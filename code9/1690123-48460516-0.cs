            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
            })
            .AddGoogle("Google", options =>
            {
                options.AccessType = "offline";
                options.ClientId = googleClientId;
                options.ClientSecret = googleClientSecret;
                options.SaveTokens = true;
                options.Scope.Add(GmailService.Scope.MailGoogleCom);
                options.Scope.Add(GmailService.Scope.GmailSettingsBasic);
            });
