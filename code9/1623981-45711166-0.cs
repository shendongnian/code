    public class StatusMap : EntityTypeConfiguration<Status>
    {
         public StatusMap()
         {
             ToTable("StatusTable")
             .HasKey(p => p.ID);
         }
    }
