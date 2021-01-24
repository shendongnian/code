        public class UserMap : EntityTypeConfigurationBase<User>
        {
           new public void Configure(EntityTypeBuilder<User> builder)
           {
            builder.HasKey(u => u.Id);
            builder
                .HasOne(u => u.ProfileItem)
                .WithOne()
                .HasForeignKey<Profile>(p => p.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("User");
            base.Configure(builder);
            }
        }
