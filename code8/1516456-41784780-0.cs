    protected override void Seed(ApplicationDbContext context)
    {
    	//  This method will be called after migrating to the latest version.
    
    	//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
    	//  to avoid creating duplicate seed data. E.g.
    
    	//add roles
    	context.Roles.AddOrUpdate(p => p.Id,
    		new IdentityRole()
    		{
    			Id = EnumUtility<AspNetRoles>.GetAppRoleId(AspNetRoles.None),
    			Name = AspNetRoles.None.ToString()
    		});
    }
