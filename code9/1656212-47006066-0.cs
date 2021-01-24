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
          .Map(x => x.MapKey("ChildObjectId"));
          .WillCascadeOnDelete(false);
      }
    }
