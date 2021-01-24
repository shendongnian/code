    modelBuilder.Entity<MenuItemRelation>()
        .HasKey(e => new { e.PrimaryMenuItemId, e.RelatedMenuItemId });
    modelBuilder.Entity<MenuItemRelation>()
        .HasOne(d => d.PrimaryMenuItem)
        .WithMany(p => p.RelatedItems)
        .HasForeignKey(d => d.PrimaryMenuItemId)
        .OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<MenuItemRelation>()
        .HasOne(d => d.RelatedMenuItem)
        .WithMany(p => p.RelatedTo)
        .HasForeignKey(d => d.RelatedMenuItemId)
        .OnDelete(DeleteBehavior.Restrict);
