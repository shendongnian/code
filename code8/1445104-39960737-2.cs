    public class SomeTableConfig : EntityTypeConfiguration<SomeTable>
    {
        public SomeTableConfig()
        {
            this.Property(a => a.StartTime).HasColumnType("datetimeoffset").HasPrecision(0);
            this.Property(a => a.EndTime ).HasColumnType("datetimeoffset").HasPrecision(0);
        }
    }
