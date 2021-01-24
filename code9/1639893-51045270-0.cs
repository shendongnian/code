        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //...
            app.UseSwaggerUI(c =>
            {
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Your.Default.Namespace.Resources.Swagger_Custom_index.html");
            });
            app.UseMvc();
        }
