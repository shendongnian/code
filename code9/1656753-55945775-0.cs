cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	base.OnModelCreating(modelBuilder);
	foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
	{
		relationship.DeleteBehavior = DeleteBehavior.Restrict;
	}
	modelBuilder.Entity<User>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
	modelBuilder.Entity<User>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
	modelBuilder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
	modelBuilder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
	modelBuilder.EnableAutoHistory(null);
	modelBuilder.Entity<Post>()
		.HasOne(p => p.Medias)
		.WithOne(m => m.Post)
		.HasForeignKey<Media>(p => p.PostId);
}
And you only need to defined your connection in startup.cs file like this
cs
services.AddDbContextPool<ApplicationDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
b => b.MigrationsAssembly("AwesomeCMSCore")).UseOpenIddict());
Hope I make it clear for you. Please let me know if you have any problem
Full source code can be found [here](https://github.com/SaiGonSoftware/Awesome-CMS-Core/blob/master/src/AwesomeCMSCore/Modules/AwesomeCMSCore.Modules.Entities/Data/ApplicationDbContext.cs) and [here](https://github.com/SaiGonSoftware/Awesome-CMS-Core/blob/master/src/AwesomeCMSCore/AwesomeCMSCore/Extension/ServiceCollectionExtensions.cs#L171-L179)
