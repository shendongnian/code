    private void CreateRoleModel(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(role => role.UserRoles).
                WithOne(**"Role"**).
                HasForeignKey(userRole => userRole.RoleId).
                IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
        private void CreateUserModel(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(user => user.UserRoles).
                WithOne(**"User"**).
                HasForeignKey(userRole => userRole.UserId).
                IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
