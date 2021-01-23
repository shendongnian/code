            #region 2way SSL settings
            services.AddMvc();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CertificateAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CertificateAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCertificateAuthentication(certOptions =>
            {
                var certificateAndRoles = new List<CertficateAuthenticationOptions.CertificateAndRoles>();
                Configuration.GetSection("AuthorizedCertficatesAndRoles:CertificateAndRoles").Bind(certificateAndRoles);
                certOptions.CertificatesAndRoles = certificateAndRoles.ToArray();
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanAccessAdminMethods", policy => policy.RequireRole("Admin"));
                options.AddPolicy("CanAccessUserMethods", policy => policy.RequireRole("User"));
            });
            #endregion
