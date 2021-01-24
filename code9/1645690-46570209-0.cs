    public class SharedKeyPrincipal
    {
        public int Id { get; set; }
        public int PrincipalProperty { get; set; }
        public SharedKeyDependent Dependent { get; set; }
    }
    public class SharedKeyDependent
    {
        public int Id { get; set; }
        public int DependentProperty { get; set; }
        public SharedKeyPrincipal Principal { get; set; }
    }
    modelBuilder.Entity<SharedKeyDependent>()
        .HasOne( d => d.Principal )
        .WithOne( p => p.Dependent )
        .IsRequired()
        .HasForeignKey<SharedKeyDependent>( d => d.Id );
    var principals = dbContext.Set<SharedKeyPrincipal>()
        .Include( p => p.Dependent )
        .ToArray();
