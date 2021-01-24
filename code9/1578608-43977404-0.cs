    public class Model1 : DbContext
    {
        public Model1()
            : base( "name=Model1" )
        {
        }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
            var location = modelBuilder.Entity<Location>();
            // location.ToTable( nameof( Location ) );
            location.HasKey( e => e.Id );
            location.Property( e => e.Code )
                .IsRequired()
                .HasMaxLength( 20 );
            location.Property( e => e.Name )
                .HasMaxLength( 125 );
            location.HasOptional( e => e.Parent )
                .WithMany( e => e.Children )
                .HasForeignKey( e => e.ParentId )
                .WillCascadeOnDelete( false );
        }
        public virtual DbSet<Location> Locations { get; set; }
    }
    public class Location
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Location Parent { get; set; }
        public virtual ICollection<Location> Children { get; set; }
    }
