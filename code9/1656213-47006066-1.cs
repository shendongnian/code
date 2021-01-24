    public class ParentClassConfiguration : EntityTypeConfiguration<ParentClass>
    {
      public ParentClassConfiguration()
      {
        ToTable("ParentTable");
        HasKey(x => x.ParentObjectId)
          .Property(x => x.ParentObjectId)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      
        HasRequired(x => x.ChildObject)
          .WithMany()
          .HasForeignKey(x => x.ChildObjectId));
          .WillCascadeOnDelete(false);
      }
    }
