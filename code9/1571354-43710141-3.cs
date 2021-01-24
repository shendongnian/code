    using System;
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    
                IConfigurationRoot configuration = builder.Build();
    
                var optionsBuilder = new DbContextOptionsBuilder();
    
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    
                var context = new DbContext(optionsBuilder.Options);
    
                context.Database.EnsureCreated();
            }
        }
    }
