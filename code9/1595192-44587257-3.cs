	public class YourContext: DbContext
	{
		...
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasMany<Document>(u => u.Documents)
				.WithMany(d => d.Users)
				.Map(userJointDocument =>
					{
						userJointDocument.MapLeftKey("IDUser");
						userJointDocument.MapRightKey("IDDocument");
						userJointDocument.ToTable("User_joint_Document");
					});
		}
		
		...
	}
