        public void ConfigureServices(IServiceCollection services) {
            // .... Ignore code before this
            services.AddMvc(); // Already included. Add your code below this.
            services.AddAutoMapper(); // <-- This is the line you add.
            // services.AddAutoMapper(typeof(Startup));  // <-- newer automapper version uses this signature.
    }
