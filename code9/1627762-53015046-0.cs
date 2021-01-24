    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            CreateUserModel(modelBuilder.Entity<User>());
            CreateRoleModel(modelBuilder.Entity<Role>());
        }
        private void CreateRoleModel(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(role => role.UserRoles).
                WithOne(**e=> e.Role**).
                HasForeignKey(userRole => userRole.RoleId).
                IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
        private void CreateUserModel(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(user => user.UserRoles).
                WithOne(**e=>e.User**).
                HasForeignKey(userRole => userRole.UserId).
                IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
