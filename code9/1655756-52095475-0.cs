        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {               
                // <snip>
            }
            else
            {
                // <snip>
                app.UseHttpsRedirection(); // <- Moved from outside to inside else block to allow ngrok tunneling for testing Stripe webhooks
            }
            // <snip>
            app.UseMvc();
        }
