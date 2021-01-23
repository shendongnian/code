    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
    using Microsoft.Extensions.Options;
    
    namespace AdventureWorksAPI.Models
    {
        public class AdventureWorksDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            public AdventureWorksDbContext(IOptions<AppSettings> appSettings)
            {
                ConnectionString = appSettings.Value.ConnectionString;
            }
    
            public String ConnectionString { get; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
    
                // this block forces map method invoke for each instance
                var builder = new ModelBuilder(new CoreConventionSetBuilder().CreateConventionSet());
    
                OnModelCreating(builder);
    
                optionsBuilder.UseModel(builder.Model);
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.MapProduct();
    
                base.OnModelCreating(modelBuilder);
            }
        }
    }
