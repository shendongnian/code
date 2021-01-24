    using EFCore.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    
    namespace EFCore
    {
        class Program : IDesignTimeDbContextFactory<StudentContext>
        {
            public StudentContext CreateDbContext(string[] args)
            {
                var configurationBuilder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    
                IConfigurationRoot configuration = configurationBuilder.Build();
                string connectionString = configuration.GetConnectionString("Storage");
    
                DbContextOptionsBuilder<StudentContext> optionsBuilder = new DbContextOptionsBuilder<StudentContext>()
                    .UseSqlite(connectionString);
    
                return new StudentContext(optionsBuilder.Options);
            }
    
            static void Main(string[] args)
            {
                Program p = new Program();
    
                using (StudentContext sc = p.CreateDbContext(null))
                {
                    sc.Database.Migrate();
    
                    sc.Students.AddRange
                    (
                        new Student { Name = "Isaac Newton" },
                        new Student { Name = "C.F. Gauss" },
                        new Student { Name = "Albert Einstein" }
                    );
    
                    sc.SaveChanges();
                }
            }
        }
    }
