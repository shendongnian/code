     protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Wishlist>()
                        .HasMany<Product>(s => s.Products)
                        .WithMany(c => c.Wishlists)
                        .Map(cs =>
                                {
                                    cs.MapLeftKey("WishlistRefId");
                                    cs.MapRightKey("ProductRefId");
                                    cs.ToTable("WishlistProduct");
                                });
        
        }
