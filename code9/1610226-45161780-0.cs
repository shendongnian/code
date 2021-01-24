        public void Configuration(IAppBuilder app)
        {         
            app.Map("/signalR", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration { };
                map.RunSignalR(hubConfiguration);
            });
        }
