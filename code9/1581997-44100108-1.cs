    public class Model1 : DbContext
    {
        public Model1()
            : base( "name=Model1" )
        {
        }
    
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
    
            var language = modelBuilder.Entity<Language>();
            language.HasKey( e => e.Id );
            language.Property( e => e.Name ).IsRequired().HasMaxLength( 100 );
    
            var product = modelBuilder.Entity<Product>();
    
            product.HasKey( e => e.Id );
            product.Property( e => e.Name ).IsRequired().HasMaxLength( 100 );
            product.Property( e => e.Description ).IsOptional().HasMaxLength( 1000 );
            product.Property( e => e.IsDeleted ).IsRequired();
            product.Property( e => e.IsApproved ).IsRequired();
            product.HasRequired( e => e.Category )
                .WithMany()
                .HasForeignKey( e => e.CategoryId )
                .WillCascadeOnDelete( false );
    
            var category = modelBuilder.Entity<Category>();
    
            category.HasKey( e => e.Id );
            category.Property( e => e.Name ).IsRequired().HasMaxLength( 100 );
            category.HasMany( e => e.Translations )
                .WithRequired( e => e.Category )
                .HasForeignKey( e => e.CategoryId )
                .WillCascadeOnDelete( true );
    
            var categoryTrans = modelBuilder.Entity<CategoryTrans>();
            // composite key
            categoryTrans.HasKey( e => new { e.CategoryId, e.LanguageId } );
            categoryTrans.HasRequired( e => e.Language )
                .WithMany()
                .HasForeignKey( e => e.LanguageId )
                .WillCascadeOnDelete( false );
    
        }
    }
