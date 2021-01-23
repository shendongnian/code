    public class OneTwoConfiguration : EntityTypeConfiguration<OneTwo>
    {
    	public OneTwoConfiguration()
    	{
            // Table and Schema Name declarations are optional
            ToTable("OneTwo", "dbo");
            // composite primary key
            HasKey(p => new { p.OneId, p.TwoId });   
    
            HasRequired(a => a.One)
                .WithMany(c => c.OneTwos)
               .HasForeignKey(fk => fk.OneId)
               .WillCascadeOnDelete(false); 
  
            HasRequired(a => a.Two)
                .WithMany(c => c.OneTwos)
               .HasForeignKey(fk => fk.TwoId)
               .WillCascadeOnDelete(false);
            // TODO: handle orphans when last association is deleted
        }
    }
