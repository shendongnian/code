    public class ABMap : EntityTypeConfiguration<AB>
    {
        public ABMap()
        {
            this.HasKey(a => a.Id);
            this.HasRequired(e => e.A)
                .WithMany(a => a.ABs)
                .HasForeignKey(e => e.AId)
                .WillCascadeOnDelete(false);
            this.Property(a => a.AId);
            this.HasRequired(c => c.B)
                .WithMany(b => b.ABs)
                .HasForeignKey(e => e.BId)
                .WillCascadeOnDelete(false);
            this.Property(a => a.BId);
            this.Property(e => e.AId)
                    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_AB", 1) { IsUnique = true }));
            this.Property(e => e.BId)
                    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_AB", 2) { IsUnique = true }));
        }
    }
