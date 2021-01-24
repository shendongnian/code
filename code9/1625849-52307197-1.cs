    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    namespace EmailServerConsole.Data
    {
        public class EmailDBContext : DbContext
        {
            public EmailDBContext(DbContextOptions<EmailDBContext> options) : base(options) { }
            public DbSet<EmailQueue> EmailsQueue { get; set; }
        }
        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<EmailDBContext>
        {
            EmailDBContext IDesignTimeDbContextFactory<EmailDBContext>.CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<EmailDBContext>();
                var connectionString = configuration.GetConnectionString("connection_string");
                builder.UseSqlServer(connectionString);
                return new EmailDBContext(builder.Options);
            }
        }
    }
