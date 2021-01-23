        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseResponseCompression(); // <--
            app.UseHttpsRedirection();
            app.UseMvc(); // <--
        }
