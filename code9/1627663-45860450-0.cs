    public static class MyExtensionPoint {
        public static IServiceCollection AddMyLibraryDbContext(this IServiceCollection services, IConfiguration Configuration) {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:LocalConnectionString"]));
        }
    }
