    public abstract class EntityMapConfiguration<T> : DbEntityConfiguration<T> where T : class
    {
        public override void Configure(EntityTypeBuilder<T> entity)
        {
            //if (typeof(ICreationAudited<ApplicationUser>).GetTypeInfo().IsAssignableFrom(typeof(T)))
            //{
            //    entity.HasOne(nameof(ICreationAudited<ApplicationUser>.CreatorUser))
            //        .WithOne()
            //        .HasForeignKey(typeof(T), "CreatorUserId");
            //}
            //if (typeof(IModificationAudited<ApplicationUser>).GetTypeInfo().IsAssignableFrom(typeof(T)))
            //{
            //    entity.HasOne(nameof(IModificationAudited<ApplicationUser>.LastModifierUser))
            //       .WithOne()
            //       .HasForeignKey(typeof(T), "LastModifierUserId");
            //}
            if (typeof(IHasConcurrency).GetTypeInfo().IsAssignableFrom(typeof(T)))
                entity.Property(nameof(IHasConcurrency.RowVersion)).IsRowVersion();
        }
    }
