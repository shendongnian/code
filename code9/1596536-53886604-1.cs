    private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "YourApiName",
                    Description = "Your Api Description.",
                    TermsOfService = "None",
                    Contact = new Contact
                        {Name = "Contact Title", Email = "contactemailaddress@domain.com", Url = ""}
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "YourApiName.xml");
                c.IncludeXmlComments(filePath);
            });
        }
