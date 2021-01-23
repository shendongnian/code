                // -------------- Defining BrandsOfCategories Entity --------------- //
            modelBuilder.Entity<BrandCategory>()
                .HasKey(input => new { input.BrandId, input.CatId })
                .HasName("BrandsOfCategories_CompositeKey");
            modelBuilder.Entity<BrandCategory>()
                .Property(input => input.DeletedAt)
                .IsRequired(false);
            // -------------- Defining BrandsOfCategories Entity --------------- //
       public class BrandCategory
    {
        public int CatId { get; set; }
        public int BrandId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Category Category { get; set; }
        public Brands Brand { get; set; }
    }
