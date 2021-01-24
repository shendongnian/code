        public void Configure(IApplicationBuilder app)
        {
            //first handle any websocket requests
            app.UseWebSockets();
            app.UseWebSocketHandler();
            //now handle other requests (default, static files, mvc actions, ...)
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseMvc(...);
        }
