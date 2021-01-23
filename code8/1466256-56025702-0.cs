 dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 2.2.4 
Then Update your Startup.cs file as indicated below.
using Microsoft.EntityFrameworkCore.Proxies;
services.AddEntityFrameworkProxies();
services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                options.UseLazyLoadingProxies(true);
            });
