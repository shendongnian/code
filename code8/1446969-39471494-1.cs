    public class EntryMap : EntityTypeConfiguration<Entry >
    {
        public Entry Map()
        {
            Property(t => t.databaseDateTime)
                .HasColumnName("DateTime");
            Ignore(t => t.MyDateTimeWithoutMs );
